using Business.BusinesObjects;
using Business.BusinesServices;
using DataContracts;
using DataContracts.DataInteractions;
using DataContracts.DataObjects;

namespace Business
{
    public class DataFacade
    {
        private UserService userService;
        private ProjectService projectService;
        private DataLists dataList;
        

        public DataFacade()
        {
            userService = new UserService();
            projectService = new ProjectService();
            dataList = new DataLists();
        }

        public bool AddNewUserData(string userName, string password, Enums.AccessRoles role)
        {
            User user = UserInteraction.AddNewUser(userName, password, role);
            UserData userData = new UserData(user);
            userData.IsActiveChanged += DisplayMessage;
            dataList.userDataList.Add(userData);
            return true;
        }

        public bool AddNewProjectData(string projectName)
        {
            Project project = ProjectInteraction.AddNewProject(projectName);
            ProjectData projectData = new ProjectData(project);
            projectData.IsActiveChanged += DisplayMessage;
            dataList.projectDataList.Add(projectData);
            return true;
        }

        public List<UserData> ReturnAllActiveUser()
        {
            List<UserData> activeUsers = userService.GetAllActiveUser(dataList.userDataList);
            return activeUsers;
        }

        public List<UserData> ReturnAllLeader()
        {
            List<UserData> leaderUsers = 
                userService.GetAllLeader(dataList.userDataList);
            return leaderUsers;
        }

        public List<UserData> ReturnAllActiveUsersFromSomeTime()
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
            List<UserData> leaderUsers = userService.GetAllActiveUsersFromSomeTime(dataList.userDataList, minTime);
            return leaderUsers;
        }

        public UserData? ReturnUserData(string userName)
        {
            foreach (var i in dataList.userDataList)
            {
                if (i.User.Username == userName)
                {
                    return i;
                }
            }

            return null;
        }

        public bool PasswordVerification(UserData userData, string password)
        {
            if (userData.User.Password == password)
            {
                return true;
            }

            return false;
        }

        public List<ProjectData> ReturnAllExpiredProjects()
        {
            List<ProjectData> expiredProjects = 
                projectService.GetAllExpiredProjects(dataList.projectDataList);
            return expiredProjects;
        }

        public List<ProjectData> ReturnAllProjectsWihMoreEmployees()
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
                projectService.GetAllProjectsWihMoreEmployees(dataList.projectDataList, minEmploys);
            return Projects;
        }

        private static string DisplayMessage(string message)
        {
            return message;
        }

    }
}