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
        public double newHP;
        public double newDamage;
        public short counter;
        public Random rnd = new Random();

        // Nel metodo "Attack" devo fare in modo che sia completamente flessibile, deve calcolare ogni statistica di danno in base al nemico che affronta del giocatore
        public void Attack(List<Factions> factions, List<Weapons> weapon)
        {

            // Weapon shot determina quanti attacchi fai in un turno solo
            while (counter < weapon[0].Shot)
            {
                // PRIMO PASSO: probabilità di danno critico
                var CritChance = rnd.Next(0, 100);

                // ** Controllo dell'armatura nemica **
                // **
                // ** Se il nemico ha l'armatura allora NUOVO DANNO assume il valore di DANNO BASE * ARMATURA NEMICA sottratto al DANNO BASE. Quindi SALUTE NEMICA - NUOVO DANNO **
                // ** Altrimenti SALUTE NEMICA - DANNO BASE **
                if (factions[0].Shield > 0.0)
                {
                    newDamage = factions[0].Shield - weapon[0].BaseDamage;
                    factions[0].Shield = newDamage;
                    Console.WriteLine("Danno agli scudi");
                    Console.WriteLine(factions[0].Shield.ToString("F1"));
                    if (factions[0].Shield < 0.0)
                    {
                        factions[0].Shield = Math.Max(0.0, factions[0].Shield);
                        Console.WriteLine("Scudi infranti");
                    }
                }
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
                    Console.WriteLine("Danno alla salute");
                }
                else if (factions[0].Armor == 0.0 && factions[0].Shield == 0.0)
                {
                    factions[0].Health = factions[0].Health - weapon[0].BaseDamage;
                }

                Console.WriteLine(factions[0].Health.ToString("F1"));
                counter++;
            }
        }
    }
}
