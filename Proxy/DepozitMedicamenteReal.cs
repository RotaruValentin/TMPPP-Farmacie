namespace TMPP.Structural.Proxy;

// RealSubject - depozitul real de medicamente cu acces direct la stoc
public class DepozitMedicamenteReal : IDepozitMedicamente
{
    private readonly Dictionary<string, int> _stoc = new()
    {
        { "Paracetamol 500mg", 200 },
        { "Ibuprofen 400mg", 150 },
        { "Amoxicilina 500mg", 50 },
        { "Morfina 10mg", 20 },         // substanta controlata
        { "Codeina 30mg", 15 },          // substanta controlata
        { "Diazepam 5mg", 25 },          // substanta controlata
        { "Vitamina C 1000mg", 300 }
    };

    public string ElibereazaMedicament(string numeMedicament, int cantitate)
    {
        if (_stoc.ContainsKey(numeMedicament) && _stoc[numeMedicament] >= cantitate)
        {
            _stoc[numeMedicament] -= cantitate;
            return $"[DepozitReal] Eliberat {cantitate}x '{numeMedicament}'. Stoc ramas: {_stoc[numeMedicament]}";
        }

        return $"[DepozitReal] EROARE: '{numeMedicament}' indisponibil sau stoc insuficient.";
    }

    public List<string> VeziMedicamenteDisponibile()
    {
        var lista = new List<string>();
        foreach (var entry in _stoc)
        {
            lista.Add($"{entry.Key} (stoc: {entry.Value})");
        }
        return lista;
    }
}
