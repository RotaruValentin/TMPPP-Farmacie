namespace TMPP.Behavioral.Visitor;

public static class VisitorUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Visitor Pattern ---");
        Console.WriteLine("Scenariu: Audit si raportare farmacie - vizitatori diferiti inspecteaza elementele farmaciei.\n");

        // Cream elementele farmaciei
        var raftOTC = new RaftMedicamente("Raft A - Analgezice");
        raftOTC.AdaugaMedicament(new MedicamentStocat("Paracetamol 500mg", 5.00m, 8.00m, 150, DateTime.Now.AddMonths(18)));
        raftOTC.AdaugaMedicament(new MedicamentStocat("Ibuprofen 400mg", 8.00m, 12.50m, 10, DateTime.Now.AddMonths(12)));
        raftOTC.AdaugaMedicament(new MedicamentStocat("Aspirina 100mg", 3.50m, 6.00m, 80, DateTime.Now.AddMonths(24)));

        var frigider = new FrigiderMedicamente("Frigider Principal", 4.5m);
        frigider.AdaugaMedicament(new MedicamentStocat("Insulina NovoRapid", 45.00m, 65.00m, 25, DateTime.Now.AddMonths(6)));
        frigider.AdaugaMedicament(new MedicamentStocat("Vaccin Gripal", 30.00m, 50.00m, 8, DateTime.Now.AddDays(-10))); // EXPIRAT!
        frigider.AdaugaMedicament(new MedicamentStocat("Eritropoietina", 120.00m, 180.00m, 5, DateTime.Now.AddDays(60))); // Expira in curand

        var seif = new SeifStudefiante("Ridicat", "Dr. Maria Ionescu", DateTime.Now.AddDays(-3));
        seif.AdaugaMedicament(new MedicamentStocat("Morfina 10mg", 80.00m, 120.00m, 8, DateTime.Now.AddMonths(12)));
        seif.AdaugaMedicament(new MedicamentStocat("Diazepam 5mg", 15.00m, 25.00m, 3, DateTime.Now.AddMonths(8)));

        // Lista tuturor elementelor farmaciei
        var elementeFarmacie = new List<IElementFarmacie> { raftOTC, frigider, seif };

        // 1. Vizita Auditor Financiar
        Console.WriteLine(">> 1. Vizita AUDITOR FINANCIAR:");
        var auditor = new AuditorFinanciar();
        foreach (var element in elementeFarmacie)
        {
            element.Accepta(auditor);
        }
        auditor.AfiseazaRaportFinal();

        // 2. Vizita Inspector Sanitar
        Console.WriteLine("\n>> 2. Vizita INSPECTOR SANITAR:");
        var inspector = new InspectorSanitar();
        foreach (var element in elementeFarmacie)
        {
            element.Accepta(inspector);
        }
        inspector.AfiseazaRaportFinal();

        // 3. Vizita Analist Stoc
        Console.WriteLine("\n>> 3. Vizita ANALIST STOC:");
        var analist = new AnalistStoc(pragMinim: 20);
        foreach (var element in elementeFarmacie)
        {
            element.Accepta(analist);
        }
        analist.AfiseazaRaportFinal();
    }
}
