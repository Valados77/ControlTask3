using Application;
using DataContracts;


class Program
{
    public static Dictionary<string, User> userDictionary = new Dictionary<string, User>();
    public static Dictionary<string, Project> projectDictionary = new Dictionary<string, Project>();
    public static User loginingUser = new User();

    static void Main(string[] args)
    {
        //TEST IMPLEMENTATION
        //---------------------------------------
        Console.WriteLine("Enter \"reg\" to register new user");
        while (Console.ReadLine() == "reg")
        {
            User user = InteractionUser.Regestration();
            userDictionary.Add(user.Id, user);
            Console.WriteLine("end");
            Console.WriteLine("Enter \"reg\" to register new user")
        }

        foreach (var i in userDictionary)
        {
            i.Value.Print();
        }

        User loginingUser = InteractionUser.Logining(userDictionary);
        //---------------------------------------
    }
}
