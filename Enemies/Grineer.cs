namespace WEffects
{
    public class Grineer
    {
        public short id = 0;
        public double Health { get; set; }
        public double Armor { get; set; }
        public double Shield { get; set; }

        // Gli faccio un override string così quando stampo la lista in un foreach posso vedere i valori
        public override string ToString() 
        {
            
            return $"Grineer[{id++}]:{Health}, {Armor}, {Shield}";
        }
    }
}
