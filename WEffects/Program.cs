using Enemies;
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
            Elements_enum status = new Elements_enum();

            #region Generazione avversario
            // Genero l'avversario
            Console.WriteLine("Genera avversario:");
            Console.WriteLine("1) Grineer");
            Console.WriteLine("2) Corpus");
            Console.WriteLine("3) Infested");
            while (true) {
                if (!int.TryParse(Console.ReadLine(), out int spawnEnemy))
                {
                    // CONTROLLO se è un numero
                    Console.WriteLine("Input non valido. Inserisci un numero tra 1 e 3.");
                    continue;
                }
                else if (spawnEnemy < 1 || spawnEnemy > 3)
                {
                    // CONTROLLO se è un numero compreso tra 1 e 3
                    Console.WriteLine($"Valore '{spawnEnemy}' non valido! Scegli tra 1 e 3");
                    continue;
                }
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
                        break;
                    case 3:
                        var i = new Infested((short)infested.Count, rng);
                        infested.Add(i);
                        factions.Add(i);
                        break;
                }
                break;
            }
            Console.WriteLine("Il nemico è stato generato");
            foreach (var f in factions)
            {
                Console.WriteLine(f);
            }
            #endregion

            #region Sistema di turni e di attacco
            #region Scelta dell'arma

            //Genero un'arma e per ora l'arma che si andrà a scegliere determinerà il numero di attacchi
            Console.WriteLine("Genera un'arma da usare:");
            Console.WriteLine("1) Fucile d'assalto ------> | 4 attacchi per turno | 10% probabilità effetto | 20% probabilità critico | +100% danno critico | 6 danno");
            Console.WriteLine("2) Pistola ---------------> | 3 attacchi per turno | 20% probabilità effetto | 25% probabilità critico | +50% danno critico | 10 danno");
            Console.WriteLine("3) Fucile a pompa --------> | 2 attacchi per turno | 50% probabilità effetto | 7% probabilità critico | +200% danno critico | 14 danno");
            Console.WriteLine("4) Fucile di precisione --> | 1 attacchi per turno | 30% probabilità effetto | 15% probabilità critico | +250% danno critico | 20 danno");
            int id_weapon = Convert.ToInt32(Console.ReadLine());

            if (id_weapon == 1)
            {
                weapon.Add(new Weapons { BaseDamage = 6, CritDamage = 2, CritChance = 20, StatusChance = 50, Status = 2, Shot = 4 });
            }
            else if (id_weapon == 2)
            {
                weapon.Add(new Weapons { BaseDamage = 10, CritDamage = 1.5, CritChance = 25, StatusChance = 60, Status = 1, Shot = 3 });
            }
            else if (id_weapon == 3)
            {
                weapon.Add(new Weapons { BaseDamage = 14, CritDamage = 3, CritChance = 7, StatusChance = 15, Status = 1, Shot = 2 });
            }
            else if (id_weapon == 4)
            {
                weapon.Add(new Weapons { BaseDamage = 20, CritDamage = 3.5, CritChance = 15, StatusChance = 25, Status = 1, Shot = 1 });

            }
            #endregion

            round.Attack(factions, weapon);
            //round.Fire(factions, weapon);

            #endregion
        }
    }
}
