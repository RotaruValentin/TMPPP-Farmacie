namespace TMPP.Structural.Bridge;

public static class BridgeUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Bridge Pattern ---");
        Console.WriteLine("Scenariu: Rapoarte farmaceutice exportate in formate diferite.");
        Console.WriteLine("Bridge separa tipul raportului (CE date) de formatul de export (CUM se afiseaza).\n");

        // Cream formatele de export disponibile
        var formatConsola = new FormatConsola();
        var formatCSV = new FormatCSV();
        var formatHTML = new FormatHTML();

        // 1. Raport de Vanzari exportat la Consola
        Console.WriteLine(">> Raport Vanzari -> Format Consola:");
        var raportVanzariConsola = new RaportVanzari(formatConsola);
        raportVanzariConsola.Genereaza();

        // 2. Raport de Vanzari exportat in CSV
        Console.WriteLine("\n>> Raport Vanzari -> Format CSV:");
        var raportVanzariCSV = new RaportVanzari(formatCSV);
        raportVanzariCSV.Genereaza();

        // 3. Raport de Stoc exportat in HTML
        Console.WriteLine("\n>> Raport Stoc -> Format HTML:");
        var raportStocHTML = new RaportStocMedicamente(formatHTML);
        raportStocHTML.Genereaza();

        // 4. Raport de Stoc exportat la Consola
        Console.WriteLine("\n>> Raport Stoc -> Format Consola:");
        var raportStocConsola = new RaportStocMedicamente(formatConsola);
        raportStocConsola.Genereaza();

        Console.WriteLine("\n  [Bridge] Observatie: 2 tipuri de rapoarte × 3 formate = 6 combinatii posibile,");
        Console.WriteLine("  dar avem nevoie de doar 2+3=5 clase in loc de 2×3=6 clase.");
    }
}
