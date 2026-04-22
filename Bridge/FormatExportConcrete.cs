namespace TMPP.Structural.Bridge;

// ConcreteImplementation 1 - export la consola cu formatare vizuala
public class FormatConsola : IFormatExport
{
    public string NumeFormat => "Consola";

    public void ExportaAntet(string titlu)
    {
        Console.WriteLine($"\n  ╔{'═'.ToString().PadRight(50, '═')}╗");
        Console.WriteLine($"  ║ {titlu.PadRight(49)}║");
        Console.WriteLine($"  ╚{'═'.ToString().PadRight(50, '═')}╝");
    }

    public void ExportaLinie(string cheie, string valoare)
    {
        Console.WriteLine($"  │ {cheie,-20}: {valoare}");
    }

    public void ExportaTabel(string[] coloane, List<string[]> randuri)
    {
        // Afiseaza rand de cap de tabel
        Console.Write("  │ ");
        foreach (var col in coloane)
            Console.Write($"{col,-18}");
        Console.WriteLine();
        Console.WriteLine($"  │ {new string('─', coloane.Length * 18)}");

        // Afiseaza fiecare rand de date
        foreach (var rand in randuri)
        {
            Console.Write("  │ ");
            foreach (var val in rand)
                Console.Write($"{val,-18}");
            Console.WriteLine();
        }
    }

    public void ExportaFinal()
    {
        Console.WriteLine($"  └{'─'.ToString().PadRight(50, '─')}┘");
    }
}

// ConcreteImplementation 2 - export in format CSV (Comma-Separated Values)
public class FormatCSV : IFormatExport
{
    public string NumeFormat => "CSV";

    public void ExportaAntet(string titlu)
    {
        Console.WriteLine($"\n  [CSV Output] # {titlu}");
    }

    public void ExportaLinie(string cheie, string valoare)
    {
        Console.WriteLine($"  {cheie},{valoare}");
    }

    public void ExportaTabel(string[] coloane, List<string[]> randuri)
    {
        Console.WriteLine($"  {string.Join(",", coloane)}");
        foreach (var rand in randuri)
        {
            Console.WriteLine($"  {string.Join(",", rand)}");
        }
    }

    public void ExportaFinal()
    {
        Console.WriteLine("  [CSV] # END");
    }
}

// ConcreteImplementation 3 - export in format HTML
public class FormatHTML : IFormatExport
{
    public string NumeFormat => "HTML";

    public void ExportaAntet(string titlu)
    {
        Console.WriteLine($"\n  <html><body>");
        Console.WriteLine($"  <h1>{titlu}</h1>");
    }

    public void ExportaLinie(string cheie, string valoare)
    {
        Console.WriteLine($"  <p><strong>{cheie}:</strong> {valoare}</p>");
    }

    public void ExportaTabel(string[] coloane, List<string[]> randuri)
    {
        Console.WriteLine("  <table border='1'>");
        Console.Write("    <tr>");
        foreach (var col in coloane)
            Console.Write($"<th>{col}</th>");
        Console.WriteLine("</tr>");

        foreach (var rand in randuri)
        {
            Console.Write("    <tr>");
            foreach (var val in rand)
                Console.Write($"<td>{val}</td>");
            Console.WriteLine("</tr>");
        }
        Console.WriteLine("  </table>");
    }

    public void ExportaFinal()
    {
        Console.WriteLine("  </body></html>");
    }
}
