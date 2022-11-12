using Business.BusinessObjects;

namespace Business
{
    internal class DataLists
    {
        public List<UserData> UserDataList;
        public List<ProjectData> ProjectDataList;

        public DataLists()
        {
            UserDataList = new List<UserData>();
            ProjectDataList = new List<ProjectData>();
        }
    }
}
