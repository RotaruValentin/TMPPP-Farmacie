namespace TMPP.Behavioral.Observer;

// Subject - Depozitul de medicamente care notifica observatorii la modificari de stoc.
// Gestioneaza lista de observatori si emite notificari automate.
public class DepozitMedicamenteSubject
{
    private readonly Dictionary<string, int> _stoc = new();
    private readonly List<IObservatorStoc> _observatori = new();

    public DepozitMedicamenteSubject()
    {
        // Initializare stoc initial
        _stoc["Paracetamol 500mg"] = 50;
        _stoc["Ibuprofen 400mg"] = 30;
        _stoc["Amoxicilina 500mg"] = 15;
        _stoc["Insulina NovoRapid"] = 8;
    }

    // Abonare observator
    public void Aboneaza(IObservatorStoc observator)
    {
        _observatori.Add(observator);
        Console.WriteLine($"  [Depozit] Observator abonat: {observator.Nume}");
    }

    // Dezabonare observator
    public void Dezaboneaza(IObservatorStoc observator)
    {
        _observatori.Remove(observator);
        Console.WriteLine($"  [Depozit] Observator dezabonat: {observator.Nume}");
    }

    // Notifica toti observatorii despre o schimbare de stoc
    private void NotificaObservatori(string numeMedicament, int stocVechi, int stocNou, string tipEveniment)
    {
        Console.WriteLine($"  [Depozit] Notificare {_observatori.Count} observatori despre: {tipEveniment} '{numeMedicament}'");
        foreach (var observator in _observatori)
        {
            observator.Actualizeaza(numeMedicament, stocVechi, stocNou, tipEveniment);
        }
    }

    // Operatiune de vanzare - scade stocul si notifica
    public void VindeMedicament(string numeMedicament, int cantitate)
    {
        if (!_stoc.ContainsKey(numeMedicament))
        {
            Console.WriteLine($"  [Depozit] EROARE: '{numeMedicament}' nu exista in depozit.");
            return;
        }

        int stocVechi = _stoc[numeMedicament];
        if (stocVechi < cantitate)
        {
            Console.WriteLine($"  [Depozit] EROARE: Stoc insuficient pentru '{numeMedicament}'. Disponibil: {stocVechi}, Cerut: {cantitate}");
            return;
        }

        _stoc[numeMedicament] -= cantitate;
        Console.WriteLine($"  [Depozit] Vandut {cantitate}x '{numeMedicament}' (stoc: {stocVechi} -> {_stoc[numeMedicament]})");
        NotificaObservatori(numeMedicament, stocVechi, _stoc[numeMedicament], "Vanzare");
    }

    // Operatiune de aprovizionare - creste stocul si notifica
    public void AprovizionareaMedicament(string numeMedicament, int cantitate)
    {
        int stocVechi = _stoc.ContainsKey(numeMedicament) ? _stoc[numeMedicament] : 0;
        _stoc[numeMedicament] = stocVechi + cantitate;
        Console.WriteLine($"  [Depozit] Aprovizionat {cantitate}x '{numeMedicament}' (stoc: {stocVechi} -> {_stoc[numeMedicament]})");
        NotificaObservatori(numeMedicament, stocVechi, _stoc[numeMedicament], "Aprovizionare");
    }
}
