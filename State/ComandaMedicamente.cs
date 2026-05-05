namespace TMPP.Behavioral.State;

// Context - Comanda de medicamente care isi schimba comportamentul in functie de stare.
// Delega toate actiunile catre obiectul de stare curent.
public class ComandaMedicamente
{
    private IStareComanda _stareCurenta;
    private readonly List<string> _istoricStari = new();

    public string IdComanda { get; }
    public string NumeClient { get; }
    public string AdresaLivrare { get; }
    public Dictionary<string, int> Medicamente { get; } // nume -> cantitate

    public ComandaMedicamente(string idComanda, string numeClient, string adresaLivrare,
        Dictionary<string, int> medicamente)
    {
        IdComanda = idComanda;
        NumeClient = numeClient;
        AdresaLivrare = adresaLivrare;
        Medicamente = medicamente;
        _stareCurenta = new StareNoua();
        _istoricStari.Add(_stareCurenta.NumeStare);
    }

    // Schimba starea comenzii si inregistreaza tranzitia
    public void SchimbaStare(IStareComanda stareNoua)
    {
        Console.WriteLine($"  [Comanda #{IdComanda}] Tranzitie: '{_stareCurenta.NumeStare}' -> '{stareNoua.NumeStare}'");
        _stareCurenta = stareNoua;
        _istoricStari.Add(stareNoua.NumeStare);
    }

    // Actiuni delegate catre starea curenta
    public void Verifica() => _stareCurenta.Verifica(this);
    public void Pregateste() => _stareCurenta.Pregateste(this);
    public void Livreaza() => _stareCurenta.Livreaza(this);
    public void Anuleaza() => _stareCurenta.Anuleaza(this);

    public void AfiseazaDetalii()
    {
        Console.WriteLine($"  [Comanda #{IdComanda}] Client: {NumeClient}, Adresa: {AdresaLivrare}");
        Console.WriteLine($"  [Comanda #{IdComanda}] Stare curenta: {_stareCurenta.NumeStare}");
        Console.WriteLine($"  [Comanda #{IdComanda}] Medicamente:");
        foreach (var med in Medicamente)
        {
            Console.WriteLine($"    - {med.Key} x{med.Value}");
        }
        Console.WriteLine($"  [Comanda #{IdComanda}] Istoric stari: {string.Join(" -> ", _istoricStari)}");
    }
}
