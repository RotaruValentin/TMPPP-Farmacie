using System;

namespace TMPP.Structural.Composite;

// Leaf - reprezinta un medicament individual (nu are copii)
public class MedicamentIndividual : IMedicamentComponent
{
    public string Name { get; }
    public decimal Price { get; }

    public MedicamentIndividual(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth * 2)}{Name} - {Price} RON");
    }
}
