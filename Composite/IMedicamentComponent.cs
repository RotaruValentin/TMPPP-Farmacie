namespace TMPP.Structural.Composite;

// Componenta de baza - interfata comuna pentru medicamente individuale si grupuri
public interface IMedicamentComponent
{
    string Name { get; }
    decimal Price { get; }
    void Display(int depth = 0);
}
