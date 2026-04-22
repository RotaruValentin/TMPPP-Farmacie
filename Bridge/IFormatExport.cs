namespace TMPP.Structural.Bridge;

// Implementation - interfata pentru formatul de export.
// Aceasta este partea "implementare" din Bridge, separata de abstractie.
public interface IFormatExport
{
    string NumeFormat { get; }
    void ExportaAntet(string titlu);
    void ExportaLinie(string cheie, string valoare);
    void ExportaTabel(string[] coloane, List<string[]> randuri);
    void ExportaFinal();
}
