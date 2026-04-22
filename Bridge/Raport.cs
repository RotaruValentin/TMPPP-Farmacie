namespace TMPP.Structural.Bridge;

// Abstraction - clasa abstracta pentru rapoarte.
// Tine o referinta catre IFormatExport (implementarea) prin Bridge.
// Tipul raportului si formatul de export variaza INDEPENDENT unul de altul.
public abstract class Raport
{
    protected readonly IFormatExport _formatExport;

    protected Raport(IFormatExport formatExport)
    {
        _formatExport = formatExport;
    }

    // Metoda template care genereaza raportul folosind formatul de export injectat
    public abstract void Genereaza();
}

// RefinedAbstraction 1 - Raport de vanzari
public class RaportVanzari : Raport
{
    public RaportVanzari(IFormatExport formatExport) : base(formatExport) { }

    public override void Genereaza()
    {
        _formatExport.ExportaAntet("RAPORT VANZARI - Farmacie");
        _formatExport.ExportaLinie("Perioada", "01.04.2026 - 30.04.2026");
        _formatExport.ExportaLinie("Total Tranzactii", "145");
        _formatExport.ExportaLinie("Venit Total", "12,450.00 RON");

        _formatExport.ExportaTabel(
            ["Medicament", "Cantitate", "Venit"],
            [
                ["Ibuprofen 400mg", "52", "650.00 RON"],
                ["Paracetamol 500mg", "38", "304.00 RON"],
                ["Amoxicilina 500mg", "27", "945.00 RON"],
                ["Vitamina C 1000mg", "28", "420.00 RON"]
            ]);

        _formatExport.ExportaFinal();
    }
}

// RefinedAbstraction 2 - Raport de stoc
public class RaportStocMedicamente : Raport
{
    public RaportStocMedicamente(IFormatExport formatExport) : base(formatExport) { }

    public override void Genereaza()
    {
        _formatExport.ExportaAntet("RAPORT STOC MEDICAMENTE - Farmacie");
        _formatExport.ExportaLinie("Data Generarii", "22.04.2026");
        _formatExport.ExportaLinie("Total Produse", "4 tipuri");

        _formatExport.ExportaTabel(
            ["Medicament", "In Stoc", "Stoc Minim"],
            [
                ["Ibuprofen 400mg", "120", "50"],
                ["Paracetamol 500mg", "85", "40"],
                ["Amoxicilina 500mg", "30", "20"],
                ["Insulina NovoRapid", "15", "10"]
            ]);

        _formatExport.ExportaFinal();
    }
}
