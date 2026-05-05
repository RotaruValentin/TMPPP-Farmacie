namespace TMPP.Behavioral.ChainOfResponsibility;

// ConcreteHandler 1 - Verificarea datelor pacientului
// Asigura ca numele si varsta sunt valide
public class ValidatorDatePacient : ValidatorReteta
{
    public ValidatorDatePacient() : base("Validator Date Pacient") { }

    protected override bool ExecutaValidare(CerereEliberare cerere)
    {
        if (string.IsNullOrWhiteSpace(cerere.NumePacient))
        {
            cerere.Erori.Add("Numele pacientului lipseste.");
            return false;
        }

        if (cerere.VarstaPacient <= 0 || cerere.VarstaPacient > 120)
        {
            cerere.Erori.Add($"Varsta pacientului este invalida: {cerere.VarstaPacient}.");
            return false;
        }

        Console.WriteLine($"      Pacient: {cerere.NumePacient}, varsta: {cerere.VarstaPacient} ani - date complete.");
        return true;
    }
}

// ConcreteHandler 2 - Verificarea ca medicamentul exista in baza de date
public class ValidatorMedicamentValid : ValidatorReteta
{
    private readonly HashSet<string> _medicamenteValide = new()
    {
        "Paracetamol 500mg", "Ibuprofen 400mg", "Amoxicilina 500mg",
        "Azitromicina 250mg", "Vitamina C 1000mg", "Morfina 10mg",
        "Diazepam 5mg", "Insulina NovoRapid", "Metformin 850mg"
    };

    public ValidatorMedicamentValid() : base("Validator Medicament") { }

    protected override bool ExecutaValidare(CerereEliberare cerere)
    {
        if (string.IsNullOrWhiteSpace(cerere.NumeMedicament))
        {
            cerere.Erori.Add("Numele medicamentului lipseste.");
            return false;
        }

        if (!_medicamenteValide.Contains(cerere.NumeMedicament))
        {
            cerere.Erori.Add($"Medicamentul '{cerere.NumeMedicament}' nu exista in baza de date.");
            return false;
        }

        Console.WriteLine($"      Medicament '{cerere.NumeMedicament}' - gasit in baza de date.");
        return true;
    }
}

// ConcreteHandler 3 - Verificarea interactiunilor medicamentoase periculoase
public class ValidatorInteractiuni : ValidatorReteta
{
    // Perechi de medicamente care nu pot fi administrate simultan
    private readonly Dictionary<string, List<string>> _interactiuniPericuloase = new()
    {
        { "Ibuprofen 400mg", new List<string> { "Metformin 850mg", "Diazepam 5mg" } },
        { "Morfina 10mg", new List<string> { "Diazepam 5mg", "Amoxicilina 500mg" } },
        { "Azitromicina 250mg", new List<string> { "Amoxicilina 500mg" } }
    };

    public ValidatorInteractiuni() : base("Validator Interactiuni") { }

    protected override bool ExecutaValidare(CerereEliberare cerere)
    {
        if (!_interactiuniPericuloase.ContainsKey(cerere.NumeMedicament))
        {
            Console.WriteLine($"      Nicio interactiune cunoscuta pentru '{cerere.NumeMedicament}'.");
            return true;
        }

        var interactiuni = _interactiuniPericuloase[cerere.NumeMedicament];
        foreach (var medicamentActual in cerere.MedicamenteActuale)
        {
            if (interactiuni.Contains(medicamentActual))
            {
                cerere.Erori.Add($"Interactiune periculoasa: '{cerere.NumeMedicament}' + '{medicamentActual}' nu pot fi administrate simultan!");
                return false;
            }
        }

        Console.WriteLine($"      Verificate {cerere.MedicamenteActuale.Count} medicamente actuale - fara interactiuni periculoase.");
        return true;
    }
}

// ConcreteHandler 4 - Verificarea stocului disponibil
public class ValidatorStoc : ValidatorReteta
{
    private readonly Dictionary<string, int> _stocDisponibil = new()
    {
        { "Paracetamol 500mg", 200 },
        { "Ibuprofen 400mg", 150 },
        { "Amoxicilina 500mg", 5 },
        { "Azitromicina 250mg", 30 },
        { "Vitamina C 1000mg", 300 },
        { "Morfina 10mg", 10 },
        { "Diazepam 5mg", 20 },
        { "Insulina NovoRapid", 0 },
        { "Metformin 850mg", 100 }
    };

    public ValidatorStoc() : base("Validator Stoc") { }

    protected override bool ExecutaValidare(CerereEliberare cerere)
    {
        int stoc = _stocDisponibil.GetValueOrDefault(cerere.NumeMedicament, 0);

        if (stoc < cerere.Cantitate)
        {
            cerere.Erori.Add($"Stoc insuficient pentru '{cerere.NumeMedicament}': disponibil {stoc}, cerut {cerere.Cantitate}.");
            return false;
        }

        Console.WriteLine($"      Stoc '{cerere.NumeMedicament}': {stoc} disponibil, {cerere.Cantitate} cerut - OK.");
        return true;
    }
}

// ConcreteHandler 5 - Aprobarea finala de catre farmacist
// Verifica daca medicamentul necesita reteta si daca aceasta exista
public class ValidatorFarmacist : ValidatorReteta
{
    private readonly HashSet<string> _necesitaReteta = new()
    {
        "Amoxicilina 500mg", "Azitromicina 250mg", "Morfina 10mg",
        "Diazepam 5mg", "Insulina NovoRapid", "Metformin 850mg"
    };

    public ValidatorFarmacist() : base("Validator Farmacist (Aprobare Finala)") { }

    protected override bool ExecutaValidare(CerereEliberare cerere)
    {
        if (_necesitaReteta.Contains(cerere.NumeMedicament) && !cerere.AreReteta)
        {
            cerere.Erori.Add($"Medicamentul '{cerere.NumeMedicament}' necesita reteta medicala, dar aceasta lipseste.");
            return false;
        }

        string tipEliberare = _necesitaReteta.Contains(cerere.NumeMedicament) ? "cu reteta" : "OTC (fara reteta)";
        Console.WriteLine($"      Aprobare farmacist: eliberare {tipEliberare} - APROBAT.");
        return true;
    }
}
