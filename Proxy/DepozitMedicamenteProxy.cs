namespace TMPP.Structural.Proxy;

// Proxy - controleaza accesul la depozitul real de medicamente.
// Adauga: verificare autorizare, logare acces, si restrictii pentru substante controlate.
public class DepozitMedicamenteProxy : IDepozitMedicamente
{
    private readonly DepozitMedicamenteReal _depozitReal;
    private readonly string _numeUtilizator;
    private readonly string _rolUtilizator; // "Farmacist", "Asistent", "Client"
    private readonly List<string> _jurnalAcces = new();

    // Lista de substante controlate care necesita rol de Farmacist
    private static readonly HashSet<string> _substanteControlate = new()
    {
        "Morfina 10mg",
        "Codeina 30mg",
        "Diazepam 5mg"
    };

    public DepozitMedicamenteProxy(DepozitMedicamenteReal depozitReal, string numeUtilizator, string rolUtilizator)
    {
        _depozitReal = depozitReal;
        _numeUtilizator = numeUtilizator;
        _rolUtilizator = rolUtilizator;
    }

    public string ElibereazaMedicament(string numeMedicament, int cantitate)
    {
        // 1. Logare tentativa de acces
        string logEntry = $"[{DateTime.Now:HH:mm:ss}] {_numeUtilizator} ({_rolUtilizator}) -> ElibereazaMedicament('{numeMedicament}', {cantitate})";
        _jurnalAcces.Add(logEntry);
        Console.WriteLine($"  [Proxy-Log] {logEntry}");

        // 2. Verificare autorizare pentru substante controlate
        if (_substanteControlate.Contains(numeMedicament))
        {
            if (_rolUtilizator != "Farmacist")
            {
                string mesajRefuz = $"  [Proxy-Securitate] ACCES REFUZAT: '{numeMedicament}' este substanta controlata. " +
                                    $"Doar farmacistii pot elibera acest medicament. Utilizator: {_numeUtilizator} ({_rolUtilizator})";
                Console.WriteLine(mesajRefuz);
                _jurnalAcces.Add($"  >> REFUZAT - rol insuficient");
                return mesajRefuz;
            }

            Console.WriteLine($"  [Proxy-Securitate] Autorizare OK: {_numeUtilizator} are rol '{_rolUtilizator}' - acces permis pentru substanta controlata.");
        }

        // 3. Verificare cantitate maxima (proxy adauga o regula de business)
        if (cantitate > 10)
        {
            string mesajLimita = $"  [Proxy-Regula] REFUZAT: Cantitate maxima permisa per eliberare este 10. Cerut: {cantitate}";
            Console.WriteLine(mesajLimita);
            return mesajLimita;
        }

        // 4. Delegare catre depozitul real
        Console.WriteLine($"  [Proxy] Delegare catre depozitul real...");
        return _depozitReal.ElibereazaMedicament(numeMedicament, cantitate);
    }

    public List<string> VeziMedicamenteDisponibile()
    {
        Console.WriteLine($"  [Proxy-Log] {_numeUtilizator} ({_rolUtilizator}) vizualizeaza lista medicamente.");
        var lista = _depozitReal.VeziMedicamenteDisponibile();

        // Clientii nu vad substantele controlate in lista
        if (_rolUtilizator == "Client")
        {
            Console.WriteLine($"  [Proxy-Filtru] Ascund substantele controlate pentru rolul 'Client'.");
            lista = lista.Where(m => !_substanteControlate.Any(sc => m.StartsWith(sc))).ToList();
        }

        return lista;
    }

    // Metoda suplimentara a Proxy-ului (nu exista pe RealSubject)
    public void AfiseazaJurnalAcces()
    {
        Console.WriteLine($"\n  [Proxy] Jurnal acces pentru {_numeUtilizator}:");
        foreach (var entry in _jurnalAcces)
        {
            Console.WriteLine($"    {entry}");
        }
    }
}
