namespace TMPP.Behavioral.ChainOfResponsibility;

// Datele unei cereri de eliberare medicament pe baza de reteta
public class CerereEliberare
{
    public string NumePacient { get; set; }
    public int VarstaPacient { get; set; }
    public string NumeMedicament { get; set; }
    public int Cantitate { get; set; }
    public bool AreReteta { get; set; }
    public List<string> MedicamenteActuale { get; set; } // medicamente pe care pacientul le ia deja
    public List<string> Erori { get; set; } = new();

    public CerereEliberare(string numePacient, int varstaPacient, string numeMedicament, int cantitate,
        bool areReteta, List<string>? medicamenteActuale = null)
    {
        NumePacient = numePacient;
        VarstaPacient = varstaPacient;
        NumeMedicament = numeMedicament;
        Cantitate = cantitate;
        AreReteta = areReteta;
        MedicamenteActuale = medicamenteActuale ?? new List<string>();
    }

    public override string ToString() =>
        $"Cerere: '{NumeMedicament}' x{Cantitate} pentru {NumePacient} (varsta: {VarstaPacient})";
}

// Handler abstract - Chain of Responsibility
// Fiecare validator proceseaza cererea sau o paseaza urmatorului din lant
public abstract class ValidatorReteta
{
    private ValidatorReteta? _urmatorulValidator;
    public string NumeValidator { get; protected set; }

    protected ValidatorReteta(string numeValidator)
    {
        NumeValidator = numeValidator;
    }

    // Seteaza urmatorul handler din lant si returneaza referinta la el (fluent API)
    public ValidatorReteta SeteazaUrmator(ValidatorReteta urmator)
    {
        _urmatorulValidator = urmator;
        return urmator;
    }

    // Metoda template care proceseaza cererea si o paseaza mai departe daca e valida
    public bool Valideaza(CerereEliberare cerere)
    {
        Console.WriteLine($"    [{NumeValidator}] Verificare in curs...");

        if (!ExecutaValidare(cerere))
        {
            Console.WriteLine($"    [{NumeValidator}] ✗ RESPINS: {cerere.Erori[^1]}");
            return false;
        }

        Console.WriteLine($"    [{NumeValidator}] ✓ Validare trecuta.");

        // Daca exista un urmator validator, continua lantul
        if (_urmatorulValidator != null)
        {
            return _urmatorulValidator.Valideaza(cerere);
        }

        // Sfarsitul lantului - cererea a trecut toate validarile
        return true;
    }

    // Metoda abstracta implementata de fiecare validator concret
    protected abstract bool ExecutaValidare(CerereEliberare cerere);
}
