using DataContracts.DataObjects;

namespace DataContracts.DataInteractions
{
    public class UserInteraction
    {
        public static User AddNewUser(string username, string password, Enums.AccessRoles role)
        {
            //TEST IMPLEMENTATION
            //---------------------------------------


            User addUser = new User(username, password, role);
            DataDictionaries.UserDictionary.Add(addUser.Id, addUser);

            return addUser;
            //---------------------------------------
        }
    }
}
