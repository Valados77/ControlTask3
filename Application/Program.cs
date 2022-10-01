using Application;
using DataContracts;


class Program
{
    public static Dictionary<string, User> UserDictionary = new Dictionary<string, User>();
    public static Dictionary<string, Project> ProjectDictionary = new Dictionary<string, Project>();
    public static User LoginingUser = new User("test", "12345", Enums.AccessRoles.Admin);

    static void Main(string[] args)
    {
        //TEST IMPLEMENTATION
        //---------------------------------------
        Console.WriteLine("Enter \"reg\" to register new user");
        while (Console.ReadLine() == "reg")
        {
            User user = UserInteraction.Registration();
            UserDictionary.Add(user.Id, user);
            Console.WriteLine("end");
            Console.WriteLine("Enter \"reg\" to register new user");
        }

        foreach (var i in UserDictionary)
        {
            i.Value.Print();
        }

        User loginingUser = UserInteraction.Logining(UserDictionary);
        //---------------------------------------
    }
}
