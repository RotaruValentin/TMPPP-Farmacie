using TMPP.Models;

namespace TMPP.Creational.AbstractFactory;

public class CapsuleFactory : IMedicineFactory
{
    public BaseMedicine CreateMedicine(string medicineName)
    {
        return new Capsule
        {
            Name = medicineName,
            Manufacturer = "HealthPlus",
            Quantity = 100
        };
    }
}
