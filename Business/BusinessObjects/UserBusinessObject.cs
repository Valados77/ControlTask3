using Business;
using Business.Mediator;
using Mediator.Components;

namespace Business.BusinessObjects;

public class UserBusinessObject : BaseComponent
{
    public void DoLoginUser(string name, string password)
    {
        this._mediator.Notify(this, Interactions.DoLoginUser, name, password);
    }

    public void DoLogoutUser()
    {
        this._mediator.Notify(this, Interactions.DoLogoutUser);
    }

    public void DoReturnAllProjectForUser()
    {
        this._mediator.Notify(this, Interactions.DoReturnAllProjectForUser);
    }

    public void DoReturnSubmitDateTime(string name)
    {
        this._mediator.Notify(this, Interactions.DoReturnSubmitDateTime, name);
    }

    public void DoSetViewingDateTime(string name)
    {
        this._mediator.Notify(this, Interactions.DoSetViewingDateTime, name);
    }
}