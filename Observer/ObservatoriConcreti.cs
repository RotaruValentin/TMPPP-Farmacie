namespace TMPP.Behavioral.Observer;

// ConcreteObserver 1 - Farmacistul este notificat cand stocul scade sub minim
public class FarmacistObservator : IObservatorStoc
{
    public string Nume { get; }
    private readonly int _pragMinim;

    public FarmacistObservator(string nume, int pragMinim = 10)
    {
        Nume = nume;
        _pragMinim = pragMinim;
    }

    public void Actualizeaza(string numeMedicament, int stocVechi, int stocNou, string tipEveniment)
    {
        if (stocNou < _pragMinim)
        {
            Console.WriteLine($"    [Farmacist {Nume}] ⚠ ALERTA STOC CRITIC: '{numeMedicament}' are doar {stocNou} unitati (minim: {_pragMinim})! Necesita comanda urgenta.");
        }
        else
        {
            Console.WriteLine($"    [Farmacist {Nume}] Notificare: '{numeMedicament}' - {tipEveniment} (stoc: {stocVechi} -> {stocNou})");
        }
    }
}

// ConcreteObserver 2 - Furnizorul este notificat automat cand stocul scade sub prag
// pentru a pregati o noua livrare
public class FurnizorObservator : IObservatorStoc
{
    public string Nume { get; }
    private readonly int _pragReaprovizionare;

    public FurnizorObservator(string nume, int pragReaprovizionare = 20)
    {
        Nume = nume;
        _pragReaprovizionare = pragReaprovizionare;
    }

    public void Actualizeaza(string numeMedicament, int stocVechi, int stocNou, string tipEveniment)
    {
        if (stocNou < _pragReaprovizionare && tipEveniment == "Vanzare")
        {
            int cantitateRecomandata = _pragReaprovizionare * 3;
            Console.WriteLine($"    [Furnizor {Nume}] Comanda automata generata: {cantitateRecomandata}x '{numeMedicament}' (stoc actual: {stocNou}, prag: {_pragReaprovizionare})");
        }
        else
        {
            Console.WriteLine($"    [Furnizor {Nume}] Inregistrat: '{numeMedicament}' - {tipEveniment} (stoc: {stocNou})");
        }
    }
}

// ConcreteObserver 3 - Sistemul de raportare inregistreaza toate miscarile de stoc
public class RaportareObservator : IObservatorStoc
{
    public string Nume => "SistemRaportare";
    private readonly List<string> _logMiscari = new();

    public void Actualizeaza(string numeMedicament, int stocVechi, int stocNou, string tipEveniment)
    {
        string inregistrare = $"[{DateTime.Now:HH:mm:ss}] {tipEveniment}: '{numeMedicament}' stoc {stocVechi} -> {stocNou} (delta: {stocNou - stocVechi:+#;-#;0})";
        _logMiscari.Add(inregistrare);
        Console.WriteLine($"    [Raportare] Log: {inregistrare}");
    }

    public void AfiseazaRaport()
    {
        Console.WriteLine($"\n    [Raportare] === Raport miscari stoc ({_logMiscari.Count} inregistrari) ===");
        foreach (var entry in _logMiscari)
        {
            Console.WriteLine($"    {entry}");
        }
    }
}
