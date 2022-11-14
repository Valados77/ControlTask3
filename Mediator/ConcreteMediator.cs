using Mediator.Components;
using Business;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Mediator;

public class ConcreteMediator : IMediator
{
    private bool disposed = false;

    private DataFacade dataFacade;
    private SubscribeTo _subscribeTo;

    public ConcreteMediator(SubscribeTo subscribeTo)
    {
        _subscribeTo = subscribeTo;
        _subscribeTo.SetMediator(this);
        ;
    }

    public void Notify(object sender, string ev)
    {
        if (ev == "new action")
        {
            Console.WriteLine("Add new action.");
        }
    }
}