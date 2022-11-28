
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
            RegisterNewUser();
            Console.WriteLine("end");
            Console.WriteLine("Enter \"reg\" to register new user");
        }

        Print(DataFacade.GetAllUser());

        Console.WriteLine("Enter login name");
        var loginName = Console.ReadLine();
        Console.WriteLine("Enter login password");
        var loginPassword = Console.ReadLine();

        var loginUser = UserBusinessObject.DoLoginUser(loginName, loginPassword);
        Console.WriteLine(loginUser?.User!.Username);
        ////---------------------------------------
    }
}