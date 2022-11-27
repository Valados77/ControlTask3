using Business.BusinessObjects;

namespace Application;

internal class Program : ProgramInteraction
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

        //Print(DataFacadeInteraction.GetAllActiveUser());

        ProgramInteraction.Print(_dataFacade.GetAllUser());

        Console.WriteLine("Enter login name");
        string loginName = Console.ReadLine();
        Console.WriteLine("Enter login password");
        string loginPassword = Console.ReadLine();
        _userBusinessObject.DoLoginUser(loginName, loginPassword);
        ////---------------------------------------
    }
}