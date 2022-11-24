using Business.BusinessObjects;
using DataContracts;
using System;

namespace Business.BusinessServices
{
    public class UserService
    {
        public List<UserData> GetAllActiveUser(List<UserData> userList)
        {
            var activeUsers =
                userList.Where(p => p.User is { IsActive: true });

            return activeUsers.ToList();
        }

        public List<UserData> GetAllLeader(List<UserData> userList)
        {
            var leaders =
                userList.Where(p => p.User is { AccessRole: Enums.AccessRoles.Leader });

            return leaders.ToList();
        }

        public List<UserData> GetAllActiveUsersFromSomeTime(List<UserData> userList, int time)
        {
            var leaders =
                userList.Where(p => p.User is { AccessRole: Enums.AccessRoles.Leader } &&
                                    p.SumOfSubmittedTime >= time);

            return leaders.ToList();
        }
    }
}