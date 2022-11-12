using Application;
using Business.BusinessObjects;

class Program : ProgramInteraction
{
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

        //Print(DataFacadeInteraction.ReturnAllActiveUser());

        ProgramInteraction.Print(DataFacadeInteraction.ReturnAllUser());

        UserData? loginingUser = ProgramInteraction.LoginUser();
        ////---------------------------------------
    }
}