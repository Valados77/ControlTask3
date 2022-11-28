using Business.Mediator;

namespace Business.BusinessObjects;

public class UserBusinessObject : BaseComponent
{
    public UserData? DoLoginUser(string? name, string? password)
    {
        return (UserData)Mediator.Notify(this,
            Interactions.DoLoginUser, 
            name, password)!;
    }

    public UserData? DoLogoutUser()
    {
        return (UserData)Mediator.Notify(this,
            Interactions.DoLogoutUser)!;
    }

    public List<ProjectData> DoGetAllProjectForUser()
    {
        return (List<ProjectData>)Mediator.Notify(this,
            Interactions.DoGetAllProjectForUser)!;
    }

    public DateTime DoGetSubmitDateTime(string name)
    {
        return (DateTime)Mediator.Notify(this,
            Interactions.DoGetSubmitDateTime,
            name)!;
    }

    public string DoSetViewingDateTime(string name)
    {
        return (string)Mediator.Notify(this,
            Interactions.DoSetViewingDateTime,
            name)!;
    }
}