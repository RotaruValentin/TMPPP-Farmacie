namespace TMPP.Behavioral.Iterator;

// Aggregate (Colectie) - Catalogul farmaciei care poate crea diferiti iteratori.
// Ofera mai multe moduri de parcurgere a aceleasi colectii de medicamente.
public class CatalogFarmacie
{
    private readonly List<MedicamentItem> _medicamente = new();

    public void AdaugaMedicament(MedicamentItem medicament)
    {
        _medicamente.Add(medicament);
    }

    public int TotalMedicamente => _medicamente.Count;

    // Factory methods pentru diferiti iteratori
    public IMedicamentIterator CreazaIteratorSecvential()
    {
        return new IteratorSecvential(_medicamente);
    }

    public IMedicamentIterator CreazaIteratorCategorie(string categorie)
    {
        return new IteratorCategorie(_medicamente, categorie);
    }

    public IMedicamentIterator CreazaIteratorCuReteta()
    {
        return new IteratorCuReteta(_medicamente);
    }

    public IMedicamentIterator CreazaIteratorPretCrescator()
    {
        return new IteratorPretCrescator(_medicamente);
    }
}
