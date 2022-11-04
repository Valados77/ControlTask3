using Business.BusinesObjects;
using Business.BusinesServices;
using DataContracts;
using DataContracts.DataObjects;

namespace Business
{
    public class DataFacade
    {
        private readonly UserService _userService;
        private readonly ProjectService _projectService;
        private readonly DataDictionaries _dataDictionary;
        

        public DataFacade()
        {
            _userService = new UserService();
            _projectService = new ProjectService();
            _dataDictionary = new DataDictionaries();
        }

        public bool AddNewUserData(string userName, string password, Enums.AccessRoles role)
        {
            User user = new User(userName, password, role);

            UserData userData = new UserData(user);
            userData.IsActiveChanged += DisplayMessage;
            _dataDictionary.UserDataDictionary.Add(user.Id, userData);
            return true;
        }

        public bool AddNewProjectData(string projectName)
        {
            Project project = new Project(projectName);

            ProjectData projectData = new ProjectData(project);
            projectData.IsActiveChanged += DisplayMessage;
            _dataDictionary.ProjectDataDictionary.Add(project.Id, projectData);
            return true;
        }

        public Dictionary<string, UserData> ReturnAllUser()
        {
            return _dataDictionary.UserDataDictionary;
        }

        public Dictionary<string, UserData> ReturnAllActiveUser()
        {
            Dictionary<string, UserData> activeUsers = _userService.GetAllActiveUser(_dataDictionary.UserDataDictionary);
            return activeUsers;
        }

        public Dictionary<string, UserData> ReturnAllLeader()
        {
            Dictionary<string, UserData> leaderUsers = 
                _userService.GetAllLeader(_dataDictionary.UserDataDictionary);
            return leaderUsers;
        }

        public Dictionary<string, UserData> ReturnAllActiveUsersFromSomeTime()
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
            Dictionary<string, UserData> leaderUsers = _userService.GetAllActiveUsersFromSomeTime(_dataDictionary.UserDataDictionary, minTime);
            return leaderUsers;
        }

        public UserData? ReturnUserData(string userName)
        {
            foreach (var i in _dataDictionary.UserDataDictionary)
            {
                if (i.Value.User.Username == userName)
                {
                    return i.Value;
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

        public Dictionary<string, ProjectData> ReturnAllExpiredProjects()
        {
            Dictionary<string, ProjectData> expiredProjects = 
                _projectService.GetAllExpiredProjects(_dataDictionary.ProjectDataDictionary);
            return expiredProjects;
        }

        public Dictionary<string, ProjectData> ReturnAllProjectsWihMoreEmployees()
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
            Dictionary<string, ProjectData> Projects =
                _projectService.GetAllProjectsWihMoreEmployees(_dataDictionary.ProjectDataDictionary, minEmploys);
            return Projects;
        }

        private static string DisplayMessage(string message)
        {
            return message;
        }

    }
}