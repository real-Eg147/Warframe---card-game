using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WEffects
{
    // Aggiungi 'abstract' così puoi creare Grineer, Corpus ecc.
    public abstract class Factions : INotifyPropertyChanged
    {
        public short Id { get; set; } // Serve per identificare il nemico
        private double _health;
        private double _shield;
        private double _armor;
        private double _maxHealth;
        private double _maxShield;
        private double _maxArmor;

        public double Health
        {
            get => _health;
            set { _health = value; OnPropertyChanged(); }
        }
        public double Shield
        {
            get => _shield;
            set { _shield = value; OnPropertyChanged(); }
        }
        public double Armor
        {
            get => _armor;
            set { _armor = value; OnPropertyChanged(); }
        }
        public double MaxHealth
        {
            get => _maxHealth;
            set { _maxHealth = value; OnPropertyChanged(); }
        }

        public double MaxShield
        {
            get => _maxShield;
            set { _maxShield = value; OnPropertyChanged(); }
        }

        public double MaxArmor
        {
            get => _maxArmor;
            set { _maxArmor = value; OnPropertyChanged(); }
        }

        protected Factions(short id) { Id = id; }
        // Proprietà astratta per il nome (Grineer, ecc.)
        public abstract string Nome { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // Override di ToString per la visualizzazione nei log
        public override string ToString()
        {
            return $"{Nome} [{Id}] - HP:{Health:F1} ARM:{Armor:F2} SH:{Shield:F1}";
        }
    }
}