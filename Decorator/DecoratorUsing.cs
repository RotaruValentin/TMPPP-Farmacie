namespace TMPP.Structural.Decorator;

public static class DecoratorUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Decorator Pattern ---");
        Console.WriteLine("Scenariu: Serviciu de livrare medicamente cu optiuni suplimentare aditionale.\n");

        // 1. Livrare simpla (fara decoratori)
        IServiciuLivrare livrare1 = new LivrareStandard("Paracetamol 500mg");
        Console.WriteLine(">> Comanda 1 - Livrare simpla:");
        Console.WriteLine($"   Descriere: {livrare1.GetDescriere()}");
        Console.WriteLine($"   Cost total: {livrare1.GetCost()} RON");

        // 2. Livrare cu ambalaj cadou + livrare expresa (2 decoratori combinati)
        IServiciuLivrare livrare2 = new LivrareStandard("Vitamina C 1000mg");
        livrare2 = new AmbalajCadouDecorator(livrare2);       // +5 RON
        livrare2 = new LivrareExpresaDecorator(livrare2);      // +15 RON
        Console.WriteLine("\n>> Comanda 2 - Livrare cu cadou si expresa:");
        Console.WriteLine($"   Descriere: {livrare2.GetDescriere()}");
        Console.WriteLine($"   Cost total: {livrare2.GetCost()} RON");

        // 3. Livrare premium: toate optiunile (4 decoratori suprapusi)
        IServiciuLivrare livrare3 = new LivrareStandard("Insulina NovoRapid");
        livrare3 = new TemperaturaControlataDecorator(livrare3); // +20 RON (insulina are nevoie de frig)
        livrare3 = new AsigurareTransportDecorator(livrare3);    // +8.50 RON
        livrare3 = new LivrareExpresaDecorator(livrare3);        // +15 RON
        livrare3 = new AmbalajCadouDecorator(livrare3);          // +5 RON
        Console.WriteLine("\n>> Comanda 3 - Livrare premium completa:");
        Console.WriteLine($"   Descriere: {livrare3.GetDescriere()}");
        Console.WriteLine($"   Cost total: {livrare3.GetCost()} RON");

        // 4. Doar asigurare (un singur decorator)
        IServiciuLivrare livrare4 = new LivrareStandard("Amoxicilina 500mg");
        livrare4 = new AsigurareTransportDecorator(livrare4);    // +8.50 RON
        Console.WriteLine("\n>> Comanda 4 - Livrare cu asigurare:");
        Console.WriteLine($"   Descriere: {livrare4.GetDescriere()}");
        Console.WriteLine($"   Cost total: {livrare4.GetCost()} RON");
    }
}
