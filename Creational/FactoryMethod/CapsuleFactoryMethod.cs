using TMPP.Models;

namespace TMPP.Creational.FactoryMethod;

public class CapsuleFactoryMethod : BaseMedicineFactoryMethod
{
    protected override BaseMedicine CreateMedicine(string medicineName)
    {
        return new Capsule
        {
            Name = medicineName,
            Manufacturer = "HealthPlus",
            Quantity = 100
        };
    }
}
