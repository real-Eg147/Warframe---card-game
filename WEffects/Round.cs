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
        public Random rnd = new Random();

        // Nel metodo "Attack" devo fare in modo che si completamente flessibile, deve calcolare ogni statistica di danno in base al nemico che affronta del giocatore
        public void Attack(List<Grineer> g, List<Weapons> weapon)
        {
           
            // Weapon shot determina quanti attacchi fai in un turno solo
            while (counter < weapon[0].Shot)
            {
                var CritChance = rnd.Next(0, 100);
                // ** Controllo dell'armatura nemica **
                // **
                // ** Se il nemico ha l'armatura allora NUOVO DANNO assume il valore di DANNO BASE * ARMATURA NEMICA sottratto al DANNO BASE. Quindi SALUTE NEMICA - NUOVO DANNO **
                // ** Altrimenti SALUTE NEMICA - DANNO BASE **

                if (g[0].Armor > 0)
                {
                    newDamage = weapon[0].BaseDamage - (weapon[0].BaseDamage * g[0].Armor);
                    
                    if (CritChance <= weapon[0].CritChance)
                    {
                        newDamage = newDamage * weapon[0].CritDamage;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Danno critico!");
                        Console.ResetColor();
                    }
                    g[0].Health = g[0].Health - newDamage;
                }
                else
                {
                    g[0].Health = g[0].Health - weapon[0].BaseDamage;
                }

                Console.WriteLine(g[0].Health);
                counter++;
            }
        }
        public void Attack(List<Corpus> corpus, List<Weapons> weapon)
        {
            // Controllo dello scudo nemico
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

        public void Attack(List<Infested> infested, List<Weapons> weapon)
        {
            // Controllo dell'armatura nemica
            if (infested[0].Shield > 0)
            {
                newDamage = weapon[0].BaseDamage - infested[0].Shield;
            }
            else
            {
                newGrHP = infested[0].Health - weapon[0].BaseDamage;
            }
            Console.WriteLine(newGrHP);
        }
    }
}
