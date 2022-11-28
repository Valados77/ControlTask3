using Business;
using Business.BusinessObjects;
using Business.Mediator;
using DataContracts;

namespace Application;

public class ProgramInteraction
{
    public static UserData? _nowUserData;
    public static ProjectData? _nowProjectData;


    public static readonly DataFacade DataFacade = new DataFacade();
    public static readonly SubscribeTo SubscribeTo = new SubscribeTo(_nowUserData, _nowProjectData);
    public static readonly AdminBusinessObject AdminBusinessObject = new AdminBusinessObject();
    public static readonly LeaderBusinessObject LeaderBusinessObject = new LeaderBusinessObject();
    public static readonly UserBusinessObject UserBusinessObject = new UserBusinessObject();
    public static ConcreteMediator ConcreteMediatorInteraction = new ConcreteMediator(
        DataFacade,
        SubscribeTo,
        AdminBusinessObject,
        LeaderBusinessObject,
        UserBusinessObject);

    public static void Menu()
    {
        //TEST IMPLEMENTATION
        //---------------------------------------
        do
        {
            Console.WriteLine("Menu:\n" +
                              "0. New registration\n" +
                              "1. Logging\n" +
                              "2. Add new project\n" +
                              "3. Show a list of projects\n" +
                              "4. ");
            switch (Console.ReadLine())
            {
                case "1":
                    RegisterNewUser();
                    break;
                case "2":
                    //Program.LoginUser = DataFacadeInteraction.LoginingUserData();
                    break;

            }
        } while (true);
        //---------------------------------------
    }

    public static string RegisterNewUser()
    {
        Console.Write("Enter username: ");
        var userName = Console.ReadLine();
        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        Console.Write("Enter access role:\n" +
                      "0. Admin\n" +
                      "1. Leader\n" +
                      "2. User");
        var role = new Enums.AccessRoles();
        switch (Console.ReadLine())
        {
            case "0":
                Console.WriteLine("Role selected: Admin");
                role = Enums.AccessRoles.Admin;
                break;
            case "1":
                Console.WriteLine("Role selected: Leader");
                role = Enums.AccessRoles.Leader;
                break;
            case "2":
                Console.WriteLine("Role selected: User");
                role = Enums.AccessRoles.User;
                break;
            default:
                Console.WriteLine(
                    "Incorrectly selected value!" +
                    " Default role selected: User");
                role = Enums.AccessRoles.User;
                break;
        }
        return AdminBusinessObject.DoCreateUserData(userName, password, role);
    }

    public static void NewProjectData()
    {
        Console.Write("Enter project name: ");
        var projectName = Console.ReadLine();

        AdminBusinessObject.DoCreateProjectData(projectName);
    }

    public static void Print(List<UserData> userData)
    {
        foreach (var user in userData)
        {
            Console.WriteLine("User: {0}", user.User!.Username);
            Console.WriteLine("---------------------------------");
            if (user.SubmittedTime.Any())
            {
                foreach (var timeTrackEntry in user.SubmittedTime)
                {
                    Console.WriteLine(timeTrackEntry.Date);
                }
            }
            else
            {
                Console.WriteLine("Empty submitted time list");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
        }
    }

    public static void Print(List<ProjectData> projectData)
    {
        foreach (var project in projectData)
        {
            Console.WriteLine("Project: {0}", project.Project!.Name);
            Console.WriteLine("---------------------------------");
            if (project.EmployeesList.Any())
            {
                foreach (var employ in project.EmployeesList)
                {
                    Console.WriteLine(employ.Id);
                }
            }
            else
            {
                Console.WriteLine("Empty employees list");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
        }
    }
}