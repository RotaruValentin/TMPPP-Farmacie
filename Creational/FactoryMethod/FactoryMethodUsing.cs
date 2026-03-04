namespace TMPP.Creational.FactoryMethod;

public static class FactoryMethodUsing
{
    public static void Run()
    {
        BaseMedicineFactoryMethod medicineFactoryMethod = new CapsuleFactoryMethod();
        medicineFactoryMethod.PrintANewMedicine();

        medicineFactoryMethod = new SyrupFactoryMethod();
        medicineFactoryMethod.PrintANewMedicine();

        medicineFactoryMethod = new TabletFactoryMethod();
        medicineFactoryMethod.PrintANewMedicine();
    }
}
