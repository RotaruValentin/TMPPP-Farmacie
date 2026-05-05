namespace TMPP.Behavioral.Strategy;

public static class StrategyUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Strategy Pattern ---");
        Console.WriteLine("Scenariu: Casa de marcat cu strategii diferite de calcul al pretului.\n");

        // 1. Client standard - pret normal cu TVA
        Console.WriteLine(">> 1. Client standard - pret cu TVA:");
        var casa = new CasaDeMarcatFarmacie(new PretStandard());
        casa.ProceseazaVanzare("Ibuprofen 400mg", 12.50m, 2);

        // 2. Pensionar - beneficiaza de discount 15%
        Console.WriteLine("\n>> 2. Pensionar - discount special:");
        casa.SeteazaStrategie(new PretPensionar());
        casa.ProceseazaVanzare("Paracetamol 500mg", 8.00m, 3);

        // 3. Pacient asigurat - casa de asigurari acopera 70%
        Console.WriteLine("\n>> 3. Pacient cu asigurare medicala:");
        casa.SeteazaStrategie(new PretAsigurare());
        casa.ProceseazaVanzare("Amoxicilina 500mg", 35.00m, 1);

        // 4. Comanda en-gros de la un spital
        Console.WriteLine("\n>> 4. Comanda en-gros (spital):");
        casa.SeteazaStrategie(new PretEnGros());
        casa.ProceseazaVanzare("Vitamina C 1000mg", 15.00m, 60);
    }
}
