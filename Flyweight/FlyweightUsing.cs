namespace TMPP.Structural.Flyweight;

public static class FlyweightUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Flyweight Pattern ---");
        Console.WriteLine("Scenariu: O farmacie creeaza multe prescriptii care refera aceleasi medicamente.");
        Console.WriteLine("Flyweight partajeaza specificatiile medicamentelor in loc sa le duplice.\n");

        var factory = new MedicamentSpecFactory();

        // Cream 6 prescriptii, dar doar pentru 3 medicamente unice
        // => factory va crea doar 3 obiecte MedicamentSpec in memorie

        var p1 = new Prescriptie(
            factory.GetSpec("Ibuprofen", "Ibuprofenum", "Antiinflamator", "Dureri stomac, ameteala"),
            "Ion Popescu", 2, new DateTime(2026, 12, 31));

        var p2 = new Prescriptie(
            factory.GetSpec("Amoxicilina", "Amoxicillinum", "Antibiotic", "Diaree, eruptii cutanate"),
            "Maria Ionescu", 1, new DateTime(2026, 06, 15));

        var p3 = new Prescriptie(
            factory.GetSpec("Ibuprofen", "Ibuprofenum", "Antiinflamator", "Dureri stomac, ameteala"),
            "Andrei Vasile", 3, new DateTime(2026, 09, 01));

        var p4 = new Prescriptie(
            factory.GetSpec("Paracetamol", "Paracetamolum", "Analgezic", "Reactii alergice rare"),
            "Elena Dumitrescu", 2, new DateTime(2026, 11, 20));

        var p5 = new Prescriptie(
            factory.GetSpec("Amoxicilina", "Amoxicillinum", "Antibiotic", "Diaree, eruptii cutanate"),
            "Cristian Radu", 1, new DateTime(2026, 07, 10));

        var p6 = new Prescriptie(
            factory.GetSpec("Paracetamol", "Paracetamolum", "Analgezic", "Reactii alergice rare"),
            "Ana Marin", 4, new DateTime(2026, 10, 05));

        // Afisam toate prescriptiile
        Console.WriteLine("\n>> Toate prescriptiile:");
        var prescriptii = new[] { p1, p2, p3, p4, p5, p6 };
        foreach (var p in prescriptii)
        {
            p.Afiseaza();
            Console.WriteLine();
        }

        // Demonstram economia de memorie
        Console.WriteLine($"Total prescriptii create: {prescriptii.Length}");
        Console.WriteLine($"Total obiecte MedicamentSpec in memorie: {factory.GetTotalSpecsCreate()}");
        Console.WriteLine($"Obiecte economisite: {prescriptii.Length - factory.GetTotalSpecsCreate()}");
    }
}
