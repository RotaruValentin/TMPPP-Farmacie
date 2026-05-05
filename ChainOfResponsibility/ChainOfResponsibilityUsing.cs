namespace TMPP.Behavioral.ChainOfResponsibility;

public static class ChainOfResponsibilityUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Chain of Responsibility Pattern ---");
        Console.WriteLine("Scenariu: Lant de validare a retetei medicale inainte de eliberare.\n");

        // Construim lantul de validare:
        // Date Pacient -> Medicament Valid -> Interactiuni -> Stoc -> Farmacist
        var validatorDate = new ValidatorDatePacient();
        var validatorMedicament = new ValidatorMedicamentValid();
        var validatorInteractiuni = new ValidatorInteractiuni();
        var validatorStoc = new ValidatorStoc();
        var validatorFarmacist = new ValidatorFarmacist();

        validatorDate
            .SeteazaUrmator(validatorMedicament)
            .SeteazaUrmator(validatorInteractiuni)
            .SeteazaUrmator(validatorStoc)
            .SeteazaUrmator(validatorFarmacist);

        Console.WriteLine("  [Lant] Validatori configurati: Date Pacient -> Medicament -> Interactiuni -> Stoc -> Farmacist\n");

        // 1. Cerere valida completa - trece toate validarile
        Console.WriteLine(">> 1. Cerere valida completa (Paracetamol OTC):");
        var cerere1 = new CerereEliberare("Ion Popescu", 45, "Paracetamol 500mg", 2, false);
        Console.WriteLine($"  {cerere1}");
        bool rezultat1 = validatorDate.Valideaza(cerere1);
        Console.WriteLine($"  [Rezultat] {(rezultat1 ? "✓ APROBAT - Medicament eliberat!" : "✗ RESPINS")}\n");

        // 2. Cerere cu date pacient lipsa
        Console.WriteLine(">> 2. Cerere cu date incomplete (nume pacient lipseste):");
        var cerere2 = new CerereEliberare("", 30, "Ibuprofen 400mg", 1, false);
        Console.WriteLine($"  {cerere2}");
        bool rezultat2 = validatorDate.Valideaza(cerere2);
        Console.WriteLine($"  [Rezultat] {(rezultat2 ? "✓ APROBAT" : "✗ RESPINS - " + cerere2.Erori[^1])}\n");

        // 3. Cerere cu interactiuni periculoase
        Console.WriteLine(">> 3. Cerere cu interactiuni periculoase (Ibuprofen + Metformin):");
        var cerere3 = new CerereEliberare("Maria Ionescu", 62, "Ibuprofen 400mg", 1, false,
            new List<string> { "Metformin 850mg", "Vitamina C 1000mg" });
        Console.WriteLine($"  {cerere3}");
        Console.WriteLine($"  Medicamente actuale: {string.Join(", ", cerere3.MedicamenteActuale)}");
        bool rezultat3 = validatorDate.Valideaza(cerere3);
        Console.WriteLine($"  [Rezultat] {(rezultat3 ? "✓ APROBAT" : "✗ RESPINS - " + cerere3.Erori[^1])}\n");

        // 4. Cerere cu stoc insuficient
        Console.WriteLine(">> 4. Cerere cu stoc insuficient (Insulina - stoc 0):");
        var cerere4 = new CerereEliberare("Vasile Gheorghe", 55, "Insulina NovoRapid", 5, true);
        Console.WriteLine($"  {cerere4}");
        bool rezultat4 = validatorDate.Valideaza(cerere4);
        Console.WriteLine($"  [Rezultat] {(rezultat4 ? "✓ APROBAT" : "✗ RESPINS - " + cerere4.Erori[^1])}\n");

        // 5. Cerere fara reteta pentru medicament ce necesita reteta
        Console.WriteLine(">> 5. Cerere fara reteta pentru Amoxicilina (necesita reteta):");
        var cerere5 = new CerereEliberare("Elena Dumitrescu", 38, "Amoxicilina 500mg", 1, false);
        Console.WriteLine($"  {cerere5}");
        bool rezultat5 = validatorDate.Valideaza(cerere5);
        Console.WriteLine($"  [Rezultat] {(rezultat5 ? "✓ APROBAT" : "✗ RESPINS - " + cerere5.Erori[^1])}");
    }
}
