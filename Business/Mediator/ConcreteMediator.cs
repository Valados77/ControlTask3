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
        _dataFacade.SetMediator(this);
        _subscribeTo = subscribeTo;
        _subscribeTo.SetMediator(this);
        _adminBusinessObject = adminBusinessObject;
        _adminBusinessObject.SetMediator(this);
        _leaderBusinessObject = leaderBusinessObject;
        _leaderBusinessObject.SetMediator(this);
        _userBusinessObject = userBusinessObject;
        _userBusinessObject.SetMediator(this);
    }

    public void Notify(object sender,
        Interactions interaction, 
        string? name = null,
        string? password = null,
        Enums.AccessRoles? role = null)
    {
        switch (interaction)
        {
            case Interactions.DoLoginUser:
                _dataFacade.LoginUserData(name, password);
                break;
            case Interactions.DoLogoutUser:
                _dataFacade.LogoutUserData();
                break;
            case Interactions.DoReturnAllProjectForUser:
                _dataFacade.ReturnAllProject();
                break;
            case Interactions.DoReturnSubmitDateTime:
                var submitDateTime =
                        _dataFacade.ReturnSubmitDateTime(
                            _dataFacade.ReturnProjectDataByName(name));
                break;
            case Interactions.DoSetViewingDateTime:
                _dataFacade.SetViewingDateTime(
                    _dataFacade.ReturnProjectDataByName(name));
                break;
            case Interactions.DoReturnMaxHoursPerMonth:
                _dataFacade.ReturnMaxHoursPerMonth(
                    _dataFacade.ReturnProjectDataByName(name));
                break;
            case Interactions.DoSetMaxHoursPerMonth: 
                var hours = int.Parse(password);
                _dataFacade.SetMaxHoursPerMonth(
                    _dataFacade.ReturnProjectDataByName(name),
                    hours);
                break;
            case Interactions.DoCreateUserData:
                _dataFacade.AddNewUserData(name, password, role);
                break;
            case Interactions.DoCreateProjectData:
                _dataFacade.AddNewProjectData(name);
                break;
            case Interactions.DoReadUserDataById: //id = name
                _dataFacade.ReturnUserDataById(name);
                break;
            case Interactions.DoReadProjectDataById: //id = name
                _dataFacade.ReturnProjectDataById(name);
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
                    _dataFacade.ReturnUserDataByName(name),
                    _dataFacade.ReturnProjectDataByName(password));
                break;
            case Interactions.DoAssignProjectLeader:
                //userName = name, projectName = password
                _dataFacade.AssignProjectLeader(
                    _dataFacade.ReturnUserDataByName(name), 
                    _dataFacade.ReturnProjectDataByName(password));
                break;
        }
    }
}