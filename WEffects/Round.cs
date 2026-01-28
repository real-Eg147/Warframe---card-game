using Enemies;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEffects
{
    // Come funziona il round? Una volta scelti gli armamenti decidi con quale attaccare, ogni armamento può colpire più volte nello stesso round (5 colpi = 5 hit per round)
    public class Round : Weapons
    {
        public List<Damage> damage = new List<Damage>();
        public double newGrHP;
        public double newDamage;
        public short counter;

        // Nel metodo "Attack" devo fare in modo che si completamente flessibile, deve calcolare ogni statistica di danno in base al nemico che affronta del giocatore
        public void Attack(List<Grineer> grineer, List<Weapons> weapon)
        {
            // Weapon shot determina quanti attacchi fai in un turno solo
            while (counter < weapon[0].Shot)
            {
                // Controllo dell'armatura nemica
                if (grineer[0].Armor > 0)
                {
                    newDamage = weapon[0].BaseDamage - (weapon[0].BaseDamage * grineer[0].Armor);
                    grineer[0].Health = grineer[0].Health - newDamage;
                }
                else
                {
                    grineer[0].Health = grineer[0].Health - weapon[0].BaseDamage;
                }
                Console.WriteLine(grineer[0].Health);
                counter++;
            }
        }
        public void Attack(List<Corpus> corpus, List<Weapons> weapon)
        {
            // Controllo dell'armatura nemica
            if (corpus[0].Shield > 0)
            {
                newDamage = weapon[0].BaseDamage - corpus[0].Shield;
            }
            else
            {
                newGrHP = corpus[0].Health - weapon[0].BaseDamage;
            }
            Console.WriteLine(newGrHP);
        }
    }
}
