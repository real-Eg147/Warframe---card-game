namespace WEffects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Grineer> grnr = new List<Grineer>();
            Round wpn = new Round();
            Weapons damage = new Weapons();

            // Genero l'avversario
            Console.WriteLine("Genera avversario:");
            Console.WriteLine("1) Grineer");
            Console.WriteLine("2) Corpus");
            Console.WriteLine("3) Infested");
            int selectEnemy = Convert.ToInt32(Console.ReadLine());


            switch (selectEnemy)
            {
                case 1:
                        grnr.Add(new Grineer { id = 0, Health = 20, Armor = 25, Shield = 0 });
                    break;
                case 2:
                    break;
                case 3:
                    break;
                
            }
            // Se Armor >10 allora x0,90 | Se >20 allora x0,80 sul danno finale...

            //Genero un'arma
            Console.WriteLine("Genera un'arma da usare:");
            Console.WriteLine("1) Fucile d'assalto ------> | 3 attacchi per turno | 10% probabilità effetto | 20% probabilità critico | +100% danno critico | 1 danno");
            Console.WriteLine("2) Pistola ---------------> | 2 attacchi per turno | 20% probabilità effetto | 20% probabilità critico | +100% danno critico | 2 danno");
            Console.WriteLine("3) Fucile a pompa --------> | 1 attacchi per turno | 50% probabilità effetto | 10% probabilità critico | +50% danno critico | 4 danno");
            Console.WriteLine("4) Fucile di precisione --> | 1 attacchi per turno | 30% probabilità effetto | 40% probabilità critico | +250% danno critico | 4 danno");
            int id_weapon = Convert.ToInt32(Console.ReadLine());

            switch (id_weapon)
            {
                case 1:
                    short counter = 0;
                    while (counter != 3)
                    {
                        damage.Damage(id_weapon);
                        wpn.Attack(grnr);
                        counter++;
                    }
                    break;
                case 2:
                    counter = 0;
                    while (counter != 2)
                    {
                        wpn.Attack(grnr);
                        counter++;
                    }
                    break;
                case 3:
                    counter = 0;
                    while (counter != 1)
                    {
                        wpn.Attack(grnr);
                        counter++;
                    }
                    break;
                case 4:
                    counter = 0;
                    while (counter != 1)
                    {
                        wpn.Attack(grnr);
                        counter++;
                    }
                    break;
            }


            foreach (Grineer gr in grnr)
            {
                Console.WriteLine(gr);
            }

            //wpn.Attack(grnr);

        }
    }
}
