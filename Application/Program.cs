using DataContracts;
using Business;

class Program
{
    public static UserData LoginingUser = new UserData(new User("test", 
        "12345", 
        Enums.AccessRoles.Admin));

    static void Main(string[] args)
    {
        DataFacade dataFacade = new DataFacade();

        ////TEST IMPLEMENTATION
        ////---------------------------------------
        Console.WriteLine("Enter \"reg\" to register new user");
        while (Console.ReadLine() == "reg")
        {
            dataFacade.RegistrationNewUser();
            Console.WriteLine("end");   
            Console.WriteLine("Enter \"reg\" to register new user");
        }

        DataDictionaries.PrintUserDictionary();

        UserData loginingUser = dataFacade.LoginingUserData();
        ////---------------------------------------
    }
}
