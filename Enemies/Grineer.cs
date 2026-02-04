using WEffects;

namespace Enemies
{
    public class Grineer : Factions
    {
        private static readonly StatRange HealthRange = new() { Min = 30.0, Max = 50.0 };
        // ARMATURA --> da 0,2 a 0,75
        private static readonly StatRange ArmorRange = new() { Min = 0.2, Max = 0.75 };
        private static readonly StatRange ShieldRange = new() { Min = 0.0, Max = 0.0 };

        public Grineer(short id, Random rnd) : base(id)
        {
            Health = HealthRange.Roll(rnd);
            Armor = ArmorRange.Roll(rnd);
            Shield = ShieldRange.Roll(rnd);
        }

        public override string Nome => "Grineer";
    }
}
