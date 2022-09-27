using DataContracts;

namespace Application;

public class InteractionUser
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
                    User user = Regestration();
                    Program.userDictionary.Add(user.Id, user);
                    break;
                case "2":
                    Program.loginingUser = Logining(Program.userDictionary);
                    break;

            }
        } while (true);
        //---------------------------------------
    }


    public static User Regestration()
    {
        //TEST IMPLEMENTATION
        //---------------------------------------
        User addUser = new User();
        Console.Write("Enter username: ");
        addUser.Username = Console.ReadLine();

        Console.Write("Enter password: ");
        addUser.Password = Console.ReadLine();

        Console.Write("Enter full name: ");
        addUser.FullName = Console.ReadLine();

        Console.Write("Enter access role:\n" +
                      "0. Admin\n" +
                      "1. Leader\n" +
                      "2. Employee");
        switch (Console.ReadLine())
        {
            case "0":
                Console.WriteLine("Role selected: Admin");
                addUser.AccessRole = AccessRoles.Admin;
                break;
            case "1":
                Console.WriteLine("Role selected: Leader");
                addUser.AccessRole = AccessRoles.Leader;
                break;
            case "2":
                Console.WriteLine("Role selected: Employee");
                addUser.AccessRole = AccessRoles.Employee;
                break;
            default:
                Console.WriteLine("Incorrectly selected value! Default role selected: Employee");
                addUser.AccessRole = AccessRoles.Employee;
                break;
        }
        return addUser;
        //---------------------------------------
    }

    public static User Logining(Dictionary<string, User> dataUsers)
    {
        //TEST IMPLEMENTATION
        //---------------------------------------
        User TestDELETE = new User();
        Console.WriteLine("enter username: ");
        string name = Console.ReadLine();
        foreach (var i in dataUsers)
        {
            if (i.Value.Username == name)
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                if (i.Value.Password == password)
                {
                    Console.WriteLine("OK");
                    return i.Value;
                }

            }
        }
        return TestDELETE;
        //---------------------------------------
    }

    public static Project NewProject()
    {

    }


    }

    