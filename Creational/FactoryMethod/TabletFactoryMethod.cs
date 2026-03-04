using TMPP.Models;

namespace TMPP.Creational.FactoryMethod;

public class TabletFactoryMethod : BaseMedicineFactoryMethod
{
    protected override BaseMedicine CreateMedicine(string medicineName)
    {
        return new Tablet
        {
            Name = medicineName,
            Manufacturer = "PharmaCorp",
            Dosage = 500
        };
    }
}
