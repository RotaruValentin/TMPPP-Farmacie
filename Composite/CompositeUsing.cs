using System;

namespace TMPP.Structural.Composite;

public static class CompositeUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Composite Pattern ---");

        // Leaf-uri: medicamente individuale
        var ibuprofen = new MedicamentIndividual("Ibuprofen 400mg", 12.50m);
        var paracetamol = new MedicamentIndividual("Paracetamol 500mg", 8.00m);
        var vitamina = new MedicamentIndividual("Vitamina C 1000mg", 15.00m);
        var zinc = new MedicamentIndividual("Zinc 50mg", 10.00m);
        var amoxicilina = new MedicamentIndividual("Amoxicilina 500mg", 35.00m);
        var probiotice = new MedicamentIndividual("Probiotice LactoBalance", 45.00m);

        // Composite nivel 1 - grup de imunitate
        var kitImunitate = new MedicamentGroup("Kit Imunitate");
        kitImunitate.Add(vitamina);
        kitImunitate.Add(zinc);

        // Composite nivel 1 - tratament antibiotic
        var tratamentAntibiotic = new MedicamentGroup("Tratament Antibiotic");
        tratamentAntibiotic.Add(amoxicilina);
        tratamentAntibiotic.Add(probiotice);

        // Composite nivel 2 - kit complet antiviral (contine alte grupuri + medicamente individuale)
        var kitAntiviral = new MedicamentGroup("Kit Antiviral Complet");
        kitAntiviral.Add(ibuprofen);
        kitAntiviral.Add(paracetamol);
        kitAntiviral.Add(kitImunitate);        // sub-grup
        kitAntiviral.Add(tratamentAntibiotic); // sub-grup

        // Clientul trateaza uniform atat un medicament individual cat si un grup intreg
        Console.WriteLine("\n>> Medicament individual:");
        ibuprofen.Display();

        Console.WriteLine("\n>> Kit Imunitate (grup simplu):");
        kitImunitate.Display();

        Console.WriteLine("\n>> Kit Antiviral Complet (grup arbore):");
        kitAntiviral.Display();

        Console.WriteLine($"\nPret total kit antiviral: {kitAntiviral.Price} RON");
    }
}
