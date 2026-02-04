namespace Enemies
{// Questa struct serve a generare stat randomici per le caratteristiche dei nemici (salute, armatura e scudi)
    public struct StatRange
    {
        public double Max;
        public double Min;
        //public int Roll(Random rnd) => rnd.Next(Min, Max + 1);
        public double Roll(Random rnd)
        {
            if (Min > Max)
                throw new InvalidOperationException("Min > Max");
            return Min + rnd.NextDouble() * (Max - Min);
        }
    }
}
