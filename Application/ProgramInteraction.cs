using Business.BusinesObjects;
using DataContracts;

namespace Application;

public class ProgramInteraction
{
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
                    User user = UserInteraction.Registration();
                    DataDictionaries.UserDictionary.Add(user.Id, user);
                    break;
                case "2":
                    //Program.LoginingUser = DataFacade.LoginingUserData();
                    break;

            }
        } while (true);
        //---------------------------------------
    }

    public static void RegisterNewUser()
    {
        User user = UserInteraction.Registration();
        DataDictionaries.UserDictionary.Add(user.Id, user);
        UserData userData = new UserData(user);
        userData.IsActiveChanged += DisplayMessage;
//        Program.dataFacade.dataList.userDataList.Add(userData);
    }

    public static User LoginingUser()
    {
        Console.WriteLine("Enter username: ");
        string name = Console.ReadLine();
        foreach (var i in DataDictionaries.UserDictionary.Values)
        {
            if (i.Username == name)
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                if (i.Password == password)
                {
                    Console.WriteLine("OK");
                    return i;
                }

            }
        }
        return new User("test", "test", Enums.AccessRoles.User);
    }

    //    public void Print(List<UserData> userData)
    //    {
    //        foreach (var user in userData)
    //        {
    //            Console.WriteLine("User: {0}", user.User.Username);
    //            Console.WriteLine("---------------------------------");
    //            foreach (var timeTrackEntry in user.SubmittedTime)
    //            {
    //                Console.WriteLine(timeTrackEntry.Date);
    //            }
    //            Console.WriteLine("---------------------------------");
    //            Console.WriteLine("---------------------------------");
    //        }
    //    }

    //public void Print(List<ProjectData> projectDatas)
    //{
    //    foreach (var project in projectDatas)
    //    {
    //        Console.WriteLine("Project: {0}", project.Project.Name);
    //        Console.WriteLine("---------------------------------");
    //        foreach (var employ in project.EmployeesList)
    //        {
    //            Console.WriteLine(employ.Id);
    //        }
    //        Console.WriteLine("---------------------------------");
    //        Console.WriteLine("---------------------------------");
    //    }
    //}


    private static void DisplayMessage(string message) => Console.WriteLine(message);
}

    