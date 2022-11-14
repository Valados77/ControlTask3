using DataContracts.DataObjects;

namespace DataContracts
{
    public class ObjectLists
    {
        public List<User> UserDataList;
        public List<Project> ProjectDataList;

        public ObjectLists()
        {
            UserDataList = new List<User>();
            ProjectDataList = new List<Project>();
        }
    }
}