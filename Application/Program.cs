using Application;
using Business;
using Business.BusinesObjects;

class Program : ProgramInteraction
{
    public static DataFacade dataFacade = new DataFacade();

    static void Main(string[] args)
    {

        ////TEST IMPLEMENTATION
        ////---------------------------------------
        Console.WriteLine("Enter \"reg\" to register new user");
        while (Console.ReadLine() == "reg")
        {
            ProgramInteraction.RegisterNewUser(dataFacade);
            Console.WriteLine("end");   
            Console.WriteLine("Enter \"reg\" to register new user");
        }

        //Print(dataFacade.ReturnAllActiveUser());

        ProgramInteraction.Print(dataFacade.ReturnAllExpiredProjects());

        UserData? loginingUser = ProgramInteraction.LoginingUser(dataFacade);
        ////---------------------------------------
    }
}
