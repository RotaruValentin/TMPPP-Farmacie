namespace TMPP.Behavioral.Observer;

public static class ObserverUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Observer Pattern ---");
        Console.WriteLine("Scenariu: Notificari automate la modificarea stocului de medicamente.\n");

        // Cream subiectul (depozitul)
        var depozit = new DepozitMedicamenteSubject();

        // Cream observatorii
        var farmacist = new FarmacistObservator("Dr. Ionescu", pragMinim: 10);
        var furnizor = new FurnizorObservator("GlobalPharma", pragReaprovizionare: 20);
        var raportare = new RaportareObservator();

        // Abonam toti observatorii
        Console.WriteLine(">> Abonare observatori:");
        depozit.Aboneaza(farmacist);
        depozit.Aboneaza(furnizor);
        depozit.Aboneaza(raportare);

        // 1. Vanzare normala - stocul nu scade sub prag
        Console.WriteLine("\n>> 1. Vanzare normala (fara alerta):");
        depozit.VindeMedicament("Paracetamol 500mg", 5);

        // 2. Vanzare care genereaza alerta la furnizor (sub prag reaprovizionare)
        Console.WriteLine("\n>> 2. Vanzare cu alerta furnizor (stoc sub 20):");
        depozit.VindeMedicament("Ibuprofen 400mg", 15);

        // 3. Vanzare care genereaza alerta critica la farmacist (sub prag minim)
        Console.WriteLine("\n>> 3. Vanzare cu alerta critica (stoc sub 10):");
        depozit.VindeMedicament("Amoxicilina 500mg", 8);

        // 4. Aprovizionare - toti sunt notificati
        Console.WriteLine("\n>> 4. Aprovizionare noua:");
        depozit.AprovizionareaMedicament("Amoxicilina 500mg", 100);

        // 5. Dezabonam furnizorul si facem o alta vanzare
        Console.WriteLine("\n>> 5. Dezabonare furnizor + vanzare:");
        depozit.Dezaboneaza(furnizor);
        depozit.VindeMedicament("Insulina NovoRapid", 3);

        // Afisam raportul final
        raportare.AfiseazaRaport();
    }
}
