namespace TMPP.Behavioral.State;

public static class StateUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- State Pattern ---");
        Console.WriteLine("Scenariu: Ciclul de viata al unei comenzi de medicamente (Noua -> Verificata -> Predata Curier -> Livrata).\n");

        // 1. Flux normal complet: Noua -> Verificata -> Predata Curier -> Livrata
        Console.WriteLine(">> 1. Flux normal - comanda parcurge toate starile:");
        var comanda1 = new ComandaMedicamente("CMD-001", "Ion Popescu", "Str. Farmaciei Nr. 10, Bucuresti",
            new Dictionary<string, int>
            {
                { "Paracetamol 500mg", 2 },
                { "Vitamina C 1000mg", 1 }
            });
        comanda1.AfiseazaDetalii();

        Console.WriteLine("\n  >> Verificare comanda:");
        comanda1.Verifica();

        Console.WriteLine("\n  >> Pregatire comanda:");
        comanda1.Pregateste();

        Console.WriteLine("\n  >> Livrare comanda:");
        comanda1.Livreaza();

        Console.WriteLine("\n  >> Stare finala:");
        comanda1.AfiseazaDetalii();

        // 2. Incercare de actiune invalida pe comanda livrata
        Console.WriteLine("\n>> 2. Actiuni invalide pe comanda livrata:");
        Console.WriteLine("  >> Incercare verificare pe comanda livrata:");
        comanda1.Verifica();
        Console.WriteLine("  >> Incercare anulare pe comanda livrata:");
        comanda1.Anuleaza();

        // 3. Anulare comanda din stare verificata
        Console.WriteLine("\n>> 3. Anulare comanda dupa verificare:");
        var comanda2 = new ComandaMedicamente("CMD-002", "Maria Ionescu", "Str. Sanatatii Nr. 5, Cluj",
            new Dictionary<string, int>
            {
                { "Amoxicilina 500mg", 1 },
                { "Ibuprofen 400mg", 3 }
            });
        comanda2.Verifica();
        Console.WriteLine("\n  >> Anulare comanda verificata:");
        comanda2.Anuleaza();
        Console.WriteLine("\n  >> Stare finala:");
        comanda2.AfiseazaDetalii();

        // 4. Incercare de a sari peste o stare
        Console.WriteLine("\n>> 4. Incercare de a livra direct o comanda noua (fara verificare si pregatire):");
        var comanda3 = new ComandaMedicamente("CMD-003", "Vasile Gheorghe", "Str. Libertatii Nr. 22, Iasi",
            new Dictionary<string, int>
            {
                { "Insulina NovoRapid", 2 }
            });
        comanda3.Livreaza();
        Console.WriteLine("  >> Incercare pregatire fara verificare:");
        comanda3.Pregateste();
    }
}
