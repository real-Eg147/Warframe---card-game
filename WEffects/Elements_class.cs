namespace WEffects
{
    public class Elements_class
    {
        public short counterEffect;
        public Random rnd = new Random();
        private short ping = 0;
        public void Fire(List<Factions> factions, List<Weapon> weapon)
        {
            var StatusChance = rnd.Next(0, 100);
            // *** FUOCO ***
            // Il danno da fuoco può essere inflitto solo se gli scudi nemici sono infranti
            if (StatusChance <= weapon[0].StatusChance && factions[0].Shield == 0.0)
            {
                if (weapon[0].Status == 1)
                {
                    if (factions[0].Armor > 0.0 && ping == 0)
                    {
                        factions[0].Armor = factions[0].Armor / 2;
                        ping = 1;
                        Console.WriteLine($"||ARMATURA [{factions[0].Armor.ToString("F1")}]");
                    }
                    do
                    {
                        factions[0].Health = factions[0].Health - (weapon[0].BaseDamage * 0.2);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Danno da fuoco!");
                        Console.ResetColor();
                        Console.WriteLine(factions[0].Health.ToString("F1"));
                        counterEffect++;
                    } while (counterEffect < weapon[0].Shot);
                }
            }
            counterEffect = 0;
        }


        public void Electric(List<Factions> factions, List<Weapon> weapon)
        {
            var StatusChance = rnd.Next(0, 100);
            if (StatusChance <= weapon[0].StatusChance)
            {
                factions[0].Shield = factions[0].Shield - (weapon[0].BaseDamage * 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Danni elettrici! ---- ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (factions[0].Shield < 0.0)
                {
                    factions[0].Shield = Math.Max(0.0, factions[0].Shield);
                    Console.WriteLine("Scudi infranti");
                }
                Console.WriteLine($"SCUDI [{factions[0].Shield.ToString("F1")}]");
                Console.ResetColor();
            }

        }

        public void Toxic(List<Factions> factions, List<Weapon> weapon)
        {
            var StatusChance = rnd.Next(0, 100);
            // *** TOSSCITà ***
            // Il danno tossico può essere inflitto alla salute, ignorando completamente gli scudi
            if (StatusChance <= weapon[0].StatusChance)
            {
                if (weapon[0].Status == 3)
                {
                    do
                    {
                        factions[0].Health = factions[0].Health - (weapon[0].BaseDamage * 0.2);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Danno tossico!");
                        Console.ResetColor();
                        Console.WriteLine(factions[0].Health.ToString("F1"));
                        counterEffect++;
                    } while (counterEffect < 3);
                }
            }
            counterEffect = 0;
        }

        public void Ice(List<Factions> factions)
        {

        }


        public void Viral(List<Factions> factions, List<Weapon> weapon)
        {
            // Il danno viral non ignore ne armatura e ne scudi, viene applicato solo quando gli scudi sono infranti, e applica un danno bonus alla solute per ogni colpo sferrato
            if (factions[0].Shield == 0)
            {
                double stack = 1.0;
                var StatusChance = rnd.Next(0, 100);
                if (StatusChance <= weapon[0].StatusChance)
                {
                    if (weapon[0].Status == 5)
                    {
                        do
                        {
                            stack = stack + 0.15;
                            weapon[0].BaseDamage = weapon[0].BaseDamage * stack;
                            if (factions[0].Armor > 0.0)
                            {
                                weapon[0].BaseDamage = weapon[0].BaseDamage - (weapon[0].BaseDamage * factions[0].Armor);
                            }
                            factions[0].Health -= weapon[0].BaseDamage;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine($"Danno virale! bonus danno +{stack.ToString("F1")}");
                            Console.ResetColor();
                            Console.WriteLine(factions[0].Health.ToString("F1"));
                            counterEffect++;
                        } while (counterEffect < 3);
                    }
                }
                counterEffect = 0;
            }
        }

        public void Magnetic(List<Factions> factions)
        {

        }

        public void Radiation(List<Factions> factions)
        {

        }

        public void Corrosive(List<Factions> factions)
        {

        }
    }
}
