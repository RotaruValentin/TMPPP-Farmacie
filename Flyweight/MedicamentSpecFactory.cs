namespace TMPP.Structural.Flyweight;

// Flyweight Factory - gestioneaza si partajeaza instantele MedicamentSpec.
// Daca un MedicamentSpec cu aceeasi cheie exista deja, il returneaza pe cel existent
// in loc sa creeze unul nou => economie de memorie.
public class MedicamentSpecFactory
{
    private readonly Dictionary<string, MedicamentSpec> _specs = new();

    public MedicamentSpec GetSpec(string nume, string substantaActiva, string categorie, string efecteSecundare)
    {
        string key = nume.ToLower();

        if (!_specs.ContainsKey(key))
        {
            _specs[key] = new MedicamentSpec(nume, substantaActiva, categorie, efecteSecundare);
            Console.WriteLine($"  [Factory] Creat spec NOU pentru '{nume}' (obiect unic in memorie)");
        }
        else
        {
            Console.WriteLine($"  [Factory] Reutilizat spec EXISTENT pentru '{nume}' (partajat)");
        }

        return _specs[key];
    }

    public int GetTotalSpecsCreate() => _specs.Count;
}
