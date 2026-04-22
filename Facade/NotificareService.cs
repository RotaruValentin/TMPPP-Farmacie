using System;

namespace TMPP.Structural.Facade;

// Subsistem 4 - trimite notificari pacientului
public class NotificareService
{
    public void TrimiteConfirmare(string numePacient, string numeMedicament, int cantitate)
    {
        Console.WriteLine($"  [NotificareService] Trimit confirmare catre '{numePacient}': " +
                          $"comanda ta de {cantitate}x '{numeMedicament}' a fost procesata cu succes.");
    }
}
