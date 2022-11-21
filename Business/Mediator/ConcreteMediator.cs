using Mediator.Components;
using Business;
using Business.BusinessObjects;
using DataContracts;

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

    public void Notify(object sender, string ev)
    {
        string? name;
        switch (ev)
        {
            case "DoLoginUser":
                _dataFacade.LoginUserData("test", "test");
                break;
            case "DoLogoutUser":
                _dataFacade.LogoutUserData();
                break;
            case "DoReturnAllProjectForUser":
                _dataFacade.ReturnAllProject();
                break;
            case "DoReturnSubmitDateTime":
                Console.WriteLine("Input project name: ");
                name = Console.ReadLine();
                if (name != null)
                {
                    var submitDateTime =
                        _dataFacade.ReturnSubmitDateTime(_dataFacade.ReturnProjectDataByName(name));
                }

                break;
            case "DoSetViewingDateTime":
                Console.WriteLine("Input project name: ");
                name = Console.ReadLine();
                if (name != null)
                {
                    _dataFacade.SetViewingDateTime(_dataFacade.ReturnProjectDataByName(name));
                }
                break;
            case "DoReturnMaxHoursPerMonth":
                Console.WriteLine("Input project name: ");
                name = Console.ReadLine();
                if (name != null)
                {
                    _dataFacade.ReturnMaxHoursPerMonth(_dataFacade.ReturnProjectDataByName(name));
                }
                break;
            case "DoSetMaxHoursPerMonth":
                Console.WriteLine("Input project name: ");
                name = Console.ReadLine();
                Console.WriteLine("Input max hours");
                var hours = 0;
                int.TryParse(Console.ReadLine(), out hours); 
                if (name != null)
                {
                    _dataFacade.SetMaxHoursPerMonth(_dataFacade.ReturnProjectDataByName(name), hours);
                }
                break;
            case "DoCreateUserData":
                _dataFacade.AddNewUserData("test", "test", Enums.AccessRoles.User);
                break;
            case "DoCreateProjectData":
                _dataFacade.AddNewProjectData("test");
                break;
            case "DoReadUserData":
                _dataFacade.ReturnUserDataById("0001U");
                break;
            case "DoReadProjectData":
                _dataFacade.ReturnProjectDataById("0001P");
                break;
            case "DoDeleteUserData":
                _dataFacade.DeleteUserData("0001U");
                break;
            case "DoDeleteProjectData":
                _dataFacade.DeleteProjectData("0001P");
                break;
            case "DoAssignProjectForUser":
                _dataFacade.AssignProjectForUser(
                    _dataFacade.ReturnUserDataByName("test"),
                    _dataFacade.ReturnProjectDataByName("test"));
                break;
            case "DoAssignProjectLeader":
                _dataFacade.AssignProjectLeader(
                    _dataFacade.ReturnUserDataByName("test"), 
                    _dataFacade.ReturnProjectDataByName("test"));
                break;
        }
    }
}