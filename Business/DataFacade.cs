using Business.BusinessObjects;
using Business.BusinessServices;
using Business.Mediator;
using DataContracts;
using DataContracts.DataObjects;

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

            var userData = new UserData(user);
            userData.IsActiveChanged += DisplayMessage;
            _dataList.UserDataList.Add(userData);

            return userData.User!.Id;
        }

        public bool DeleteUserDataById(string? userId)
        {
            if (userId == null)
            {
                return false;
            }
            _dataList.UserDataList.RemoveAll(u => u.User!.Id == userId);
            return true;
        }

        public string AddNewProjectData(string projectName)
        {
            var project = new Project(projectName);

            var projectData = new ProjectData(project);
            projectData.IsActiveChanged += DisplayMessage;
            _dataList.ProjectDataList.Add(projectData);

            return projectData.Project!.Id;
        }

        public bool DeleteProjectDataById(string? projectId)
        {
            if (projectId == null)
            {
                return false;
            }
            _dataList.ProjectDataList.RemoveAll(p => p.Project!.Id == projectId);
            return true;
        }

        public UserData? LoginUserData(string? userName, string? password)
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

        public List<UserData> GetAllActiveUsersFromSomeTime(int minTime)
        {
            return _userService.GetAllActiveUsersFromSomeTime(_dataList.UserDataList, minTime);
        }

        public string AssignProjectForUser(UserData userData, ProjectData projectData)
        {
            userData.User!.ProjectIdForUser = projectData.Project!.Id;
            return projectData.Project!.Id;
        }

        public UserData? GetUserDataByName(string? userName)
        {
            return _dataList.UserDataList.Find(u => u.User!.Username == userName);
        }

        public UserData? GetUserDataById(string? userId)
        {
            return _dataList.UserDataList.Find(u => u.User!.Id == userId);
        }

        public bool PasswordVerification(UserData userData, string? password)
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

        public List<ProjectData> GetAllProjectsWihMoreEmployees(int minEmploys)
        {
            return _projectService.GetAllProjectsWihMoreEmployees(_dataList.ProjectDataList, minEmploys);
        }

        public ProjectData? GetProjectDataById(string? projectId)
        {
            return _dataList.ProjectDataList.Find(p => p.Project!.Id == projectId);
        }

        public ProjectData? GetProjectDataByName(string? projectName)
        {
            return _dataList.ProjectDataList.Find(p => p.Project!.Name == projectName);
        }

        public string AssignProjectLeader(UserData userData, ProjectData projectData)
        {
            projectData.Project!.LeaderUserId = userData.User!.Id;
            return userData.User!.Id;
        }

        public DateTime GetSubmitDateTime(ProjectData projectData)
        {
            return projectData.Project!.SubmitDateTime;
        }

        public string SetViewingDateTime(ProjectData projectData)
        {
            projectData.Project!.ViewingDateTime.Add(DateTime.Now);
            return projectData.Project!.Id;
        }

        public string SetMaxHoursPerMonth(ProjectData projectData, int hours)
        {
            projectData!.Project!.MaxHoursPerMonth = hours;
            return projectData.Project.Id;
        }

        public int GetMaxHoursPerMonth(ProjectData projectData)
        {
            return projectData.Project!.MaxHoursPerMonth;
        }

        private static string DisplayMessage(string message)
        {
            return message;
        }
    }
}