using Business.Mediator;

namespace Business.BusinessObjects;

public class UserBusinessObject : BaseComponent
{
    public UserData? DoLoginUser(string? name, string? password)
    {
        return (UserData)Mediator.Notify(
            Interactions.DoLoginUser, 
            name, password)!;
    }

    public UserData? DoLogoutUser()
    {
        return (UserData)Mediator.Notify(
            Interactions.DoLogoutUser)!;
    }

    public List<ProjectData> DoGetAllProjectForUser()
    {
        return (List<ProjectData>)Mediator.Notify(
            Interactions.DoGetAllProjectForUser)!;
    }

    public DateTime DoGetSubmitDateTime(string name)
    {
        return (DateTime)Mediator.Notify(
            Interactions.DoGetSubmitDateTime,
            name)!;
    }

    public string DoSetViewingDateTime(string name)
    {
        return (string)Mediator.Notify(
            Interactions.DoSetViewingDateTime,
            name)!;
    }
}