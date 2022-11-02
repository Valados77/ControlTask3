using Business.BusinesObjects;

namespace Business
{
    internal class DataDictionaries
    {
        public Dictionary<string, UserData> UserDataDictionary; //List for storing business objects
        public Dictionary<string, ProjectData> ProjectDataDictionary; //List for storing business objects

        public DataDictionaries()
        {
            UserDataDictionary = new Dictionary<string, UserData>();
            ProjectDataDictionary = new Dictionary<string, ProjectData>();
        }
    }
}
