using Business.BusinesObjects;

namespace Business
{
    internal class DataDictionaries
    {
        public Dictionary<string, UserData> UserDataDictionary;
        public Dictionary<string, ProjectData> ProjectDataDictionary;

        public DataDictionaries()
        {
            UserDataDictionary = new Dictionary<string, UserData>();
            ProjectDataDictionary = new Dictionary<string, ProjectData>();
        }
    }
}
