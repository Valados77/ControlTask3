using Business.BusinessObjects;
using DataContracts;

namespace Business.Mediator;

public class ConcreteMediator : IMediator
{
    private readonly DataFacade _dataFacade;

    public ConcreteMediator(
        DataFacade dataFacade,
        SubscribeTo subscribeTo,
        AdminBusinessObject adminBusinessObject,
        LeaderBusinessObject leaderBusinessObject,
        UserBusinessObject userBusinessObject)
    {
        _dataFacade = dataFacade;
        _dataFacade.SetMediator(this);
        subscribeTo.SetMediator(this);
        adminBusinessObject.SetMediator(this);
        leaderBusinessObject.SetMediator(this);
        userBusinessObject.SetMediator(this);
    }

    public object? Notify(object sender,
        Interactions interaction,
        string? name = null,
        string? password = null,
        Enums.AccessRoles role = Enums.AccessRoles.User)
    {
        switch (interaction)
        {
            case Interactions.DoLoginUser:
                return _dataFacade.LoginUserData(name, password);
            // returns UserData
            case Interactions.DoLogoutUser:
                return _dataFacade.LogoutUserData();
            // returns UserData
            case Interactions.DoGetAllProjectForUser:
                return _dataFacade.GetAllProject();
            // returns List<ProjectData>
            case Interactions.DoGetSubmitDateTime:
                return _dataFacade.GetSubmitDateTime(
                            _dataFacade.GetProjectDataByName(name)!);
            // returns DateTime
            case Interactions.DoSetViewingDateTime:
                return _dataFacade.SetViewingDateTime(
                     _dataFacade.GetProjectDataByName(name)!);
            // returns string
            case Interactions.DoGetMaxHoursPerMonth:
                return _dataFacade.GetMaxHoursPerMonth(
                    _dataFacade.GetProjectDataByName(name)!);
            // returns int
            case Interactions.DoSetMaxHoursPerMonth:
                int.TryParse(password, out var hours);
                return _dataFacade.SetMaxHoursPerMonth(
                        _dataFacade.GetProjectDataByName(name)!,
                        hours);
            // returns string
            case Interactions.DoCreateUserData:
                return _dataFacade.AddNewUserData(name!, password!, role);
            // returns string
            case Interactions.DoCreateProjectData:
                return _dataFacade.AddNewProjectData(name!);
            // returns string
            case Interactions.DoReadUserDataById: //id = name
                return _dataFacade.GetUserDataById(name);
            // returns UserData
            case Interactions.DoReadProjectDataById: //id = name
                return _dataFacade.GetProjectDataById(name);
            // returns ProjectData
            case Interactions.DoDeleteUserDataById: //id = name
                return _dataFacade.DeleteUserDataById(name);
            // returns bool
            case Interactions.DoDeleteProjectDataById: //id = name
                return _dataFacade.DeleteProjectDataById(name);
            // returns bool
            case Interactions.DoAssignProjectForUser:
                //userName = name, projectName = password
                return _dataFacade.AssignProjectForUser(
                    _dataFacade.GetUserDataByName(name)!,
                    _dataFacade.GetProjectDataByName(password)!);
            // returns string
            case Interactions.DoAssignProjectLeader:
                //userName = name, projectName = password
                return _dataFacade.AssignProjectLeader(
                    _dataFacade.GetUserDataByName(name)!,
                    _dataFacade.GetProjectDataByName(password)!);
                // returns string
            default:
                return null;
        }
    }
}