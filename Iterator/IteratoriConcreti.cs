namespace TMPP.Behavioral.Iterator;

// ConcreteIterator 1 - Itereaza toate medicamentele in ordine normala
public class IteratorSecvential : IMedicamentIterator
{
    private readonly List<MedicamentItem> _medicamente;
    private int _pozitie = 0;

    public string NumeIterator => "Secvential (toate medicamentele)";

    public IteratorSecvential(List<MedicamentItem> medicamente)
    {
        _medicamente = medicamente;
    }

    public bool AreUrmator() => _pozitie < _medicamente.Count;

    public MedicamentItem Urmator()
    {
        if (!AreUrmator())
            throw new InvalidOperationException("Nu mai exista elemente de parcurs.");
        return _medicamente[_pozitie++];
    }

    public void Reseteaza() => _pozitie = 0;
}

// ConcreteIterator 2 - Itereaza doar medicamentele dintr-o anumita categorie
public class IteratorCategorie : IMedicamentIterator
{
    private readonly List<MedicamentItem> _medicamenteCategorie;
    private int _pozitie = 0;
    private readonly string _categorie;

    public string NumeIterator => $"Filtrat pe categorie: '{_categorie}'";

    public IteratorCategorie(List<MedicamentItem> medicamente, string categorie)
    {
        _categorie = categorie;
        // Filtram la creare pentru eficienta
        _medicamenteCategorie = medicamente
            .Where(m => m.Categorie.Equals(categorie, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public bool AreUrmator() => _pozitie < _medicamenteCategorie.Count;

    public MedicamentItem Urmator()
    {
        if (!AreUrmator())
            throw new InvalidOperationException("Nu mai exista elemente in aceasta categorie.");
        return _medicamenteCategorie[_pozitie++];
    }

    public void Reseteaza() => _pozitie = 0;
}

// ConcreteIterator 3 - Itereaza doar medicamentele care necesita reteta
public class IteratorCuReteta : IMedicamentIterator
{
    private readonly List<MedicamentItem> _medicamenteCuReteta;
    private int _pozitie = 0;

    public string NumeIterator => "Filtrat: doar medicamente cu reteta";

    public IteratorCuReteta(List<MedicamentItem> medicamente)
    {
        _medicamenteCuReteta = medicamente.Where(m => m.NecesitaReteta).ToList();
    }

    public bool AreUrmator() => _pozitie < _medicamenteCuReteta.Count;

    public MedicamentItem Urmator()
    {
        if (!AreUrmator())
            throw new InvalidOperationException("Nu mai exista medicamente cu reteta.");
        return _medicamenteCuReteta[_pozitie++];
    }

    public void Reseteaza() => _pozitie = 0;
}

// ConcreteIterator 4 - Itereaza medicamentele sortate dupa pret (crescator)
public class IteratorPretCrescator : IMedicamentIterator
{
    private readonly List<MedicamentItem> _medicamenteSortate;
    private int _pozitie = 0;

    public string NumeIterator => "Sortat dupa pret (crescator)";

    public IteratorPretCrescator(List<MedicamentItem> medicamente)
    {
        _medicamenteSortate = medicamente.OrderBy(m => m.Pret).ToList();
    }

    public bool AreUrmator() => _pozitie < _medicamenteSortate.Count;

    public MedicamentItem Urmator()
    {
        if (!AreUrmator())
            throw new InvalidOperationException("Nu mai exista elemente de parcurs.");
        return _medicamenteSortate[_pozitie++];
    }

    public void Reseteaza() => _pozitie = 0;
}
