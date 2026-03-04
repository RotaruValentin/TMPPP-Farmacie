using TMPP.Models;

namespace TMPP.Creational.AbstractFactory;

public interface IMedicineFactory
{
    BaseMedicine CreateMedicine(string flowerName);
}