using Business.BusinesObjects;
using DataContracts;

namespace Business.BusinesServices
{
    internal class UserService
    {
        public Dictionary<string, UserData> GetAllActiveUser(Dictionary<string, UserData> userList)
        {
            var activeUsers = userList.Where(p => p.Value.User.IsActive == true);

            return activeUsers.ToDictionary(p => p.Key, p => p.Value);
        }

        public Dictionary<string, UserData> GetAllLeader(Dictionary<string, UserData> userList)
        {
            var Leaders = userList.Where(p => p.Value.User.AccessRole == Enums.AccessRoles.Leader);
            return Leaders.ToDictionary(p => p.Key, p => p.Value);
        }

        public Dictionary<string, UserData> GetAllActiveUsersFromSomeTime(Dictionary<string, UserData> userList, int time)
        {
            var Leaders = userList.Where(p => p.Value.User.AccessRole == Enums.AccessRoles.Leader && p.Value.SumOfSubmittedTime >= time);
            return Leaders.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}