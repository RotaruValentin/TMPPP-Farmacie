using TMPP.Models;

namespace TMPP.Structural.Adapter;

// Interfata țintă pe care clientul o așteaptă
public interface IMedicineProvider
{
    BaseMedicine ProvideMedicine(string name);
}
