using Business;
using DataContracts;

namespace Application;

public class ProgramInteraction
{
    public static void Menu()
    {
        //TEST IMPLEMENTATION
        //---------------------------------------
        do
        {
            Console.WriteLine("Menu:\n" +
                              "0. New registration\n" +
                              "1. Logging\n" +
                              "2. Add new project\n" +
                              "3. Show a list of projects\n" +
                              "4. ");
            switch (Console.ReadLine())
            {
                case "1":
                    User user = UserInteraction.Registration();
                    DataDictionaries.UserDictionary.Add(user.Id, user);
                    break;
                case "2":
                    //Program.LoginingUser = DataFacade.LoginingUserData();
                    break;

            }
        } while (true);
        //---------------------------------------
    }
}

    