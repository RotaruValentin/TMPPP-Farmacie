namespace TMPP.Structural.Proxy;

public static class ProxyUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Proxy Pattern ---");
        Console.WriteLine("Scenariu: Acces controlat la depozitul de medicamente.");
        Console.WriteLine("Proxy-ul verifica autorizarea, logeaza accesul si aplica reguli de business.\n");

        // Depozitul real (ascuns in spatele proxy-ului)
        var depozitReal = new DepozitMedicamenteReal();

        // ============================================
        // 1. Farmacist - are acces deplin la tot
        // ============================================
        Console.WriteLine(">> 1. Farmacist (Dr. Ionescu) - acces complet:");
        var proxyFarmacist = new DepozitMedicamenteProxy(depozitReal, "Dr. Ionescu", "Farmacist");

        // Elibereaza medicament normal
        var rezultat1 = proxyFarmacist.ElibereazaMedicament("Paracetamol 500mg", 5);
        Console.WriteLine($"  Rezultat: {rezultat1}\n");

        // Elibereaza substanta controlata (are autorizare)
        var rezultat2 = proxyFarmacist.ElibereazaMedicament("Morfina 10mg", 2);
        Console.WriteLine($"  Rezultat: {rezultat2}\n");

        // ============================================
        // 2. Asistent - NU poate elibera substante controlate
        // ============================================
        Console.WriteLine(">> 2. Asistent (Ana Popa) - acces limitat:");
        var proxyAsistent = new DepozitMedicamenteProxy(depozitReal, "Ana Popa", "Asistent");

        // Elibereaza medicament normal - OK
        var rezultat3 = proxyAsistent.ElibereazaMedicament("Ibuprofen 400mg", 3);
        Console.WriteLine($"  Rezultat: {rezultat3}\n");

        // Incearca substanta controlata - REFUZAT
        var rezultat4 = proxyAsistent.ElibereazaMedicament("Codeina 30mg", 1);
        Console.WriteLine($"  Rezultat: {rezultat4}\n");

        // ============================================
        // 3. Client - vede lista filtrata (fara substante controlate)
        // ============================================
        Console.WriteLine(">> 3. Client (Mihai Stanescu) - vizualizare filtrata:");
        var proxyClient = new DepozitMedicamenteProxy(depozitReal, "Mihai Stanescu", "Client");

        var medicamenteVizibile = proxyClient.VeziMedicamenteDisponibile();
        Console.WriteLine("  Medicamente vizibile pentru client:");
        foreach (var med in medicamenteVizibile)
        {
            Console.WriteLine($"    - {med}");
        }

        // ============================================
        // 4. Incercare cu cantitate prea mare - REFUZAT de regula proxy
        // ============================================
        Console.WriteLine("\n>> 4. Incercare cantitate excesiva:");
        var rezultat5 = proxyFarmacist.ElibereazaMedicament("Vitamina C 1000mg", 50);
        Console.WriteLine($"  Rezultat: {rezultat5}");

        // Afiseaza jurnalul de acces al farmacistului
        proxyFarmacist.AfiseazaJurnalAcces();
    }
}
