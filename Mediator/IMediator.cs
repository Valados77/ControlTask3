using Business.BusinessObjects;

namespace Mediator;

public interface IMediator
{
    void Notify(object sender, string ev);
}