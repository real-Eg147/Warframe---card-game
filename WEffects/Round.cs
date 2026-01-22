using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEffects
{
    public class Round
    {
        int BaseDamage = 1;
        public List<Weapons> wpns = new List<Weapons>();
        
        public double newGrHP;
        public void Attack(List<Grineer> grineer)
        {
            if (grineer[0].Armor > 20)
            {
                    newGrHP = grineer[0].Health - (BaseDamage * 0.90);
                    grineer[0].Health = newGrHP;
            }
            else
            {
                newGrHP = grineer[0].Health - BaseDamage;
                grineer[0].Health = newGrHP;
            }

            Console.WriteLine(newGrHP);
        }
    }
}
