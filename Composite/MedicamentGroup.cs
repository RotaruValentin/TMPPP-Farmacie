using System;
using System.Collections.Generic;
using System.Linq;

namespace TMPP.Structural.Composite;

// Composite - reprezinta un grup de medicamente (poate contine atat Leaf-uri cat si alte Composite-uri)
public class MedicamentGroup : IMedicamentComponent
{
    private readonly List<IMedicamentComponent> _components = [];

    public string Name { get; }

    // Pretul grupului este suma preturilor tuturor componentelor
    public decimal Price => _components.Sum(c => c.Price);

    public MedicamentGroup(string name)
    {
        Name = name;
    }

    public void Add(IMedicamentComponent component)
    {
        _components.Add(component);
    }

    public void Remove(IMedicamentComponent component)
    {
        _components.Remove(component);
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth * 2)}[Grup] {Name} - Total: {Price} RON");
        foreach (var component in _components)
        {
            // Fiecare copil se afiseaza cu un nivel de adancime mai mare
            component.Display(depth + 1);
        }
    }
}
