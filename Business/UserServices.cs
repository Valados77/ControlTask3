using DataContracts;

namespace Business
{
    internal class UserServices
    {
        public List<UserData> GetAllActiveUser(List<UserData> userList)
        {
            var activeUsers = userList.Where(p => p.User.IsActive == true);

            return activeUsers.ToList();
        }

        public List<UserData> GetAllLeader(List<UserData> userList)
        {
            var Leaders = userList.Where(p => p.User.AccessRole == Enums.AccessRoles.Leader);
            return Leaders.ToList();
        }

        public List<UserData> GetAllActiveUsersFromSomeTime(List<UserData> userList, int time)
        {
            var Leaders = userList.Where(p => p.User.AccessRole == Enums.AccessRoles.Leader && p.sumOfSubmittedTime >= time);
            return Leaders.ToList();
        }

        public void Print(List<UserData> userData)
        {
            foreach (var user in userData)
            {
                Console.WriteLine("User: {0}", user.User.Username);
                Console.WriteLine("---------------------------------");
                foreach (var timeTrackEntry in user.SubmittedTime)
                {
                    Console.WriteLine(timeTrackEntry.Date);
                }
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------------------------------");
            }
        }
    }
}
