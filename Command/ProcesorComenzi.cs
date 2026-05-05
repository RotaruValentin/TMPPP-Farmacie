namespace TMPP.Behavioral.Command;

// Invoker - Procesorul de comenzi care pastreaza istoricul si permite Undo.
// Actioneaza ca un controller care decupleaza emiterea comenzilor de executia lor.
public class ProcesorComenzi
{
    private readonly Stack<IComandaFarmacie> _istoric = new();

    public void ExecutaComanda(IComandaFarmacie comanda)
    {
        comanda.Executa();
        _istoric.Push(comanda);
        Console.WriteLine($"  [Procesor] Comanda adaugata in istoric. Total comenzi: {_istoric.Count}");
    }

    public void AnuleazaUltimaComanda()
    {
        if (_istoric.Count > 0)
        {
            var comanda = _istoric.Pop();
            Console.WriteLine($"  [Procesor] Anulare ultima comanda: {comanda.Descriere}");
            comanda.Anuleaza();
        }
        else
        {
            Console.WriteLine("  [Procesor] Nu exista comenzi de anulat.");
        }
    }

    public void AfiseazaIstoric()
    {
        Console.WriteLine($"\n  [Procesor] === Istoric comenzi ({_istoric.Count} ramase) ===");
        int index = 1;
        foreach (var comanda in _istoric)
        {
            Console.WriteLine($"    {index}. {comanda.Descriere}");
            index++;
        }
    }
}
