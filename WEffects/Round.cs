namespace WEffects
{
    // Come funziona il round? Una volta scelti gli armamenti decidi con quale attaccare, ogni armamento può colpire più volte nello stesso round (5 colpi = 5 hit per round)
    public class Round : Weapons
    {
        public List<Damage> damage = new List<Damage>();
        public Elements_class StatusEffect = new();
        public double newHP;
        public double newDamage;
        public short counter;
        public short counterEffect;
        public Random rnd = new Random();

        // Nel metodo "Attack" devo fare in modo che sia completamente flessibile, deve calcolare ogni statistica di danno in base al nemico che affronta del giocatore
        public void Attack(List<Factions> factions, List<Weapons> weapon)
        {

            // Weapon shot determina quanti attacchi fai in un turno solo
            while (counter < weapon[0].Shot)
            {
                // PRIMO PASSO: probabilità di danno critico
                var CritChance = rnd.Next(0, 100);

                // **** SCUDI ****
                if (factions[0].Shield > 0.0)
                {
                    factions[0].Shield = factions[0].Shield - weapon[0].BaseDamage;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"||SCUDI [{factions[0].Shield.ToString("F1")}]");
                    Console.ResetColor();
                    StatusEffect.Electric(factions, weapon);
                    if (factions[0].Shield < 0.0)
                    {
                        factions[0].Shield = Math.Max(0.0, factions[0].Shield);
                        Console.WriteLine("Scudi infranti");
                    }
                }
                // **** ARMATURA ****
                if (factions[0].Armor > 0.0 && factions[0].Shield == 0.0)
                {
                    newDamage = weapon[0].BaseDamage - (weapon[0].BaseDamage * factions[0].Armor);
                    if (CritChance <= weapon[0].CritChance)
                    {
                        newDamage = (weapon[0].BaseDamage * weapon[0].CritDamage) - (weapon[0].BaseDamage * factions[0].Armor);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Danno critico!");
                        Console.ResetColor();
                    }
                    factions[0].Health = factions[0].Health - newDamage;
                    Console.WriteLine($"||SALUTE [{factions[0].Health.ToString("F1")}]");
                }
                // **** SALUTE ****
                else if (factions[0].Armor == 0.0 && factions[0].Shield == 0.0)
                {
                    factions[0].Health = factions[0].Health - weapon[0].BaseDamage;
                }
                //Console.WriteLine($"||SALUTE [{factions[0].Health.ToString("F1")}]");
                // ** EFFETTI ELEMENTALI **
                var statusActions = new Dictionary<int, Action>
                {
                    { 1, () => StatusEffect.Fire(factions, weapon) },
                    //{ 2, () => StatusEffect.Electric(factions, weapon) }
                };

                if (statusActions.TryGetValue(weapon[0].Status, out var action))
                {
                    action();
                }

                counter++;
            }
        }
        //public void StatusEffect(List<Factions> factions, List<Weapons> weapon)
        //{
        //    var StatusChance = rnd.Next(0, 100);
        //    short ping = 0;
        //    // *** FUOCO ***
        //    if (StatusChance <= weapon[0].StatusChance)
        //    {
        //        if (weapon[0].Status == 1)
        //        {
        //            if (factions[0].Armor > 0.0 && ping == 0)
        //            {
        //            factions[0].Armor = factions[0].Armor / 2;
        //            ping = 1;
        //            }
        //            do
        //            {
        //                factions[0].Health = factions[0].Health - (weapon[0].BaseDamage * 0.2);
        //                Console.ForegroundColor = ConsoleColor.DarkYellow;
        //                Console.WriteLine("Danno da fuoco!");
        //                Console.ResetColor();
        //                Console.WriteLine(factions[0].Health.ToString("F1"));
        //                counterEffect++;
        //            } while (counterEffect < weapon[0].Shot);
        //        }
        //    }
    }
}
