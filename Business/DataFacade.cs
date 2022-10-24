using Business.BusinesObjects;
using Business.BusinesServices;
using DataContracts;

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

        public List<UserData> PrintAllActiveUser()
        {
            List<UserData> activeUsers = userService.GetAllActiveUser(dataList.userDataList);
            return activeUsers;
        }

        public List<UserData> PrintAllLeader()
        {
            List<UserData> leaderUsers = 
                userService.GetAllLeader(dataList.userDataList);
            return leaderUsers;
        }

        public List<UserData> PrintAllActiveUsersFromSomeTime()
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

        public List<ProjectData> PrintExpiredProjects()
        {
            List<ProjectData> expiredProjects = 
                projectService.GetAllExpiredProjects(dataList.projectDataList);
            return expiredProjects;
        }

        public List<ProjectData> PrintAllProjectsWihMoreEmployees()
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
    }
}