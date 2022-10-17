using DataContracts;

namespace Business
{
    public class DataFacade
    {
        private UserServices userServices;
        private ProjectServices projectServices;
        private DataLists dataLists;
        

        public DataFacade()
        {
            userServices = new UserServices();
            projectServices = new ProjectServices();
            dataLists = new DataLists();
        }

        public void RegistrationNewUser()
        {
            User user = UserInteraction.Registration();
            DataDictionaries.UserDictionary.Add(user.Id, user);
            UserData userData = new UserData(user);
            userData.Notify += DisplayMessage;
            dataLists.userDataList.Add(userData);
        }

        public UserData LoginingUserData()
        {
            Console.WriteLine("enter username: ");
            string name = Console.ReadLine();
            foreach (var i in dataLists.userDataList)
            {
                if (i.User.Username == name)
                {
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    if (i.User.Password == password)
                    {
                        Console.WriteLine("OK");
                        return i;
                    }

                }
            }
            return new UserData(new User("test", "test", Enums.AccessRoles.Employee));
        }
        
        public void PrintAllActiveUser()
        {
            List<UserData> activeUsers = userServices.GetAllActiveUser(dataLists.userDataList);
            userServices.Print(activeUsers);
        }

        public void PrintAllLeader()
        {
            List<UserData> leaderUsers = 
                userServices.GetAllLeader(dataLists.userDataList);
            userServices.Print(leaderUsers);
        }

        public void PrintAllActiveUsersFromSomeTime()
        {
            Console.Write("Enter the minimum working time: ");
            int minTime;
            try
            {
                minTime = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("An exception was thrown: ");
                minTime = 0;
            }
            List<UserData> leaderUsers = userServices.GetAllActiveUsersFromSomeTime(dataLists.userDataList, minTime);
            userServices.Print(leaderUsers);
        }

        public void PrintExpiredProjects()
        {
            List<ProjectData> expiredProjects = 
                projectServices.GetAllExpiredProjects(dataLists.projectDataList);
            projectServices.Print(expiredProjects);
        }

        public void PrintAllProjectsWihMoreEmployees()
        {
            int minEmploys;
            try
            {
                minEmploys = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("An exception was thrown: ");
                minEmploys = 0;
            }
            List<ProjectData> Projects =
                projectServices.GetAllProjectsWihMoreEmployees(dataLists.projectDataList, minEmploys);
            projectServices.Print(Projects);
        }

        void DisplayMessage(string message) => Console.WriteLine(message);
    }
}