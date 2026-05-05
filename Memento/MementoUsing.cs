namespace TMPP.Behavioral.Memento;

public static class MementoUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Memento Pattern ---");
        Console.WriteLine("Scenariu: Editarea unei retete medicale cu posibilitatea de a reveni la versiuni anterioare.\n");

        var reteta = new RetetaMedicala("Ion Popescu", "Dr. Maria Ionescu", "Gripa sezoniera");
        var istoric = new IstoricRetete();

        // 1. Starea initiala a retetei
        Console.WriteLine(">> 1. Creare reteta initiala:");
        reteta.AdaugaMedicament("Paracetamol 500mg - 3x/zi");
        reteta.AdaugaMedicament("Vitamina C 1000mg - 1x/zi");
        reteta.Afiseaza();

        // Salvam versiunea 1
        Console.WriteLine("\n>> Salvare versiunea 1:");
        istoric.SalveazaVersiune(reteta.SalveazaStare());

        // 2. Doctorul modifica reteta - adauga antibiotic
        Console.WriteLine("\n>> 2. Modificare reteta - adaugare antibiotic:");
        reteta.AdaugaMedicament("Amoxicilina 500mg - 2x/zi");
        reteta.SchimbaDiagnostic("Gripa complicata cu infectie bacteriana");
        reteta.Afiseaza();

        // Salvam versiunea 2
        Console.WriteLine("\n>> Salvare versiunea 2:");
        istoric.SalveazaVersiune(reteta.SalveazaStare());

        // 3. Doctorul schimba iar reteta - inlocuire medicament
        Console.WriteLine("\n>> 3. Modificare reteta - inlocuire antibiotic:");
        reteta.StergeMedicament("Amoxicilina 500mg - 2x/zi");
        reteta.AdaugaMedicament("Azitromicina 250mg - 1x/zi");
        reteta.AdaugaMedicament("Ibuprofen 400mg - la nevoie");
        reteta.Afiseaza();

        // Salvam versiunea 3
        Console.WriteLine("\n>> Salvare versiunea 3:");
        istoric.SalveazaVersiune(reteta.SalveazaStare());

        // Afisam toate versiunile salvate
        istoric.AfiseazaVersiuni();

        // 4. Pacientul are alergie la Azitromicina - revenim la versiunea 2
        Console.WriteLine("\n>> 4. UNDO - pacientul are alergie, revenim la versiunea anterioara:");
        var mementoAnterior = istoric.RestaureareaUltimaVersiune();
        if (mementoAnterior != null)
        {
            // Aceasta restaureaza versiunea 3, dar noi vrem versiunea 2
            // Facem inca un undo
            mementoAnterior = istoric.RestaureareaUltimaVersiune();
            if (mementoAnterior != null)
            {
                reteta.RestaureazaStare(mementoAnterior);
            }
        }

        Console.WriteLine("\n>> Stare finala dupa restaurare:");
        reteta.Afiseaza();
    }
}
