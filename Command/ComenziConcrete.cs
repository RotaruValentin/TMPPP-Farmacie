namespace TMPP.Behavioral.Command;

// ConcreteCommand 1 - Comanda de eliberare medicament
public class ComandaEliberare : IComandaFarmacie
{
    private readonly InventarFarmacie _inventar;
    private readonly string _numeMedicament;
    private readonly int _cantitate;
    private bool _executataCuSucces;

    public string Descriere => $"Eliberare {_cantitate}x '{_numeMedicament}'";

    public ComandaEliberare(InventarFarmacie inventar, string numeMedicament, int cantitate)
    {
        _inventar = inventar;
        _numeMedicament = numeMedicament;
        _cantitate = cantitate;
    }

    public void Executa()
    {
        Console.WriteLine($"  [Comanda] Executare: {Descriere}");
        _executataCuSucces = _inventar.ElibereazaMedicament(_numeMedicament, _cantitate);
    }

    public void Anuleaza()
    {
        if (_executataCuSucces)
        {
            Console.WriteLine($"  [Comanda] UNDO: {Descriere}");
            _inventar.ReturnareaMedicament(_numeMedicament, _cantitate);
            _executataCuSucces = false;
        }
        else
        {
            Console.WriteLine($"  [Comanda] UNDO ignorat: comanda nu a fost executata cu succes.");
        }
    }
}

// ConcreteCommand 2 - Comanda de adaugare medicament nou in inventar
public class ComandaAdaugare : IComandaFarmacie
{
    private readonly InventarFarmacie _inventar;
    private readonly string _numeMedicament;
    private readonly int _cantitate;
    private readonly decimal _pret;

    public string Descriere => $"Adaugare {_cantitate}x '{_numeMedicament}' (pret: {_pret:F2} RON)";

    public ComandaAdaugare(InventarFarmacie inventar, string numeMedicament, int cantitate, decimal pret)
    {
        _inventar = inventar;
        _numeMedicament = numeMedicament;
        _cantitate = cantitate;
        _pret = pret;
    }

    public void Executa()
    {
        Console.WriteLine($"  [Comanda] Executare: {Descriere}");
        _inventar.AdaugaMedicament(_numeMedicament, _cantitate, _pret);
    }

    public void Anuleaza()
    {
        Console.WriteLine($"  [Comanda] UNDO: {Descriere}");
        _inventar.StergeAdaugare(_numeMedicament, _cantitate);
    }
}
