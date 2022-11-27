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
            Enums.AccessRoles role)
        {
            var user = new User(userName, password, role);

            UserData userData = new UserData(user);
            userData.IsActiveChanged += DisplayMessage;
            _dataList.UserDataList.Add(userData);

            return userData.User.Id;
        }

        public void DeleteUserDataById(string userId)
        {
            _dataList.UserDataList.RemoveAll(u => u.User.Id == userId);
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
            _dataList.ProjectDataList.RemoveAll(p => p.Project.Id == projectId);
        }

        public UserData? LoginUserData(string userName, string password)
        {
            var userData = GetUserDataByName(userName);
            if (userData != null && PasswordVerification(userData, password))
            {

                return userData;

            }
            return null;
        }

        public UserData? LogoutUserData()
        {
            return null;
        }

        public List<UserData> GetAllUser()
        {
            return _dataList.UserDataList;
        }

        public List<UserData> GetAllActiveUser()
        {
            return _userService.GetAllActiveUser(_dataList.UserDataList);
        }

        public List<UserData> GetAllLeader()
        {
            return _userService.GetAllLeader(_dataList.UserDataList);
        }

        public List<UserData> GetAllActiveUsersFromSomeTime()
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

            return _userService.GetAllActiveUsersFromSomeTime(_dataList.UserDataList, minTime);
        }

        public void AssignProjectForUser(UserData userData, ProjectData projectData)
        {
            userData.User!.ProjectIdForUser = projectData.Project!.Id;
        }

        public UserData? GetUserDataByName(string userName)
        {
            return _dataList.UserDataList.Find(u => u.User.Username == userName);
        }

        public UserData? GetUserDataById(string userId)
        {
            return _dataList.UserDataList.Find(u => u.User!.Id == userId);
        }

        public bool PasswordVerification(UserData userData, string password)
        {
            return userData.User!.Password == password;
        }

        public List<ProjectData> GetAllProject()
        {
            return _dataList.ProjectDataList;
        }

        public List<ProjectData> GetAllExpiredProjects()
        {
            return _projectService.GetAllExpiredProjects(_dataList.ProjectDataList);
        }

        public List<ProjectData> GetAllProjectsWihMoreEmployees()
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

            return _projectService.GetAllProjectsWihMoreEmployees(_dataList.ProjectDataList, minEmploys);
        }

        public ProjectData? GetProjectDataById(string projectId)
        {
            return _dataList.ProjectDataList.Find(p => p.Project.Id == projectId);
        }

        public ProjectData? GetProjectDataByName(string? projectName)
        {
            return _dataList.ProjectDataList.Find(p => p.Project.Name == projectName);
        }

        public void AssignProjectLeader(UserData userData, ProjectData projectData)
        {
            projectData.Project!.LeaderUserId = userData.User!.Id;
        }

        public DateTime GetSubmitDateTime(ProjectData? projectData)
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

        public int GetMaxHoursPerMonth(ProjectData? projectData)
        {
            return projectData.Project!.MaxHoursPerMonth;
        }

        private static string DisplayMessage(string message)
        {
            return message;
        }
    }
}