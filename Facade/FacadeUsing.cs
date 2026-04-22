using System;

namespace TMPP.Structural.Facade;

public static class FacadeUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Facade Pattern ---");

        // Clientul nu stie nimic despre StocService, RetetaService, PlataService sau NotificareService.
        // Interactioneaza doar cu FarmacieFacade printr-un singur apel simplu.
        var farmacie = new FarmacieFacade();

        // Comanda 1 - medicament cu reteta
        farmacie.ProcesezaComanada(
            numePacient: "Ion Popescu",
            numeMedicament: "Amoxicilina 500mg",
            cantitate: 2,
            pretPerBucata: 35.00m
        );

        // Comanda 2 - supliment fara reteta
        farmacie.ProcesezaComanada(
            numePacient: "Maria Ionescu",
            numeMedicament: "Vitamina C 1000mg",
            cantitate: 3,
            pretPerBucata: 15.00m
        );
    }
}
