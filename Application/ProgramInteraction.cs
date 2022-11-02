using Business;
using Business.BusinesObjects;
using DataContracts;
using DataContracts.DataObjects;

namespace Application;

public class ProgramInteraction
{
    public static DataFacade dataFacade = new DataFacade();

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
                    //Program.LoginingUser = DataFacade.LoginingUserData();
                    break;

            }
        } while (true);
        //---------------------------------------
    }

    public static bool RegisterNewUser()
    {
        Console.Write("Enter username: ");
        string userName = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Console.Write("Enter access role:\n" +
                      "0. Admin\n" +
                      "1. Leader\n" +
                      "2. User");
        Enums.AccessRoles role = new Enums.AccessRoles();
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
        dataFacade.AddNewUserData(userName, password, role);

        return true;
    }

    public static bool NewProjectData()
    {
        Console.Write("Enter project name: ");
        string projectName = Console.ReadLine();
       
        dataFacade.AddNewProjectData(projectName);

        return true;
    }

    public static UserData? LoginingUser()
    {
        Console.WriteLine("Enter username: ");
        string name = Console.ReadLine();
        UserData userData = dataFacade.ReturnUserData(name);

        if (userData != null)
        {
            Console.WriteLine("Login completed");
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (dataFacade.PasswordVerification(userData, password) == true)
            {
                Console.WriteLine("Password completed");
                return userData;
            }
        }
        Console.WriteLine("Invalid username or password");
        return null;
    }

    public static void Print(Dictionary<string, UserData> userData)
    {
        foreach (var user in userData)
        {
            Console.WriteLine("User: {0}", user.Value.User.Username);
            Console.WriteLine("---------------------------------");
            if (user.Value.submittedTime.Any())
            {
                foreach (var timeTrackEntry in user.Value.submittedTime)
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

    public static void Print(Dictionary<string, ProjectData> projectDatas)
    {
        foreach (var project in projectDatas)
        {
            Console.WriteLine("Project: {0}", project.Value.Project.Name);
            Console.WriteLine("---------------------------------");
            if (project.Value.employeesList.Any())
            {
                foreach (var employ in project.Value.employeesList)
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

    