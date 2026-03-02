using Enemies;
using System.Windows;
using System.Windows.Controls;
using WEffects;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Factions currentEnemy;
        private Weapon currentWeapon = new Weapon { BaseDamage = 10, CritChance = 20, CritDamage = 2.0, Shot = 3 };
        private Random rng = new Random();

        public MainWindow() => InitializeComponent();

        private void SpawnGrineer_Click(object sender, RoutedEventArgs e)
        {
            currentEnemy = new Grineer(1, rng);
            EnemyNameTxt.Text = $"Nemico: {currentEnemy.Nome}";

            // Impostiamo i massimali delle barre
            HealthBar.Maximum = currentEnemy.Health;
            ShieldBar.Maximum = currentEnemy.Shield > 0 ? currentEnemy.Shield : 100;
            ArmorBar.Maximum = currentEnemy.Armor > 0 ? currentEnemy.Armor : 1;

            UpdateUI();
        }
        private void SpawnCorpus_Click(object sender, RoutedEventArgs e)
        {
            currentEnemy = new Corpus(1, rng);
            EnemyNameTxt.Text = $"Nemico: {currentEnemy.Nome}";

            // Impostiamo i massimali delle barre
            HealthBar.Maximum = currentEnemy.Health;
            ShieldBar.Maximum = currentEnemy.Shield > 0 ? currentEnemy.Shield : 100;

            UpdateUI();
        }
        private void SpawnInfested_Click(object sender, RoutedEventArgs e)
        {
            currentEnemy = new Infested(1, rng);
            EnemyNameTxt.Text = $"Nemico: {currentEnemy.Nome}";

            // Impostiamo i massimali delle barre
            HealthBar.Maximum = currentEnemy.Health;
            ShieldBar.Maximum = currentEnemy.Shield > 0 ? currentEnemy.Shield : 100;

            UpdateUI();
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            if (currentEnemy == null) return;

            // Eseguiamo la tua logica esistente
            currentWeapon.CalculateDamage(new List<Factions> { currentEnemy });

            UpdateUI();
            LogTxt.Text += $"Sferrato attacco {currentWeapon.BaseDamage}! HP rimanenti: {currentEnemy.Health:F1}\n";
        }
        private void WeaponCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // L'indice 0 è il primo elemento della lista nella ComboBox
            int index = WeaponCombo.SelectedIndex;

            // Se l'indice è -1 significa che non è selezionato nulla (evitiamo errori)
            if (index == -1) return;

            if (index == 0) // Fucile d'assalto
            {
                currentWeapon = new Weapon { BaseDamage = 6, CritDamage = 2, CritChance = 20, StatusChance = 50, Status = 8, Shot = 4 };
            }
            else if (index == 1) // Pistola
            {
                currentWeapon = new Weapon { BaseDamage = 10, CritDamage = 1.5, CritChance = 25, StatusChance = 60, Status = 2, Shot = 3 };
            }
            else if (index == 2) // Fucile a pompa
            {
                currentWeapon = new Weapon { BaseDamage = 14, CritDamage = 3, CritChance = 7, StatusChance = 15, Status = 3, Shot = 2 };
            }
            else if (index == 3) // Fucile di precisione
            {
                currentWeapon = new Weapon { BaseDamage = 20, CritDamage = 3.5, CritChance = 15, StatusChance = 25, Status = 1, Shot = 1 };
            }
        }
        private void UpdateUI()
        {
            if (currentEnemy == null) return;

            // Salute
            HealthBar.Maximum = currentEnemy.MaxHealth;
            HealthBar.Value = currentEnemy.Health;

            // Scudi
            ShieldBar.Maximum = currentEnemy.MaxShield > 0 ? currentEnemy.MaxShield : 1;
            ShieldBar.Value = currentEnemy.Shield;
            ShieldBar.Visibility = currentEnemy.MaxShield > 0 ? Visibility.Visible : Visibility.Collapsed;

            // ARMATURA (Logica corretta per valori 0.0 - 1.0)
            // Se MaxArmor è 1.0 e Armor è 0.5, la barra sarà piena a metà.
            ArmorBar.Maximum = 1.0;
            ArmorBar.Value = currentEnemy.Armor;
            double percentualeArmor = currentEnemy.Armor * 100;
            ArmorText.Text = $"Armatura: {percentualeArmor:F0}%";

            // Mostra la barra solo se l'armatura è effettivamente sopra lo zero
            ArmorBar.Visibility = currentEnemy.Armor > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}