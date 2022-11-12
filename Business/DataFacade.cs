using Business.BusinessObjects;
using Business.BusinessServices;
using DataContracts;
using DataContracts.DataObjects;

namespace Business
{
    public class DataFacade
    {
        private readonly UserService _userService;
        private readonly ProjectService _projectService;
        private readonly DataLists _dataList;
        

        public DataFacade()
        {
            _userService = new UserService();
            _projectService = new ProjectService();
            _dataList = new DataLists();
        }

        public string AddNewUserData(string userName, string password, Enums.AccessRoles role)
        {
            User? user = new User(userName, password, role);

            UserData userData = new UserData(user);
            userData.IsActiveChanged += DisplayMessage;
            _dataList.UserDataList.Add(userData);

            return userData.User.Id;
        }

        public string AddNewProjectData(string projectName)
        {
            Project project = new Project(projectName);

            ProjectData projectData = new ProjectData(project);
            projectData.IsActiveChanged += DisplayMessage;
            _dataList.ProjectDataList.Add(projectData);
            return projectData.Project.Id;
        }

        public List<UserData> ReturnAllUser()
        {
            return _dataList.UserDataList;
        }

        public List<UserData> ReturnAllActiveUser()
        {
            List<UserData> activeUsers = _userService.GetAllActiveUser(_dataList.UserDataList);
            return activeUsers;
        }

        public List<UserData> ReturnAllLeader()
        {
            List<UserData> leaderUsers = 
                _userService.GetAllLeader(_dataList.UserDataList);
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
            List<UserData> leaderUsers = _userService.GetAllActiveUsersFromSomeTime(_dataList.UserDataList, minTime);
            return leaderUsers;
        }

        public UserData? ReturnUserDataByName(string userName)
        {
            foreach (var i in _dataList.UserDataList)
            {
                if (i.User.Username == userName)
                {
                    return i;
                }
            }

            return null;
        }

        public UserData? ReturnUserDataById(string userId)
        {
            foreach (var i in _dataList.UserDataList)
            {
                if (i.User.Username == userId)
                {
                    return i;
                }
            }

            return null;
        }

        public bool PasswordVerification(UserData? userData, string password)
        {
            if (userData.User.Password == password)
            {
                return true;
            }

            return false;
        }

        public List<ProjectData> ReturnAllProject()
        {
            return _dataList.ProjectDataList;
        }

        public List<ProjectData> ReturnAllExpiredProjects()
        {
            List<ProjectData> expiredProjects = 
                _projectService.GetAllExpiredProjects(_dataList.ProjectDataList);
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
                _projectService.GetAllProjectsWihMoreEmployees(_dataList.ProjectDataList, minEmploys);
            return Projects;
        }

        private static string DisplayMessage(string message)
        {
            return message;
        }

    }
}