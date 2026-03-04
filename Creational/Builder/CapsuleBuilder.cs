using TMPP.Models;

namespace TMPP.Creational.Builder;

public class CapsuleBuilder : ICapsuleBuilder
{
    private Capsule _capsule = Capsule.GetDefault();

    public Capsule Build()
    {
        var capsule = _capsule;
        _capsule = Capsule.GetDefault();
        return capsule;
    }

    public ICapsuleBuilder SetName(string name)
    {
        _capsule.Name = name;
        return this;
    }

    public ICapsuleBuilder SetManufacturer(string manufacturer)
    {
        _capsule.Manufacturer = manufacturer;
        return this;
    }

    public ICapsuleBuilder SetQuantity(int quantity)
    {
        _capsule.Quantity = quantity;
        return this;
    }
}
