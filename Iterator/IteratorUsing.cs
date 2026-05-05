namespace TMPP.Behavioral.Iterator;

public static class IteratorUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Iterator Pattern ---");
        Console.WriteLine("Scenariu: Parcurgerea catalogului de medicamente cu diferiti iteratori (filtre si sortari).\n");

        // Cream catalogul farmaciei cu medicamente diverse
        var catalog = new CatalogFarmacie();
        catalog.AdaugaMedicament(new MedicamentItem("Paracetamol 500mg", "Analgezic", 8.00m, false, 200));
        catalog.AdaugaMedicament(new MedicamentItem("Ibuprofen 400mg", "Analgezic", 12.50m, false, 150));
        catalog.AdaugaMedicament(new MedicamentItem("Amoxicilina 500mg", "Antibiotic", 35.00m, true, 50));
        catalog.AdaugaMedicament(new MedicamentItem("Azitromicina 250mg", "Antibiotic", 42.00m, true, 30));
        catalog.AdaugaMedicament(new MedicamentItem("Vitamina C 1000mg", "Vitamina", 15.00m, false, 300));
        catalog.AdaugaMedicament(new MedicamentItem("Vitamina D3 2000UI", "Vitamina", 22.00m, false, 180));
        catalog.AdaugaMedicament(new MedicamentItem("Oseltamivir 75mg", "Antiviral", 65.00m, true, 25));
        catalog.AdaugaMedicament(new MedicamentItem("Morfina 10mg", "Analgezic", 120.00m, true, 10));

        Console.WriteLine($"  Catalog incarcat cu {catalog.TotalMedicamente} medicamente.\n");

        // 1. Iterator secvential - parcurgere normala
        Console.WriteLine(">> 1. Iterator Secvential (toate medicamentele):");
        ParcurgeIterator(catalog.CreazaIteratorSecvential());

        // 2. Iterator pe categorie - doar antibiotice
        Console.WriteLine("\n>> 2. Iterator Categorie - doar 'Antibiotic':");
        ParcurgeIterator(catalog.CreazaIteratorCategorie("Antibiotic"));

        // 3. Iterator medicamente cu reteta
        Console.WriteLine("\n>> 3. Iterator - doar medicamente cu reteta:");
        ParcurgeIterator(catalog.CreazaIteratorCuReteta());

        // 4. Iterator sortat dupa pret
        Console.WriteLine("\n>> 4. Iterator - sortate dupa pret (crescator):");
        ParcurgeIterator(catalog.CreazaIteratorPretCrescator());

        // 5. Iterator pe alta categorie - vitamine
        Console.WriteLine("\n>> 5. Iterator Categorie - doar 'Vitamina':");
        ParcurgeIterator(catalog.CreazaIteratorCategorie("Vitamina"));
    }

    // Metoda helper - demonstreaza ca toti iteratorii se folosesc la fel (polimorfism)
    private static void ParcurgeIterator(IMedicamentIterator iterator)
    {
        Console.WriteLine($"  [Iterator: {iterator.NumeIterator}]");
        int index = 1;
        while (iterator.AreUrmator())
        {
            var medicament = iterator.Urmator();
            Console.WriteLine($"    {index}. {medicament}");
            index++;
        }

        if (index == 1)
        {
            Console.WriteLine("    (niciun medicament gasit)");
        }
    }
}
