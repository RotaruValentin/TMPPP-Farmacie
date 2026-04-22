namespace TMPP.Structural.Decorator;

// Component - interfata de baza pentru un serviciu de livrare medicamente
public interface IServiciuLivrare
{
    string GetDescriere();
    decimal GetCost();
}
