
namespace DataContracts
{
    public class UserInteraction
    {
        public static User Registration()
        {
            //TEST IMPLEMENTATION
            //---------------------------------------
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter access role:\n" +
                          "0. Admin\n" +
                          "1. Leader\n" +
                          "2. Employee");
            Enums.AccessRoles role = new Enums.AccessRoles();
            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("Role selected: Admin");
                    role = Enums.AccessRoles.Admin;
                    break;
                case "1":
                    Console.WriteLine("Role selected: Leader");
                    role = Enums.AccessRoles.Leader;
                    break;
                case "2":
                    Console.WriteLine("Role selected: Employee");
                    role = Enums.AccessRoles.Employee;
                    break;
                default:
                    Console.WriteLine("Incorrectly selected value! Default role selected: Employee");
                    role = Enums.AccessRoles.Employee;
                    break;
            }

            User addUser = new User(username, password, role);

            Console.Write("Enter full name: ");
            addUser.FullName = Console.ReadLine();
            return addUser;
            //---------------------------------------
        }

        public static User LoginingUser(Dictionary<string, User> dataUsers)
        {
            //TEST IMPLEMENTATION
            //---------------------------------------
            Console.WriteLine("enter username: ");
            string name = Console.ReadLine();
            foreach (var i in dataUsers)
            {
                if (i.Value.Username == name)
                {
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    if (i.Value.Password == password)
                    {
                        Console.WriteLine("OK");
                        return i.Value;
                    }

                }
            }
            return new User("test", "test", Enums.AccessRoles.Employee);
            //---------------------------------------
        }
    }
}
