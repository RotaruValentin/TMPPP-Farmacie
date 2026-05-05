namespace TMPP.Behavioral.State;

// State - interfata pentru toate starile posibile ale unei comenzi de medicamente.
// Fiecare stare defineste ce actiuni sunt permise si cum se comporta comanda.
public interface IStareComanda
{
    string NumeStare { get; }
    void Verifica(ComandaMedicamente comanda);
    void Pregateste(ComandaMedicamente comanda);
    void Livreaza(ComandaMedicamente comanda);
    void Anuleaza(ComandaMedicamente comanda);
}
