namespace TMPP.Behavioral.Visitor;

// ConcreteVisitor 1 - Auditor financiar
// Calculeaza valoarea totala a stocului, marjele de profit si genereaza raport financiar
public class AuditorFinanciar : IVizitatorFarmacie
{
    public string NumeVizitator => "Auditor Financiar";
    private decimal _valoareTotalaAchizitie = 0;
    private decimal _valoareTotalaVanzare = 0;
    private int _totalProduse = 0;

    public void Viziteaza(RaftMedicamente raft)
    {
        Console.WriteLine($"    [Auditor Financiar] Inspectie: {raft.NumeElement}");
        foreach (var med in raft.Medicamente)
        {
            decimal valoareAchizitie = med.PretAchizitie * med.Cantitate;
            decimal valoareVanzare = med.PretVanzare * med.Cantitate;
            decimal marja = ((med.PretVanzare - med.PretAchizitie) / med.PretAchizitie) * 100;

            Console.WriteLine($"      {med.Nume}: {med.Cantitate} buc, achizitie {valoareAchizitie:F2} RON, vanzare {valoareVanzare:F2} RON (marja: {marja:F1}%)");

            _valoareTotalaAchizitie += valoareAchizitie;
            _valoareTotalaVanzare += valoareVanzare;
            _totalProduse += med.Cantitate;
        }
    }

    public void Viziteaza(FrigiderMedicamente frigider)
    {
        Console.WriteLine($"    [Auditor Financiar] Inspectie: {frigider.NumeElement}");
        foreach (var med in frigider.Medicamente)
        {
            decimal valoareAchizitie = med.PretAchizitie * med.Cantitate;
            decimal valoareVanzare = med.PretVanzare * med.Cantitate;
            decimal marja = ((med.PretVanzare - med.PretAchizitie) / med.PretAchizitie) * 100;

            Console.WriteLine($"      {med.Nume}: {med.Cantitate} buc, achizitie {valoareAchizitie:F2} RON, vanzare {valoareVanzare:F2} RON (marja: {marja:F1}%)");

            _valoareTotalaAchizitie += valoareAchizitie;
            _valoareTotalaVanzare += valoareVanzare;
            _totalProduse += med.Cantitate;

            // Medicamente refrigerate expirate = pierdere financiara
            if (med.EsteExpirat())
            {
                Console.WriteLine($"      ⚠ PIERDERE: '{med.Nume}' expirat - pierdere {valoareAchizitie:F2} RON");
            }
        }
    }

    public void Viziteaza(SeifStudefiante seif)
    {
        Console.WriteLine($"    [Auditor Financiar] Inspectie: {seif.NumeElement} (Securitate: {seif.NivelSecuritate})");
        foreach (var med in seif.Medicamente)
        {
            decimal valoareAchizitie = med.PretAchizitie * med.Cantitate;
            decimal valoareVanzare = med.PretVanzare * med.Cantitate;

            Console.WriteLine($"      {med.Nume}: {med.Cantitate} buc, valoare totala {valoareVanzare:F2} RON (activ controlat)");

            _valoareTotalaAchizitie += valoareAchizitie;
            _valoareTotalaVanzare += valoareVanzare;
            _totalProduse += med.Cantitate;
        }
    }

    public void AfiseazaRaportFinal()
    {
        decimal profitBrut = _valoareTotalaVanzare - _valoareTotalaAchizitie;
        decimal marjaMedie = _valoareTotalaAchizitie > 0
            ? (profitBrut / _valoareTotalaAchizitie) * 100
            : 0;

        Console.WriteLine($"\n    [Auditor Financiar] ═══ RAPORT FINANCIAR ═══");
        Console.WriteLine($"      Total produse in stoc: {_totalProduse}");
        Console.WriteLine($"      Valoare achizitie totala: {_valoareTotalaAchizitie:F2} RON");
        Console.WriteLine($"      Valoare vanzare totala: {_valoareTotalaVanzare:F2} RON");
        Console.WriteLine($"      Profit brut potential: {profitBrut:F2} RON");
        Console.WriteLine($"      Marja medie: {marjaMedie:F1}%");
    }
}

// ConcreteVisitor 2 - Inspector sanitar
// Verifica conditiile de depozitare, temperaturi, date expirare
public class InspectorSanitar : IVizitatorFarmacie
{
    public string NumeVizitator => "Inspector Sanitar";
    private readonly List<string> _neconformitati = new();
    private int _totalVerificari = 0;

    public void Viziteaza(RaftMedicamente raft)
    {
        Console.WriteLine($"    [Inspector Sanitar] Inspectie: {raft.NumeElement}");
        _totalVerificari++;

        foreach (var med in raft.Medicamente)
        {
            if (med.EsteExpirat())
            {
                string neconf = $"EXPIRAT: '{med.Nume}' pe raftul '{raft.NumeRaft}' (expirat la {med.DataExpirare:dd.MM.yyyy})";
                _neconformitati.Add(neconf);
                Console.WriteLine($"      ✗ {neconf}");
            }
            else if (med.ExpiraInCurand())
            {
                Console.WriteLine($"      ⚠ ATENTIE: '{med.Nume}' expira in curand ({med.DataExpirare:dd.MM.yyyy})");
            }
            else
            {
                Console.WriteLine($"      ✓ '{med.Nume}' - data expirare OK ({med.DataExpirare:dd.MM.yyyy})");
            }
        }
    }

    public void Viziteaza(FrigiderMedicamente frigider)
    {
        Console.WriteLine($"    [Inspector Sanitar] Inspectie: {frigider.NumeElement}");
        _totalVerificari++;

        // Verificare temperatura
        if (frigider.TemperaturaConforma())
        {
            Console.WriteLine($"      ✓ Temperatura: {frigider.TemperaturaActuala}°C (interval acceptabil: {frigider.TemperaturaMinima}-{frigider.TemperaturaMaxima}°C)");
        }
        else
        {
            string neconf = $"TEMPERATURA NECONFORMA: Frigider '{frigider.NumeFrigider}' la {frigider.TemperaturaActuala}°C (necesar: {frigider.TemperaturaMinima}-{frigider.TemperaturaMaxima}°C)";
            _neconformitati.Add(neconf);
            Console.WriteLine($"      ✗ {neconf}");
        }

        // Verificare medicamente
        foreach (var med in frigider.Medicamente)
        {
            if (med.EsteExpirat())
            {
                string neconf = $"EXPIRAT in frigider: '{med.Nume}' (expirat la {med.DataExpirare:dd.MM.yyyy})";
                _neconformitati.Add(neconf);
                Console.WriteLine($"      ✗ {neconf}");
            }
            else
            {
                Console.WriteLine($"      ✓ '{med.Nume}' - conditii depozitare conforme");
            }
        }
    }

    public void Viziteaza(SeifStudefiante seif)
    {
        Console.WriteLine($"    [Inspector Sanitar] Inspectie: {seif.NumeElement}");
        _totalVerificari++;

        // Verificare securitate
        Console.WriteLine($"      Nivel securitate: {seif.NivelSecuritate}");
        Console.WriteLine($"      Farmacist responsabil: {seif.FarmacistResponsabil}");
        Console.WriteLine($"      Ultima verificare: {seif.UltimaVerificare:dd.MM.yyyy HH:mm}");

        // Verificare daca ultima verificare este recenta (max 7 zile)
        var zileDeLaVerificare = (DateTime.Now - seif.UltimaVerificare).TotalDays;
        if (zileDeLaVerificare > 7)
        {
            string neconf = $"VERIFICARE INTARZIATA: Seiful nu a fost verificat de {zileDeLaVerificare:F0} zile (maxim 7 zile)";
            _neconformitati.Add(neconf);
            Console.WriteLine($"      ✗ {neconf}");
        }
        else
        {
            Console.WriteLine($"      ✓ Verificare recenta ({zileDeLaVerificare:F0} zile in urma)");
        }

        foreach (var med in seif.Medicamente)
        {
            Console.WriteLine($"      ✓ '{med.Nume}' - {med.Cantitate} unitati - inregistrat corect");
        }
    }

    public void AfiseazaRaportFinal()
    {
        Console.WriteLine($"\n    [Inspector Sanitar] ═══ RAPORT INSPECTIE SANITARA ═══");
        Console.WriteLine($"      Total puncte inspectate: {_totalVerificari}");
        Console.WriteLine($"      Neconformitati gasite: {_neconformitati.Count}");

        if (_neconformitati.Count > 0)
        {
            Console.WriteLine($"      --- Lista neconformitati ---");
            for (int i = 0; i < _neconformitati.Count; i++)
            {
                Console.WriteLine($"        {i + 1}. {_neconformitati[i]}");
            }
            Console.WriteLine($"      VERDICT: ✗ NECONFORM - actiuni corective necesare!");
        }
        else
        {
            Console.WriteLine($"      VERDICT: ✓ CONFORM - toate conditiile sunt indeplinite.");
        }
    }
}

// ConcreteVisitor 3 - Analist stoc
// Analizeaza nivelurile de stoc, identifica produse sub prag minim si sugereaza reaprovizionari
public class AnalistStoc : IVizitatorFarmacie
{
    public string NumeVizitator => "Analist Stoc";
    private readonly int _pragMinim;
    private readonly List<string> _sugestiiReaprovizionare = new();
    private int _totalArticole = 0;
    private int _articoleSubPrag = 0;

    public AnalistStoc(int pragMinim = 20)
    {
        _pragMinim = pragMinim;
    }

    public void Viziteaza(RaftMedicamente raft)
    {
        Console.WriteLine($"    [Analist Stoc] Analiza: {raft.NumeElement}");

        foreach (var med in raft.Medicamente)
        {
            _totalArticole++;
            if (med.Cantitate < _pragMinim)
            {
                _articoleSubPrag++;
                int cantitateRecomandata = _pragMinim * 3;
                _sugestiiReaprovizionare.Add($"'{med.Nume}' - stoc actual: {med.Cantitate}, recomandat comanda: {cantitateRecomandata} buc");
                Console.WriteLine($"      ⚠ STOC SCAZUT: '{med.Nume}' - {med.Cantitate} buc (sub pragul de {_pragMinim})");
            }
            else
            {
                Console.WriteLine($"      ✓ '{med.Nume}' - {med.Cantitate} buc (OK)");
            }
        }
    }

    public void Viziteaza(FrigiderMedicamente frigider)
    {
        Console.WriteLine($"    [Analist Stoc] Analiza: {frigider.NumeElement}");

        foreach (var med in frigider.Medicamente)
        {
            _totalArticole++;
            if (med.EsteExpirat())
            {
                Console.WriteLine($"      ✗ '{med.Nume}' - EXPIRAT - necesita eliminare si inlocuire");
                _sugestiiReaprovizionare.Add($"'{med.Nume}' - URGENT: inlocuire stoc expirat, comanda: {_pragMinim * 2} buc");
                _articoleSubPrag++;
            }
            else if (med.Cantitate < _pragMinim)
            {
                _articoleSubPrag++;
                int cantitateRecomandata = _pragMinim * 2; // medicamente refrigerate = comanda mai mica dar mai frecventa
                _sugestiiReaprovizionare.Add($"'{med.Nume}' (refrigerat) - stoc actual: {med.Cantitate}, recomandat comanda: {cantitateRecomandata} buc");
                Console.WriteLine($"      ⚠ STOC SCAZUT: '{med.Nume}' - {med.Cantitate} buc (refrigerat, sub pragul de {_pragMinim})");
            }
            else
            {
                Console.WriteLine($"      ✓ '{med.Nume}' - {med.Cantitate} buc (OK)");
            }
        }
    }

    public void Viziteaza(SeifStudefiante seif)
    {
        Console.WriteLine($"    [Analist Stoc] Analiza: {seif.NumeElement}");

        int pragStudefiante = 5; // pragul minim pentru stupefiante este mai mic
        foreach (var med in seif.Medicamente)
        {
            _totalArticole++;
            if (med.Cantitate < pragStudefiante)
            {
                _articoleSubPrag++;
                _sugestiiReaprovizionare.Add($"'{med.Nume}' (stupefiant) - stoc actual: {med.Cantitate}, recomandat comanda: {pragStudefiante * 2} buc (necesita aprobare speciala)");
                Console.WriteLine($"      ⚠ STOC SCAZUT: '{med.Nume}' - {med.Cantitate} buc (sub pragul de {pragStudefiante} pentru stupefiante)");
            }
            else
            {
                Console.WriteLine($"      ✓ '{med.Nume}' - {med.Cantitate} buc (OK)");
            }
        }
    }

    public void AfiseazaRaportFinal()
    {
        Console.WriteLine($"\n    [Analist Stoc] ═══ RAPORT ANALIZA STOC ═══");
        Console.WriteLine($"      Total articole analizate: {_totalArticole}");
        Console.WriteLine($"      Articole sub prag minim: {_articoleSubPrag}");
        Console.WriteLine($"      Procent stoc OK: {(_totalArticole > 0 ? ((_totalArticole - _articoleSubPrag) * 100.0 / _totalArticole) : 0):F1}%");

        if (_sugestiiReaprovizionare.Count > 0)
        {
            Console.WriteLine($"      --- Sugestii reaprovizionare ---");
            for (int i = 0; i < _sugestiiReaprovizionare.Count; i++)
            {
                Console.WriteLine($"        {i + 1}. {_sugestiiReaprovizionare[i]}");
            }
        }
        else
        {
            Console.WriteLine($"      Toate stocurile sunt la nivel optim.");
        }
    }
}
