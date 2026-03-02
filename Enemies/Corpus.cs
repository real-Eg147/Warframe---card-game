using Enemies;
using WEffects;

public class Corpus : Factions
{
    private static readonly StatRange HealthRange = new() { Min = 20.0, Max = 30.0 };
    private static readonly StatRange ShieldRange = new() { Min = 5.0, Max = 100.0 };

    public Corpus(short id, Random rnd) : base(id)
    {
        // Generiamo il valore e lo salviamo come MASSIMO e ATTUALE
        double rolledHealth = HealthRange.Roll(rnd);
        Health = rolledHealth;
        MaxHealth = rolledHealth;

        double rolledShield = ShieldRange.Roll(rnd);
        Shield = rolledShield;
        MaxShield = rolledShield;

        Armor = 0; // I Corpus solitamente non hanno armatura base
    }

    public override string Nome => "Corpus";
}