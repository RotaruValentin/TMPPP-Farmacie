namespace TMPP.Behavioral.Memento;

// Caretaker - Gestioneaza istoricul de Memento-uri ale retetei.
// Nu acceseaza si nu modifica continutul Memento-urilor; doar le stocheaza.
public class IstoricRetete
{
    private readonly Stack<RetetaMemento> _versiuni = new();

    public void SalveazaVersiune(RetetaMemento memento)
    {
        _versiuni.Push(memento);
        Console.WriteLine($"  [Istoric] Versiune salvata. Total versiuni: {_versiuni.Count}");
    }

    public RetetaMemento? RestaureareaUltimaVersiune()
    {
        if (_versiuni.Count > 0)
        {
            var memento = _versiuni.Pop();
            Console.WriteLine($"  [Istoric] Restaurare versiune din {memento.DataSalvare:HH:mm:ss}. Versiuni ramase: {_versiuni.Count}");
            return memento;
        }

        Console.WriteLine("  [Istoric] Nu exista versiuni anterioare de restaurat.");
        return null;
    }

    public void AfiseazaVersiuni()
    {
        Console.WriteLine($"\n  [Istoric] === Versiuni salvate ({_versiuni.Count}) ===");
        int index = 1;
        foreach (var memento in _versiuni)
        {
            Console.WriteLine($"    {index}. {memento}");
            index++;
        }
    }
}
