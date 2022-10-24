using Application;
using DataContracts;
using Business;
using Business.BusinesObjects;

class Program
{
    public static DataFacade dataFacade = new DataFacade();

    public static UserData LoginingUser = new UserData(new User("test", 
        "12345", 
        Enums.AccessRoles.Admin));

    static void Main(string[] args)
    {

        ////TEST IMPLEMENTATION
        ////---------------------------------------
        Console.WriteLine("Enter \"reg\" to register new user");
        while (Console.ReadLine() == "reg")
        {
            ProgramInteraction.RegisterNewUser();
            Console.WriteLine("end");   
            Console.WriteLine("Enter \"reg\" to register new user");
        }

        DataDictionaries.PrintUserDictionary();

        User loginingUser = ProgramInteraction.LoginingUser();
        ////---------------------------------------
    }
}
