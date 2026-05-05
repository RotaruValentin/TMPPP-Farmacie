namespace TMPP.Behavioral.Iterator;

// Iterator - interfata pentru parcurgerea colectiei de medicamente
// Defineste contractul standard de iterare: HasNext + Next + Reset
public interface IMedicamentIterator
{
    string NumeIterator { get; }
    bool AreUrmator();
    MedicamentItem Urmator();
    void Reseteaza();
}
