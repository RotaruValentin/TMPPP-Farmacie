namespace TMPP.Behavioral.Command;

// Receiver - Inventarul farmaciei care primeste si executa operatiunile reale
public class InventarFarmacie
{
    private readonly Dictionary<string, int> _stoc = new()
    {
        { "Paracetamol 500mg", 100 },
        { "Ibuprofen 400mg", 80 },
        { "Amoxicilina 500mg", 40 },
        { "Vitamina C 1000mg", 200 }
    };

    private readonly Dictionary<string, decimal> _preturi = new()
    {
        { "Paracetamol 500mg", 8.00m },
        { "Ibuprofen 400mg", 12.50m },
        { "Amoxicilina 500mg", 35.00m },
        { "Vitamina C 1000mg", 15.00m }
    };

    private decimal _totalIncasari = 0;

    public bool ElibereazaMedicament(string numeMedicament, int cantitate)
    {
        if (_stoc.ContainsKey(numeMedicament) && _stoc[numeMedicament] >= cantitate)
        {
            _stoc[numeMedicament] -= cantitate;
            decimal cost = _preturi[numeMedicament] * cantitate;
            _totalIncasari += cost;
            Console.WriteLine($"    [Inventar] Eliberat {cantitate}x '{numeMedicament}'. Stoc ramas: {_stoc[numeMedicament]}. Incasat: {cost:F2} RON");
            return true;
        }
        Console.WriteLine($"    [Inventar] EROARE: Nu se poate elibera '{numeMedicament}' (stoc insuficient).");
        return false;
    }

    public void ReturnareaMedicament(string numeMedicament, int cantitate)
    {
        if (_stoc.ContainsKey(numeMedicament))
        {
            _stoc[numeMedicament] += cantitate;
            decimal cost = _preturi[numeMedicament] * cantitate;
            _totalIncasari -= cost;
            Console.WriteLine($"    [Inventar] Returnat {cantitate}x '{numeMedicament}'. Stoc actualizat: {_stoc[numeMedicament]}. Restituit: {cost:F2} RON");
        }
    }

    public void AdaugaMedicament(string numeMedicament, int cantitate, decimal pret)
    {
        if (_stoc.ContainsKey(numeMedicament))
        {
            _stoc[numeMedicament] += cantitate;
        }
        else
        {
            _stoc[numeMedicament] = cantitate;
            _preturi[numeMedicament] = pret;
        }
        Console.WriteLine($"    [Inventar] Adaugat {cantitate}x '{numeMedicament}' la pret {pret:F2} RON. Stoc total: {_stoc[numeMedicament]}");
    }

    public void StergeAdaugare(string numeMedicament, int cantitate)
    {
        if (_stoc.ContainsKey(numeMedicament))
        {
            _stoc[numeMedicament] -= cantitate;
            if (_stoc[numeMedicament] <= 0)
            {
                _stoc.Remove(numeMedicament);
                _preturi.Remove(numeMedicament);
                Console.WriteLine($"    [Inventar] Eliminat complet '{numeMedicament}' din inventar.");
            }
            else
            {
                Console.WriteLine($"    [Inventar] Redus stocul '{numeMedicament}' cu {cantitate}. Stoc ramas: {_stoc[numeMedicament]}");
            }
        }
    }

    public void AfiseazaStare()
    {
        Console.WriteLine($"    [Inventar] --- Stare curenta (incasari totale: {_totalIncasari:F2} RON) ---");
        foreach (var item in _stoc)
        {
            Console.WriteLine($"    [Inventar]   {item.Key}: {item.Value} buc (pret: {_preturi[item.Key]:F2} RON)");
        }
    }
}
