using DataContracts;

namespace Business.Mediator;

public interface IMediator
{
    object? Notify(
        Interactions interaction, 
        string? name = null, 
        string? password = null, 
        Enums.AccessRoles role = Enums.AccessRoles.User);
}