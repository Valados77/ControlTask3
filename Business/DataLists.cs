using Business.BusinesObjects;

namespace Business
{
    internal class DataLists
    {
        public List<UserData> userDataList; //List for storing business objects
        public List<ProjectData> projectDataList; //List for storing business objects

        public DataLists()
        {
            userDataList = new List<UserData>();
            projectDataList = new List<ProjectData>();
        }
    }
}
