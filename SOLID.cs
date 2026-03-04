namespace TMPP;

public class Solid
{
    // 1. Single Responsibility Principle (SRP)
    public class MedicineRepository
    {
        public void SaveMedicine(string medicine)
        {
        }
    }

    public class MedicineValidator
    {
        public bool Validate(string medicine)
        {
            return true;
        }
    }

    // 2. Open/Closed Principle (OCP)
    public abstract class MedicinePricing
    {
        public abstract decimal GetPrice();
    }

    public class StandardPricing : MedicinePricing
    {
        public override decimal GetPrice() => 100m;
    }

    public class DiscountedPricing : MedicinePricing
    {
        public override decimal GetPrice() => 80m;
    }

    // 3. Liskov Substitution Principle (LSP)
    public abstract class Medicine
    {
        public abstract void Administer();
    }

    public class OralMedicine : Medicine
    {
        public override void Administer()
        {
        }
    }

    public class InjectableMedicine : Medicine
    {
        public override void Administer()
        {
        }
    }

    // 4. Interface Segregation Principle (ISP)
    public interface IPrescribable
    {
        void Prescribe();
    }

    public interface IRefillable
    {
        void Refill();
    }

    public class PrescriptionMedicine : IPrescribable, IRefillable
    {
        public void Prescribe()
        {
        }

        public void Refill()
        {
        }
    }

    public class OverTheCounterMedicine : IPrescribable
    {
        public void Prescribe()
        {
        }
    }

    // 5. Dependency Inversion Principle (DIP)
    public interface IMedicineStorage
    {
        void Store(string medicine);
    }

    public class DatabaseStorage : IMedicineStorage
    {
        public void Store(string medicine)
        {
        }
    }

    public class PharmacyService
    {
        private readonly IMedicineStorage _storage;

        public PharmacyService(IMedicineStorage storage)
        {
            _storage = storage;
        }

        public void AddMedicine(string medicine)
        {
            _storage.Store(medicine);
        }
    }
}
