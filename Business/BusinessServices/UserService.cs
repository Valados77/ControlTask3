using Business.BusinessObjects;
using DataContracts;

namespace Business.BusinessServices
{
    public class UserService
    {
        public List<UserData> GetAllActiveUser(List<UserData> userList)
        {
            var activeUsers =
                userList.Where(p => p.User.IsActive == true);

            return activeUsers.ToList();
        }

        public List<UserData> GetAllLeader(List<UserData> userList)
        {
            var Leaders =
                userList.Where(p => p.User.AccessRole == Enums.AccessRoles.Leader);

            return Leaders.ToList();
        }

        public List<UserData> GetAllActiveUsersFromSomeTime(List<UserData> userList, int time)
        {
            var Leaders =
                userList.Where(p => p.User.AccessRole == Enums.AccessRoles.Leader &&
                                    p.SumOfSubmittedTime >= time);

            return Leaders.ToList();
        }
    }
}