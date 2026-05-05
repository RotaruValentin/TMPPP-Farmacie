namespace TMPP.Behavioral.Visitor;

// Visitor - interfata pentru toti vizitatorii care pot inspecta elementele farmaciei.
// Fiecare vizitator implementeaza o operatie diferita pe aceleasi elemente (double dispatch).
public interface IVizitatorFarmacie
{
    string NumeVizitator { get; }
    void Viziteaza(RaftMedicamente raft);
    void Viziteaza(FrigiderMedicamente frigider);
    void Viziteaza(SeifStudefiante seif);
}

// Element - interfata pentru elementele farmaciei care pot fi vizitate
public interface IElementFarmacie
{
    string NumeElement { get; }
    void Accepta(IVizitatorFarmacie vizitator);
}
