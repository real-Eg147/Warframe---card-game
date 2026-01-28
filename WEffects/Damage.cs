namespace WEffects
{
    public class Damage : Elements
    {
        // Ogni arma ha il suo [DANNO BASE] [DANNO CRITICO] [DANNO EFFETTO] [PROBABILITA' DI CRITICO] [PROBABILITA' EFFETTO] 
        public int id { get; set; }
        public double BaseDamage { get; set; }
        public double CritDamage { get; set; }
        public double StatusDamage { get; set; }
        public double StatusChance { get; set; }
        public double CritChance { get; set; }
        public short Shot { get; set; }

        
    }
}
