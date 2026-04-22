using System;

namespace TMPP.Structural.Facade;

// Subsistem 2 - valideaza retetele medicale
public class RetetaService
{
    public bool ValidateReteta(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"  [RetetaService] Validez reteta pacientului '{numePacient}' pentru '{numeMedicament}'...");
        Console.WriteLine($"  [RetetaService] Reteta este valida.");
        return true;
    }
}
