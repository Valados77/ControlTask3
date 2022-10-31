using Business;
using Business.BusinesObjects;
using DataContracts;

namespace Application;

public class ProgramInteraction
{
    public static void Menu(DataFacade dataFacade)
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
                    RegisterNewUser(dataFacade);
                    break;
                case "2":
                    //Program.LoginingUser = DataFacade.LoginingUserData();
                    break;

            }
        } while (true);
        //---------------------------------------
    }

    public static bool RegisterNewUser(DataFacade dataFacade)
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

    public static bool NewProjectData(DataFacade dataFacade)
    {
        Console.Write("Enter project name: ");
        string projectName = Console.ReadLine();
       
        dataFacade.AddNewProjectData(projectName);

        return true;
    }

    public static UserData? LoginingUser(DataFacade dataFacade)
    {
        Console.WriteLine("Enter username: ");
        string name = Console.ReadLine();
        UserData userData = dataFacade.ReturnUserData(name);

        if (userData != null)
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (dataFacade.PasswordVerification(userData, password) == true)
            {
                Console.WriteLine("Login completed");
                return userData;
            }
        }
        Console.WriteLine("Invalid username or password");
        return null;
    }

    public static void Print(List<UserData> userData)
    {
        foreach (var user in userData)
        {
            Console.WriteLine("User: {0}", user.User.Username);
            Console.WriteLine("---------------------------------");
            foreach (var timeTrackEntry in user.SubmittedTime)
            {
                Console.WriteLine(timeTrackEntry.Date);
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
        }
    }

    public static void Print(List<ProjectData> projectDatas)
    {
        foreach (var project in projectDatas)
        {
            Console.WriteLine("Project: {0}", project.Project.Name);
            Console.WriteLine("---------------------------------");
            foreach (var employ in project.EmployeesList)
            {
                Console.WriteLine(employ.Id);
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
        }
    }
}

    