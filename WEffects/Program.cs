using Enemies;

namespace WEffects
{
    public class Program
    {
        static void Main(string[] args)
        {
            Factions faction = new Factions();
            List<Grineer> grineer = new List<Grineer>();
            List<Corpus> crps = new List<Corpus>();
            List<Infested> inf = new List<Infested>();
            List<Weapons> weapon = new List<Weapons>();
            Round round = new Round();
            Damage damage = new Damage();

            // Genero l'avversario
            Console.WriteLine("Genera avversario:");
            Console.WriteLine("1) Grineer");
            Console.WriteLine("2) Corpus");
            Console.WriteLine("3) Infested");
            int selectEnemy = Convert.ToInt32(Console.ReadLine());


            switch (selectEnemy)
            {
                case 1:
                        grineer.Add(new Grineer { id = 0, Health = 20, Armor = 0.25, Shield = 0 });
                    break;
                case 2:
                        crps.Add(new Corpus { id = 0, Health = 10, Armor = 0, Shield = 20 });
                    break;
                case 3:
                        inf.Add(new Infested { id = 0, Health = 15, Armor = 0, Shield = 0 });
                    break;
                
            }
            // Se Armor >10 allora x0,90 | Se >20 allora x0,80 sul danno finale...

            //Genero un'arma e per ora l'arma che si andrà a sceglier edeterminaerà il numero di attacchi
            Console.WriteLine("Genera un'arma da usare:");
            Console.WriteLine("1) Fucile d'assalto ------> | 3 attacchi per turno | 10% probabilità effetto | 20% probabilità critico | +100% danno critico | 1 danno");
            Console.WriteLine("2) Pistola ---------------> | 2 attacchi per turno | 20% probabilità effetto | 20% probabilità critico | +100% danno critico | 2 danno");
            Console.WriteLine("3) Fucile a pompa --------> | 1 attacchi per turno | 50% probabilità effetto | 10% probabilità critico | +50% danno critico | 4 danno");
            Console.WriteLine("4) Fucile di precisione --> | 1 attacchi per turno | 30% probabilità effetto | 40% probabilità critico | +250% danno critico | 4 danno");

            int id_weapon = Convert.ToInt32(Console.ReadLine());

            switch (id_weapon)
            {
                case 1:
                    weapon.Add(new Weapons { BaseDamage = 1, CritDamage = 2, CritChance = 0.2, StatusChance = 0.1, Shot = 3 });
                    // Per attaccare devo sapere quale nemico e con quale arma
                    round.Attack(grineer, weapon);
                    break;
                case 2:
                    
                    weapon.Add(new Weapons { BaseDamage = 2, CritDamage = 2, CritChance = 0.2, StatusChance = 0.2, Shot = 2 });

                    break;
                case 3:

                    weapon.Add(new Weapons { BaseDamage = 4, CritDamage = 0.5, CritChance = 0.1, StatusChance = 0.5, Shot = 1 });
;
                    break;
                case 4:

                    weapon.Add(new Weapons { BaseDamage = 1, CritDamage = 2, CritChance = 0.2, StatusChance = 0.1, Shot = 1 });


                    break;
            }


            foreach (var gr in grineer)
            {
                Console.WriteLine(gr);
            }

            //wpn.Attack(grnr);

        }
    }
}
