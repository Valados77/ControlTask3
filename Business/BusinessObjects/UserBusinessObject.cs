using Business;
using Business.Mediator;
using Mediator.Components;

namespace Business.BusinessObjects;

public class UserBusinessObject : BaseComponent
{
    public void DoLoginUser(string name, string password)
    {
        this._mediator.Notify(
            Interactions.DoLoginUser, 
            name, password);
    }

    public void DoLogoutUser()
    {
        this._mediator.Notify( 
            Interactions.DoLogoutUser);
    }

    public void DoGetAllProjectForUser()
    {
        this._mediator.Notify(
            Interactions.DoGetAllProjectForUser);
    }

    public void DoGetSubmitDateTime(string name)
    {
        this._mediator.Notify(
            Interactions.DoGetSubmitDateTime,
            name);
    }

    public void DoSetViewingDateTime(string name)
    {
        this._mediator.Notify( Interactions.DoSetViewingDateTime,
            name);
    }
}