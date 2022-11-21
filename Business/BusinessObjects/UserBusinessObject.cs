using Business;
using Mediator.Components;

namespace Business.BusinessObjects;

public class UserBusinessObject : BaseComponent
{
    public void DoLoginUser()
    {
        this._mediator.Notify(this, "DoLoginUser");
    }

    public void DoLogoutUser()
    {
        this._mediator.Notify(this, "DoLogoutUser");
    }

    public void DoReturnAllProjectForUser()
    {
        this._mediator.Notify(this, "DoReturnAllProjectForUser");
        //return DataFacadeInteraction.ReturnAllProject();
    }

    public void DoReturnSubmitDateTime()
    {
        this._mediator.Notify(this, "DoReturnSubmitDateTime");
        //return projectData.Project!.SubmitDateTime;
    }

    public void DoSetViewingDateTime()
    {
        this._mediator.Notify(this, "DoSetViewingDateTime");
        //projectData.Project.ViewingDateTime.Add(DateTime.Now);
    }
}