using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEffects;

namespace Enemies
{
    public class Infested : Factions
    {
        private static readonly StatRange HealthRange = new() { Min = 70, Max = 100 };
        private static readonly StatRange ArmorRange = new() { Min = 0, Max = 0 };
        private static readonly StatRange ShieldRange = new() { Min = 0, Max = 0 };

        public Infested(short id, Random rnd) : base(id)
        {
            Health = HealthRange.Roll(rnd);
            Armor = ArmorRange.Roll(rnd);
            Shield = ShieldRange.Roll(rnd);
        }

        public override string Nome => "Infested";
    }
}

