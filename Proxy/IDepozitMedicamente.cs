namespace TMPP.Structural.Proxy;

// Subject - interfata comuna pentru accesul la depozitul de medicamente
public interface IDepozitMedicamente
{
    string ElibereazaMedicament(string numeMedicament, int cantitate);
    List<string> VeziMedicamenteDisponibile();
}
