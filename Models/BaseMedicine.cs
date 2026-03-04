using TMPP.Creational.Prototype;

namespace TMPP.Models;

public abstract class BaseMedicine : IPrototype
{
    public required string Name { get; set; }
    public required string Manufacturer { get; set; }

    public abstract IPrototype Clone();
}

public class Tablet : BaseMedicine
{
    public int Dosage { get; set; }

    public override string ToString() => $"Tablet: {Name}, Dosage: {Dosage}mg, Manufacturer: {Manufacturer}";

    public override IPrototype Clone()
    {
        return (MemberwiseClone() as IPrototype)!;
    }
}

public class Syrup : BaseMedicine
{
    public bool RequiresPrescription { get; set; }

    public override string ToString() => $"Syrup: {Name}, RequiresPrescription: {RequiresPrescription}, Manufacturer: {Manufacturer}";

    public override IPrototype Clone()
    {
        return (MemberwiseClone() as IPrototype)!;
    }
}

public class Capsule : BaseMedicine
{
    public int Quantity { get; set; }

    public static Capsule GetDefault() => new() { Quantity = 0, Manufacturer = string.Empty, Name = string.Empty };

    public override string ToString()
    {
        return $"Capsule: {Name}, Quantity: {Quantity}, Manufacturer: {Manufacturer}";
    }

    public override IPrototype Clone()
    {
        return (MemberwiseClone() as IPrototype)!;
    }
}
