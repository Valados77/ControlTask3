using Business.BusinessObjects;
using Business.BusinessServices;
using DataContracts;
using DataContracts.DataObjects;
using Mediator.Components;

namespace Business
{
    public class DataFacade : BaseComponent
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

        public string AddNewUserData(
            string userName, 
            string password, 
            Enums.AccessRoles? role)
        {
            User? user = new User(userName, password, role);

            UserData userData = new UserData(user);
            userData.IsActiveChanged += DisplayMessage;
            _dataList.UserDataList.Add(userData);

            return userData.User.Id;
        }

        public void DeleteUserDataById(string userId)
        {
            foreach (var user in _dataList.UserDataList)
            {
                if (user.User!.Id == userId)
                {
                    _dataList.UserDataList.Remove(user);
                    return;
                }
            }
        }

        public string AddNewProjectData(string projectName)
        {
            Project project = new Project(projectName);

            ProjectData projectData = new ProjectData(project);
            projectData.IsActiveChanged += DisplayMessage;
            _dataList.ProjectDataList.Add(projectData);

            return projectData.Project.Id;
        }

        public void DeleteProjectDataById(string projectId)
        {
            foreach (var project in _dataList.ProjectDataList)
            {
                if (project.Project!.Id == projectId)
                {
                    _dataList.ProjectDataList.Remove(project);
                    return;
                }
            }
        }

        public UserData? LoginUserData(string userName, string password)
        {
            UserData? userData = ReturnUserDataByName(userName);
            if (userData != null)
            {
                if (PasswordVerification(userData, password) == true)
                {
                    return userData;
                }
            }
            return null;
        }

        public UserData? LogoutUserData()
        {
            return null;
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

        public void AssignProjectForUser(UserData userData, ProjectData projectData)
        {
            userData.User!.ProjectIdForUser = projectData.Project!.Id;
        }

        public UserData? ReturnUserDataByName(string userName)
        {
            foreach (var i in _dataList.UserDataList)
            {
                if (i.User!.Username == userName)
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
                if (i.User!.Id == userId)
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

        public ProjectData? ReturnProjectDataById(string projectId)
        {
            foreach (var i in _dataList.ProjectDataList)
            {
                if (i.Project!.Id == projectId)
                {
                    return i;
                }
            }

            return null;
        }

        public ProjectData? ReturnProjectDataByName(string? projectName)
        {
            foreach (var i in _dataList.ProjectDataList)
            {
                if (i.Project!.Name == projectName)
                {
                    return i;
                }
            }

            return null;
        }

        public void AssignProjectLeader(UserData userData, ProjectData projectData)
        {
            projectData.Project!.LeaderUserId = userData.User!.Id;
        }

        public DateTime ReturnSubmitDateTime(ProjectData? projectData)
        {
            return projectData.Project!.SubmitDateTime;
        }

        public void SetViewingDateTime(ProjectData? projectData)
        {
            projectData.Project.ViewingDateTime.Add(DateTime.Now);
        }

        public void SetMaxHoursPerMonth(ProjectData? projectData, int hours)
        {
            projectData!.Project!.MaxHoursPerMonth = hours;
        }

        public int ReturnMaxHoursPerMonth(ProjectData? projectData)
        {
            return projectData.Project!.MaxHoursPerMonth;
        }

        private static string DisplayMessage(string message)
        {
            return message;
        }
    }
}