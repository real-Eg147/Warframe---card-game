using Enemies;
using Microsoft.VisualBasic.FileIO;

namespace WEffects
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            List<Factions> factions = new();
            List<Grineer> grineer = new List<Grineer>();
            List<Corpus> corpus = new List<Corpus>();
            List<Infested> infested = new List<Infested>();
            List<Weapons> weapon = new List<Weapons>();
            Round round = new Round();
            Damage damage = new Damage();

            #region Generazione avversario
            // Genero l'avversario
            //int myCycle;
            //do
            //{
            Console.WriteLine("Genera avversario:");
            Console.WriteLine("1) Grineer");
            Console.WriteLine("2) Corpus");
            Console.WriteLine("3) Infested");
            int spawnEnemy = Convert.ToInt32(Console.ReadLine());
                switch (spawnEnemy)
                {
                    case 1:
                    var g = new Grineer((short)grineer.Count, rng);
                    grineer.Add(g);
                    factions.Add(g);
                        break;
                    case 2:
                    var c = new Corpus((short)corpus.Count, rng);
                    corpus.Add(c);
                    factions.Add(c);
                    //factions.Add(new Corpus((short)(factions.Count + 1), rng));
                    break;
                    case 3:
                    var i = new Infested((short)infested.Count, rng);
                    infested.Add(i);
                    factions.Add(i);
                    break;
                }
                //List<Factions> factions = new()
                //{
                //    new Corpus(1, rng),
                //    new Grineer(2, rng),
                //    new Infested(3, rng)
                //};

                Console.WriteLine("Il nemico è stato generato");
                foreach (var f in factions)
                {
                    Console.WriteLine(f);
                }

                //Console.WriteLine("Vuoi generarne un altro?");
                //Console.WriteLine("1) SI");
                //Console.WriteLine("2) NO");
                //myCycle = Convert.ToInt32(Console.ReadLine());

            //} while (myCycle == 1);
            #endregion


            #region Sistema di turni e di attacco
            #region Scelta dell'arma
            //Genero un'arma e per ora l'arma che si andrà a sceglier e determinerà il numero di attacchi
            Console.WriteLine("Genera un'arma da usare:");
            Console.WriteLine("1) Fucile d'assalto ------> | 3 attacchi per turno | 10% probabilità effetto | 20% probabilità critico | +100% danno critico | 1 danno");
            Console.WriteLine("2) Pistola ---------------> | 2 attacchi per turno | 20% probabilità effetto | 20% probabilità critico | +100% danno critico | 2 danno");
            Console.WriteLine("3) Fucile a pompa --------> | 1 attacchi per turno | 50% probabilità effetto | 10% probabilità critico | +50% danno critico | 4 danno");
            Console.WriteLine("4) Fucile di precisione --> | 1 attacchi per turno | 30% probabilità effetto | 40% probabilità critico | +250% danno critico | 4 danno");
            int id_weapon = Convert.ToInt32(Console.ReadLine());
            if (id_weapon == 1)
            {
                weapon.Add(new Weapons { BaseDamage = 1, CritDamage = 2, CritChance = 20, StatusChance = 0.1, Shot = 3 });
            }
            else if (id_weapon == 2)
            {
                weapon.Add(new Weapons { BaseDamage = 2, CritDamage = 2, CritChance = 20, StatusChance = 0.2, Shot = 2 });
            }
            else if (id_weapon == 3)
            {
                weapon.Add(new Weapons { BaseDamage = 4, CritDamage = 0.5, CritChance = 10, StatusChance = 0.5, Shot = 1 });
            }
            else if (id_weapon == 4)
            {
                weapon.Add(new Weapons { BaseDamage = 1, CritDamage = 2, CritChance = 10, StatusChance = 0.1, Shot = 1 });

            }
            #endregion

            // Scelgo il nemico da attaccare
            //Console.WriteLine("Quale nemico vuoi attaccare?");
            //for (int i = 0; i < factions.Count; i++)
            //{
            //    Console.WriteLine($"--- {factions[i]}");
            //}


            switch (spawnEnemy)
                {
                    case 1:
                    // FUNZIONA! (per ora)
                    // Per attaccare devo sapere quale nemico e con quale arma
                    // Ora il 28/01/2026 devo sapere quanti nemici devo attaccare
                    round.Attack(grineer, weapon);
                        break;
                    case 2:
                        round.Attack(corpus, weapon);
                        break;
                    case 3:
                        round.Attack(infested, weapon);
                        break;
                    case 4:
                        break;
                }
            #endregion

            foreach (var gr in grineer)
            {
                Console.WriteLine(gr);
            }

            //wpn.Attack(grnr);

        }
    }
}
