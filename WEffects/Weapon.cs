namespace WEffects
{
    public class Weapon : Damage
    {
        public double BaseDamage { get; set; }
        public double CritDamage { get; set; }
        public double CritChance { get; set; }
        public Elements_class StatusEffect = new();

        public double CalculateDamage(List<Factions> factions)
        {
            double roll = rnd.Next(0, 100);
            double damage = BaseDamage;

            // **** SCUDI ****
            if (factions[0].Shield > 0.0)
            {
                factions[0].Shield -= damage;
                if (factions[0].Shield < 0.0)
                    factions[0].Shield = 0.0;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"||SALUTE = {factions[0].Health:F1} ||ARMATURA = {factions[0].Armor:F2} ||SCUDI = {factions[0].Shield:F2}");
            }

            // **** ARMATURA ****
            if (factions[0].Armor > 0.0 && factions[0].Shield == 0.0)
            {
                damage -= (damage * factions[0].Armor);
                factions[0].Health -= damage;
                Console.WriteLine($"||SALUTE = {factions[0].Health:F1} ||ARMATURA = {factions[0].Armor:F2} ||SCUDI = {factions[0].Shield:F2}");
            }

            // **** CALCOLO PROBABILITA' E DANNO CRITICO ****
            if (roll <= CritChance && factions[0].Armor > 0.0 && factions[0].Shield == 0.0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Danno critico alla salute e armatura!");
                Console.WriteLine($"|| ROLL = {roll}");
                Console.ResetColor();

                factions[0].Health = (damage * CritDamage) - (damage * factions[0].Armor);
                Console.WriteLine($"||SALUTE = {factions[0].Health:F1} ||ARMATURA = {factions[0].Armor:F2} ||SCUDI = {factions[0].Shield:F2}");
            }
            else if (roll <= CritChance && factions[0].Shield == 0.0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Danno critico!");
                Console.WriteLine($"|| ROLL = {roll}");
                Console.ResetColor();
                factions[0].Health = factions[0].Health - (damage * CritDamage);
                Console.WriteLine($"||SALUTE = {factions[0].Health:F1} ||ARMATURA = {factions[0].Armor:F2} ||SCUDI = {factions[0].Shield:F2}");
            }
            else if (roll > CritChance && factions[0].Armor == 0 && factions[0].Shield == 0.0)
            {
                Console.WriteLine("Nessun danno critico!");
                Console.WriteLine($"||ROLL = {roll}");

                factions[0].Health -= damage;
                Console.WriteLine($"||SALUTE = {factions[0].Health:F1} ||ARMATURA = {factions[0].Armor:F2} ||SCUDI = {factions[0].Shield:F2}");
            }

            return damage;

        }
    }
}
