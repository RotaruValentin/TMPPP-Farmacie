using System;

namespace TMPP.Structural.Facade;

// Facade - ascunde complexitatea celor 4 subsisteme in spatele unui singur punct de intrare
public class FarmacieFacade
{
    private readonly StocService _stocService;
    private readonly RetetaService _retetaService;
    private readonly PlataService _plataService;
    private readonly NotificareService _notificareService;

    public FarmacieFacade()
    {
        // Facade isi instantiaza singur subsistemele
        _stocService = new StocService();
        _retetaService = new RetetaService();
        _plataService = new PlataService();
        _notificareService = new NotificareService();
    }

    // O singura metoda simpla pentru client, in loc de 4 apeluri separate catre subsisteme
    public bool ProcesezaComanada(string numePacient, string numeMedicament, int cantitate, decimal pretPerBucata)
    {
        Console.WriteLine($"\n>> Procesez comanda: {cantitate}x '{numeMedicament}' pentru '{numePacient}'");

        // 1. Verifica stocul
        if (!_stocService.VerificaDisponibilitate(numeMedicament, cantitate))
        {
            Console.WriteLine("  [Facade] Comanda esuata: stoc insuficient.");
            return false;
        }

        // 2. Valideaza reteta (daca e cazul)
        if (!_retetaService.ValidateReteta(numePacient, numeMedicament))
        {
            Console.WriteLine("  [Facade] Comanda esuata: reteta invalida.");
            return false;
        }

        // 3. Proceseaza plata
        decimal total = pretPerBucata * cantitate;
        if (!_plataService.ProceseazaPlata(numePacient, total))
        {
            Console.WriteLine("  [Facade] Comanda esuata: plata refuzata.");
            return false;
        }

        // 4. Rezerva din stoc dupa plata confirmata
        _stocService.RezervaMedicament(numeMedicament, cantitate);

        // 5. Notifica pacientul
        _notificareService.TrimiteConfirmare(numePacient, numeMedicament, cantitate);

        Console.WriteLine($"  [Facade] Comanda finalizata cu succes! Total: {total} RON.");
        return true;
    }
}
