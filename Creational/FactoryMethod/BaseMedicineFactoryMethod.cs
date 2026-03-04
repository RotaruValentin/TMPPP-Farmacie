using System;
using TMPP.Models;

namespace TMPP.Creational.FactoryMethod;

public abstract class BaseMedicineFactoryMethod
{
    protected abstract BaseMedicine CreateMedicine(string medicineName);

    public void PrintANewMedicine()
    {
        BaseMedicine medicine = CreateMedicine("My Medicine");
        Console.WriteLine($"Created a {medicine.Manufacturer} medicine named {medicine.Name}.");
    }
}