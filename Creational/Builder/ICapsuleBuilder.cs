using TMPP.Models;

namespace TMPP.Creational.Builder;

public interface ICapsuleBuilder
{
    public Capsule Build();
    public ICapsuleBuilder SetName(string name);
    public ICapsuleBuilder SetManufacturer(string manufacturer);
    public ICapsuleBuilder SetQuantity(int quantity);
}