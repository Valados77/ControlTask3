using Mediator.Components;
using Business;
using Business.BusinessObjects;
using DataContracts;
using Business.Mediator;

namespace Mediator;

public class ConcreteMediator : IMediator
{
    private readonly DataFacade _dataFacade;
    private readonly SubscribeTo _subscribeTo;
    private AdminBusinessObject _adminBusinessObject;
    private LeaderBusinessObject _leaderBusinessObject;
    private UserBusinessObject _userBusinessObject;

    public ConcreteMediator(
        DataFacade dataFacade,
        SubscribeTo subscribeTo,
        AdminBusinessObject adminBusinessObject,
        LeaderBusinessObject leaderBusinessObject,
        UserBusinessObject userBusinessObject)
    {
        _dataFacade = dataFacade;
        _subscribeTo = subscribeTo;
        _adminBusinessObject = adminBusinessObject;
        _leaderBusinessObject = leaderBusinessObject;
        _userBusinessObject = userBusinessObject;
    }

    public void Notify(
        Interactions interaction, 
        string? name = null,
        string? password = null,
        Enums.AccessRoles role = Enums.AccessRoles.User)
    {
        switch (interaction)
        {
            case Interactions.DoLoginUser:
                _dataFacade.LoginUserData(name, password);
                break;
            case Interactions.DoLogoutUser:
                _dataFacade.LogoutUserData();
                break;
            case Interactions.DoGetAllProjectForUser:
                _dataFacade.GetAllProject();
                break;
            case Interactions.DoGetSubmitDateTime:
                var submitDateTime =
                        _dataFacade.GetSubmitDateTime(
                            _dataFacade.GetProjectDataByName(name));
                break;
            case Interactions.DoSetViewingDateTime:
                _dataFacade.SetViewingDateTime(
                    _dataFacade.GetProjectDataByName(name));
                break;
            case Interactions.DoGetMaxHoursPerMonth:
                _dataFacade.GetMaxHoursPerMonth(
                    _dataFacade.GetProjectDataByName(name));
                break;
            case Interactions.DoSetMaxHoursPerMonth: 
                var hours = int.Parse(password);
                _dataFacade.SetMaxHoursPerMonth(
                    _dataFacade.GetProjectDataByName(name),
                    hours);
                break;
            case Interactions.DoCreateUserData:
                _dataFacade.AddNewUserData(name, password, role);
                break;
            case Interactions.DoCreateProjectData:
                _dataFacade.AddNewProjectData(name);
                break;
            case Interactions.DoReadUserDataById: //id = name
                _dataFacade.GetUserDataById(name);
                break;
            case Interactions.DoReadProjectDataById: //id = name
                _dataFacade.GetProjectDataById(name);
                break;
            case Interactions.DoDeleteUserDataById: //id = name
                _dataFacade.DeleteUserDataById(name);
                break;
            case Interactions.DoDeleteProjectDataById: //id = name
                _dataFacade.DeleteProjectDataById(name);
                break;
            case Interactions.DoAssignProjectForUser:
                //userName = name, projectName = password
                _dataFacade.AssignProjectForUser(
                    _dataFacade.GetUserDataByName(name),
                    _dataFacade.GetProjectDataByName(password));
                break;
            case Interactions.DoAssignProjectLeader:
                //userName = name, projectName = password
                _dataFacade.AssignProjectLeader(
                    _dataFacade.GetUserDataByName(name), 
                    _dataFacade.GetProjectDataByName(password));
                break;
        }
    }
}