namespace TMPP.Behavioral.Command;

public static class CommandUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Command Pattern ---");
        Console.WriteLine("Scenariu: Procesare comenzi farmacie cu suport pentru Undo.\n");

        var inventar = new InventarFarmacie();
        var procesor = new ProcesorComenzi();

        // Stare initiala
        Console.WriteLine(">> Stare initiala a inventarului:");
        inventar.AfiseazaStare();

        // 1. Eliberam Paracetamol
        Console.WriteLine("\n>> 1. Eliberare Paracetamol:");
        procesor.ExecutaComanda(new ComandaEliberare(inventar, "Paracetamol 500mg", 10));

        // 2. Eliberam Ibuprofen
        Console.WriteLine("\n>> 2. Eliberare Ibuprofen:");
        procesor.ExecutaComanda(new ComandaEliberare(inventar, "Ibuprofen 400mg", 5));

        // 3. Adaugam un medicament nou in inventar
        Console.WriteLine("\n>> 3. Adaugare medicament nou:");
        procesor.ExecutaComanda(new ComandaAdaugare(inventar, "Aspirina 100mg", 50, 6.50m));

        // Verificam starea dupa comenzi
        Console.WriteLine("\n>> Stare dupa 3 comenzi:");
        inventar.AfiseazaStare();
        procesor.AfiseazaIstoric();

        // 4. Anulam ultima comanda (adaugarea de Aspirina)
        Console.WriteLine("\n>> 4. UNDO - anulam adaugarea de Aspirina:");
        procesor.AnuleazaUltimaComanda();

        // 5. Anulam urmatoarea comanda (eliberarea de Ibuprofen)
        Console.WriteLine("\n>> 5. UNDO - anulam eliberarea de Ibuprofen:");
        procesor.AnuleazaUltimaComanda();

        // Stare finala
        Console.WriteLine("\n>> Stare finala:");
        inventar.AfiseazaStare();
        procesor.AfiseazaIstoric();
    }
}
