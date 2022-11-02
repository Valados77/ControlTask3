using Application;
using Business;
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

        //Print(dataFacade.ReturnAllActiveUser());

        ProgramInteraction.Print(dataFacade.ReturnAllLeader());

        UserData? loginingUser = ProgramInteraction.LoginingUser();
        ////---------------------------------------
    }
}
