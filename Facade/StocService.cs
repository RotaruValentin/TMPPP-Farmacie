using System;

namespace TMPP.Structural.Facade;

// Subsistem 1 - gestioneaza stocul de medicamente
public class StocService
{
    public bool VerificaDisponibilitate(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"  [StocService] Verific stocul pentru '{numeMedicament}' (cantitate ceruta: {cantitate})...");
        // Simulam ca avem intotdeauna stoc suficient
        Console.WriteLine($"  [StocService] Stoc disponibil.");
        return true;
    }

    public void RezervaMedicament(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"  [StocService] Rezerv {cantitate}x '{numeMedicament}' din stoc.");
    }
}
