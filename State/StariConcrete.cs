namespace TMPP.Behavioral.State;

// ConcreteState 1 - Comanda este noua, asteapta verificarea
public class StareNoua : IStareComanda
{
    public string NumeStare => "Noua";

    public void Verifica(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareNoua] Verificare comanda #{comanda.IdComanda}...");
        Console.WriteLine($"    [StareNoua] Se verifica disponibilitatea pentru {comanda.Medicamente.Count} medicamente.");

        // Simulam verificarea
        bool toateDisponibile = true;
        foreach (var med in comanda.Medicamente)
        {
            Console.WriteLine($"      - '{med.Key}' x{med.Value}: disponibil ✓");
        }

        if (toateDisponibile)
        {
            Console.WriteLine($"    [StareNoua] Toate medicamentele sunt disponibile. Comanda verificata!");
            comanda.SchimbaStare(new StareVerificata());
        }
    }

    public void Pregateste(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareNoua] ✗ Nu se poate pregati - comanda trebuie verificata mai intai!");
    }

    public void Livreaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareNoua] ✗ Nu se poate livra - comanda trebuie verificata si pregatita mai intai!");
    }

    public void Anuleaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareNoua] Comanda #{comanda.IdComanda} anulata inainte de procesare.");
        comanda.SchimbaStare(new StareAnulata());
    }
}

// ConcreteState 2 - Comanda a fost verificata, poate fi pregatita
public class StareVerificata : IStareComanda
{
    public string NumeStare => "Verificata";

    public void Verifica(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareVerificata] ✗ Comanda #{comanda.IdComanda} a fost deja verificata.");
    }

    public void Pregateste(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareVerificata] Pregatire comanda #{comanda.IdComanda}...");
        Console.WriteLine($"    [StareVerificata] Farmacistul pregateste medicamentele:");

        foreach (var med in comanda.Medicamente)
        {
            Console.WriteLine($"      - Pregatit: '{med.Key}' x{med.Value} ✓");
        }

        Console.WriteLine($"    [StareVerificata] Comanda impachetata si gata de livrare!");
        comanda.SchimbaStare(new StarePredataCurier());
    }

    public void Livreaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareVerificata] ✗ Nu se poate livra - comanda trebuie pregatita mai intai!");
    }

    public void Anuleaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareVerificata] Comanda #{comanda.IdComanda} anulata. Medicamentele returnate in stoc.");
        comanda.SchimbaStare(new StareAnulata());
    }
}

// ConcreteState 3 - Comanda a fost pregatita si predata curierului
public class StarePredataCurier : IStareComanda
{
    public string NumeStare => "Predata Curier";

    public void Verifica(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StarePredataCurier] ✗ Comanda #{comanda.IdComanda} a fost deja verificata si pregatita.");
    }

    public void Pregateste(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StarePredataCurier] ✗ Comanda #{comanda.IdComanda} este deja pregatita.");
    }

    public void Livreaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StarePredataCurier] Livrare comanda #{comanda.IdComanda} la adresa: {comanda.AdresaLivrare}");
        Console.WriteLine($"    [StarePredataCurier] Confirmare primire de la client: {comanda.NumeClient}");
        Console.WriteLine($"    [StarePredataCurier] Comanda livrata cu succes!");
        comanda.SchimbaStare(new StareLivrata());
    }

    public void Anuleaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StarePredataCurier] ✗ Comanda #{comanda.IdComanda} nu mai poate fi anulata - este deja la curier!");
        Console.WriteLine($"    [StarePredataCurier] Contactati serviciul clienti pentru returnare dupa livrare.");
    }
}

// ConcreteState 4 - Comanda a fost livrata (stare finala)
public class StareLivrata : IStareComanda
{
    public string NumeStare => "Livrata";

    public void Verifica(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareLivrata] ✗ Comanda #{comanda.IdComanda} a fost deja livrata. Nu necesita verificare.");
    }

    public void Pregateste(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareLivrata] ✗ Comanda #{comanda.IdComanda} a fost deja livrata.");
    }

    public void Livreaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareLivrata] ✗ Comanda #{comanda.IdComanda} a fost deja livrata clientului.");
    }

    public void Anuleaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareLivrata] ✗ Comanda #{comanda.IdComanda} nu poate fi anulata - a fost deja livrata.");
        Console.WriteLine($"    [StareLivrata] Folositi procedura de returnare pentru medicamente nedesfacute.");
    }
}

// ConcreteState 5 - Comanda a fost anulata (stare finala)
public class StareAnulata : IStareComanda
{
    public string NumeStare => "Anulata";

    public void Verifica(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareAnulata] ✗ Comanda #{comanda.IdComanda} este anulata. Nu se poate verifica.");
    }

    public void Pregateste(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareAnulata] ✗ Comanda #{comanda.IdComanda} este anulata. Nu se poate pregati.");
    }

    public void Livreaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareAnulata] ✗ Comanda #{comanda.IdComanda} este anulata. Nu se poate livra.");
    }

    public void Anuleaza(ComandaMedicamente comanda)
    {
        Console.WriteLine($"    [StareAnulata] Comanda #{comanda.IdComanda} este deja anulata.");
    }
}
