using System;
using TMPP.Models;

namespace TMPP.Structural.Adapter;

// Adaptorul face ca ExternalApiSupplier sa fie compatibil cu IMedicineProvider
public class ExternalMedicineAdapter : IMedicineProvider
{
    private readonly ExternalApiSupplier _externalApiSupplier;

    public ExternalMedicineAdapter(ExternalApiSupplier externalApiSupplier)
    {
        _externalApiSupplier = externalApiSupplier;
    }

    public BaseMedicine ProvideMedicine(string name)
    {
        // 1. Preluam datele folosind interfata incompatibila
        string rawData = _externalApiSupplier.GetMedicineData(name);

        // 2. Transformam datele procesandu-le pentru a obtine formatul "BaseMedicine" cerut de IMedicineProvider
        string[] parts = rawData.Split('|');
        if (parts.Length == 3)
        {
            return new Tablet
            {
                Name = parts[0],
                Manufacturer = parts[1],
                Dosage = int.Parse(parts[2])
            };
        }

        throw new Exception("Format de date invalid de la furnizorul extern.");
    }
}
