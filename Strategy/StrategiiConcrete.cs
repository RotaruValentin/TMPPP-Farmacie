namespace TMPP.Behavioral.Strategy;

// ConcreteStrategy 1 - Pret standard (fara reduceri, doar TVA 9% pentru medicamente)
public class PretStandard : IStrategieCalculPret
{
    public string NumeStrategie => "Pret Standard (cu TVA 9%)";

    public decimal CalculeazaPret(string numeMedicament, decimal pretBaza, int cantitate)
    {
        decimal subtotal = pretBaza * cantitate;
        decimal tva = subtotal * 0.09m;
        Console.WriteLine($"    [{NumeStrategie}] Subtotal: {subtotal:F2} RON + TVA(9%): {tva:F2} RON");
        return subtotal + tva;
    }
}

// ConcreteStrategy 2 - Pret cu discount pentru pensionari (reducere 15% + TVA redus 5%)
public class PretPensionar : IStrategieCalculPret
{
    public string NumeStrategie => "Pret Pensionar (discount 15% + TVA 5%)";

    public decimal CalculeazaPret(string numeMedicament, decimal pretBaza, int cantitate)
    {
        decimal subtotal = pretBaza * cantitate;
        decimal discount = subtotal * 0.15m;
        decimal subtotalRedus = subtotal - discount;
        decimal tva = subtotalRedus * 0.05m;
        Console.WriteLine($"    [{NumeStrategie}] Subtotal: {subtotal:F2} RON - Discount(15%): {discount:F2} RON + TVA(5%): {tva:F2} RON");
        return subtotalRedus + tva;
    }
}

// ConcreteStrategy 3 - Pret cu asigurare medicala (casa de asigurari acopera 70%)
public class PretAsigurare : IStrategieCalculPret
{
    public string NumeStrategie => "Pret Asigurare (acoperire 70%)";

    public decimal CalculeazaPret(string numeMedicament, decimal pretBaza, int cantitate)
    {
        decimal subtotal = pretBaza * cantitate;
        decimal tva = subtotal * 0.09m;
        decimal totalCuTVA = subtotal + tva;
        decimal acoperireAsigurare = totalCuTVA * 0.70m;
        decimal dePlata = totalCuTVA - acoperireAsigurare;
        Console.WriteLine($"    [{NumeStrategie}] Total: {totalCuTVA:F2} RON - Asigurare(70%): {acoperireAsigurare:F2} RON");
        return dePlata;
    }
}

// ConcreteStrategy 4 - Pret en-gros (reducere progresiva pe cantitate)
public class PretEnGros : IStrategieCalculPret
{
    public string NumeStrategie => "Pret En-Gros (discount pe cantitate)";

    public decimal CalculeazaPret(string numeMedicament, decimal pretBaza, int cantitate)
    {
        decimal procentDiscount = cantitate switch
        {
            >= 100 => 0.30m,
            >= 50 => 0.20m,
            >= 20 => 0.10m,
            _ => 0.05m
        };

        decimal subtotal = pretBaza * cantitate;
        decimal discount = subtotal * procentDiscount;
        Console.WriteLine($"    [{NumeStrategie}] Subtotal: {subtotal:F2} RON - Discount({procentDiscount * 100}%): {discount:F2} RON (cantitate: {cantitate})");
        return subtotal - discount;
    }
}
