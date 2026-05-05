namespace TMPP.Behavioral.TemplateMethod;

public static class TemplateMethodUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Template Method Pattern ---");
        Console.WriteLine("Scenariu: Procesarea diferitelor tipuri de retete (standard, compensata, stupefiante).\n");
        Console.WriteLine("  Template: Validare -> [Verificare Speciala?] -> Pregatire -> Ambalare -> [Avertismente?] -> Eliberare\n");

        // 1. Reteta standard (OTC) - flux simplu
        Console.WriteLine(">> 1. Procesare reteta STANDARD (Paracetamol - fara reteta):");
        var procesatorStandard = new ProcesatorRetetaStandard();
        procesatorStandard.ProceseazaReteta("Ion Popescu", "Paracetamol 500mg", 2);

        // 2. Reteta compensata CNAS - cu card de sanatate
        Console.WriteLine("\n>> 2. Procesare reteta COMPENSATA (Amoxicilina - compensare 50%):");
        var procesatorCompensat = new ProcesatorRetetaCompensata(0.50m);
        procesatorCompensat.ProceseazaReteta("Maria Ionescu", "Amoxicilina 500mg", 1);

        // 3. Reteta stupefiante - verificari maximale
        Console.WriteLine("\n>> 3. Procesare reteta STUPEFIANTE (Morfina - regim special):");
        var procesatorStudefiante = new ProcesatorRetetaStupefiante();
        procesatorStudefiante.ProceseazaReteta("Vasile Gheorghe", "Morfina 10mg", 5);
    }
}
