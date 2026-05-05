namespace TMPP.Behavioral.Mediator;

// ConcreteColleague 1 - Receptia farmaciei
// Primeste retetele de la pacienti si notifica mediatorul
public class Receptie : DepartamentFarmacie
{
    public Receptie(IMediatorFarmacie mediator) : base(mediator, "Receptie") { }

    public void PrimesteReteta(string numePacient, string numeMedicament, bool necesitaPreparare)
    {
        Console.WriteLine($"    [Receptie] Reteta primita de la pacientul '{numePacient}' pentru '{numeMedicament}'.");

        string eveniment = necesitaPreparare ? "RetetaCuPreparare" : "RetetaStandard";
        Mediator.Notifica(this, eveniment, $"{numePacient}|{numeMedicament}");
    }

    public void NotificaPacient(string mesaj)
    {
        Console.WriteLine($"    [Receptie] Notificare pacient: {mesaj}");
    }
}

// ConcreteColleague 2 - Depozitul de medicamente
// Gestioneaza stocul si pregateste medicamentele
public class DepozitMediatorColleague : DepartamentFarmacie
{
    private readonly Dictionary<string, int> _stoc = new()
    {
        { "Paracetamol 500mg", 100 },
        { "Ibuprofen 400mg", 80 },
        { "Amoxicilina 500mg", 40 },
        { "Sirop Tuse Custom", 0 },
        { "Vitamina C 1000mg", 200 }
    };

    public DepozitMediatorColleague(IMediatorFarmacie mediator) : base(mediator, "Depozit") { }

    public bool VerificaStoc(string numeMedicament)
    {
        int stoc = _stoc.GetValueOrDefault(numeMedicament, 0);
        Console.WriteLine($"    [Depozit] Verificare stoc '{numeMedicament}': {stoc} bucati.");
        return stoc > 0;
    }

    public void PregatesteMedicament(string numeMedicament)
    {
        if (_stoc.ContainsKey(numeMedicament) && _stoc[numeMedicament] > 0)
        {
            _stoc[numeMedicament]--;
            Console.WriteLine($"    [Depozit] Medicament '{numeMedicament}' pregatit. Stoc ramas: {_stoc[numeMedicament]}.");
            Mediator.Notifica(this, "MedicamentPregatit", numeMedicament);
        }
        else
        {
            Console.WriteLine($"    [Depozit] ✗ Stoc insuficient pentru '{numeMedicament}'!");
            Mediator.Notifica(this, "StocInsuficient", numeMedicament);
        }
    }

    public void PrimesteDeLaLaborator(string numeMedicament)
    {
        _stoc[numeMedicament] = _stoc.GetValueOrDefault(numeMedicament, 0) + 1;
        Console.WriteLine($"    [Depozit] Primit de la laborator: '{numeMedicament}'. Stoc: {_stoc[numeMedicament]}.");
    }
}

// ConcreteColleague 3 - Laboratorul farmaciei
// Pregateste preparate magistrale (medicamente personalizate)
public class Laborator : DepartamentFarmacie
{
    public Laborator(IMediatorFarmacie mediator) : base(mediator, "Laborator") { }

    public void PreparaCompozitie(string numeMedicament)
    {
        Console.WriteLine($"    [Laborator] Incepere preparare compozitie pentru '{numeMedicament}'...");
        Console.WriteLine($"    [Laborator] Cantarire ingrediente... ✓");
        Console.WriteLine($"    [Laborator] Amestecare si procesare... ✓");
        Console.WriteLine($"    [Laborator] Control calitate... ✓");
        Console.WriteLine($"    [Laborator] Preparat '{numeMedicament}' finalizat!");
        Mediator.Notifica(this, "PreparatFinalizat", numeMedicament);
    }
}

// ConcreteColleague 4 - Casa de marcat
// Proceseaza plata pentru medicamente
public class CasaDeMarcat : DepartamentFarmacie
{
    private decimal _totalIncasari = 0;

    private readonly Dictionary<string, decimal> _preturi = new()
    {
        { "Paracetamol 500mg", 8.00m },
        { "Ibuprofen 400mg", 12.50m },
        { "Amoxicilina 500mg", 35.00m },
        { "Sirop Tuse Custom", 55.00m },
        { "Vitamina C 1000mg", 15.00m }
    };

    public CasaDeMarcat(IMediatorFarmacie mediator) : base(mediator, "CasaDeMarcat") { }

    public void ProceseazaPlata(string numeMedicament)
    {
        decimal pret = _preturi.GetValueOrDefault(numeMedicament, 25.00m);
        _totalIncasari += pret;
        Console.WriteLine($"    [CasaDeMarcat] Procesare plata pentru '{numeMedicament}': {pret:F2} RON");
        Console.WriteLine($"    [CasaDeMarcat] Total incasari: {_totalIncasari:F2} RON");
        Mediator.Notifica(this, "PlataFinalizata", numeMedicament);
    }
}
