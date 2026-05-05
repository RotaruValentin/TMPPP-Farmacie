using System;

namespace TMPP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        TMPP.Structural.Adapter.AdapterUsing.Run();
        TMPP.Structural.Composite.CompositeUsing.Run();
        TMPP.Structural.Facade.FacadeUsing.Run();
        TMPP.Structural.Flyweight.FlyweightUsing.Run();
        TMPP.Structural.Decorator.DecoratorUsing.Run();
        TMPP.Structural.Bridge.BridgeUsing.Run();
        TMPP.Structural.Proxy.ProxyUsing.Run();

        // Behavioral Patterns
        TMPP.Behavioral.Strategy.StrategyUsing.Run();
        TMPP.Behavioral.Observer.ObserverUsing.Run();
        TMPP.Behavioral.Command.CommandUsing.Run();
        TMPP.Behavioral.Memento.MementoUsing.Run();
        TMPP.Behavioral.Iterator.IteratorUsing.Run();

        // Behavioral Patterns - Part 2
        TMPP.Behavioral.ChainOfResponsibility.ChainOfResponsibilityUsing.Run();
        TMPP.Behavioral.State.StateUsing.Run();
        TMPP.Behavioral.Mediator.MediatorUsing.Run();
        TMPP.Behavioral.TemplateMethod.TemplateMethodUsing.Run();
        TMPP.Behavioral.Visitor.VisitorUsing.Run();
    }
}
