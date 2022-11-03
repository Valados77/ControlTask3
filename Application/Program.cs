using Application;
using Business.BusinesObjects;

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

        ProgramInteraction.Print(DataFacadeInteraction.ReturnAllLeader());

        UserData? loginingUser = ProgramInteraction.LoginingUser();
        ////---------------------------------------
    }
}
