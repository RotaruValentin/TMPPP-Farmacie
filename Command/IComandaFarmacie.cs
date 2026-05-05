namespace TMPP.Behavioral.Command;

// Command - interfata pentru toate comenzile executabile.
// Suporta Execute si Undo pentru a permite anularea operatiunilor.
public interface IComandaFarmacie
{
    string Descriere { get; }
    void Executa();
    void Anuleaza();
}
