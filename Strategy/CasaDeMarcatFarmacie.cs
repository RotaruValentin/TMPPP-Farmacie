namespace TMPP.Behavioral.Strategy;

// Context - Casa de marcat care utilizeaza o strategie de calcul al pretului.
// Strategia poate fi schimbata la runtime in functie de tipul clientului.
public class CasaDeMarcatFarmacie
{
    private IStrategieCalculPret _strategiePret;

    public CasaDeMarcatFarmacie(IStrategieCalculPret strategiePret)
    {
        _strategiePret = strategiePret;
    }

    // Permite schimbarea strategiei la runtime
    public void SeteazaStrategie(IStrategieCalculPret strategieNoua)
    {
        Console.WriteLine($"  [CasaDeMarcat] Schimbare strategie: '{_strategiePret.NumeStrategie}' -> '{strategieNoua.NumeStrategie}'");
        _strategiePret = strategieNoua;
    }

    public decimal ProceseazaVanzare(string numeMedicament, decimal pretUnitar, int cantitate)
    {
        Console.WriteLine($"  [CasaDeMarcat] Procesare: {cantitate}x '{numeMedicament}' (pret unitar: {pretUnitar:F2} RON)");
        Console.WriteLine($"  [CasaDeMarcat] Strategie activa: {_strategiePret.NumeStrategie}");

        decimal pretFinal = _strategiePret.CalculeazaPret(numeMedicament, pretUnitar, cantitate);

        Console.WriteLine($"  [CasaDeMarcat] TOTAL DE PLATA: {pretFinal:F2} RON");
        return pretFinal;
    }
}
