using Business.Mediator;
using DataContracts;

namespace Mediator;

public interface IMediator
{
    void Notify(
        object sender,
        Interactions interaction, 
        string? name = null, 
        string? password = null, 
        Enums.AccessRoles? role = null);
}