namespace WEffects
{
    public abstract class Factions
    {
        public short Id { get; }
        private static short _nextId = 1;
        public double Health { get; set; }
        public double Armor { get; set; }
        public double Shield { get; set; }

        protected Factions(short id)
        {
            Id = Id;
        }

        public abstract string Nome { get; }

        public override string ToString()
        {
            return $"{Nome}[{Id}] - HP:{Health.ToString("F1")} ARM:{Armor.ToString("F1")} SH:{Shield.ToString("F1")}";
        }
    }
}
