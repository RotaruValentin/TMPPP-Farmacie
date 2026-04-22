using System;

namespace TMPP.Structural.Facade;

// Subsistem 3 - proceseaza platile
public class PlataService
{
    public bool ProceseazaPlata(string numePacient, decimal suma)
    {
        Console.WriteLine($"  [PlataService] Procesez plata de {suma} RON pentru '{numePacient}'...");
        Console.WriteLine($"  [PlataService] Plata a fost efectuata cu succes.");
        return true;
    }
}
