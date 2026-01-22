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

        //public void Damage(int id_weapon)
        //{
        //    if (id_weapon == 1)
        //    {
        //        BaseDamage = 1;
        //        CritDamage = 2;
        //        CritChance = 2;
        //        StatusChance = 1;
        //    }
        //    if (id_weapon == 2)
        //    {
        //        BaseDamage = 2;
        //        CritDamage = 2;
        //        CritChance = 2;
        //        StatusChance = 2;
        //    }
        //    if (id_weapon == 3)
        //    {
        //        BaseDamage = 4;
        //        CritDamage = 0.5;
        //        CritChance = 1;
        //        StatusChance = 5;
        //    }
        //    if (id_weapon == 4)
        //    {
        //        BaseDamage = 4;
        //        CritDamage = 3.5;
        //        CritChance = 4;
        //        StatusChance = 3;
        //    }
        //}
    }
}
