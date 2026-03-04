using TMPP.Models;

namespace TMPP.Creational.AbstractFactory;

public class TabletFactory : IMedicineFactory
{
    public BaseMedicine CreateMedicine(string medicineName)
    {
        return new Tablet
        {
            Name = medicineName,
            Manufacturer = "PharmaCorp",
            Dosage = 500
        };
    }
}
