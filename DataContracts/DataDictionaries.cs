namespace DataContracts
{
    public class DataDictionaries
    {
        public static Dictionary<string, User> UserDictionary = new Dictionary<string, User>();
        public static Dictionary<string, Project> ProjectDictionary = new Dictionary<string, Project>();

        public static void PrintUserDictionary()
        {
            foreach (var i in UserDictionary)
            {
                i.Value.Print();
            }
        }

        public static void PrintProjectDictionary()
        {
            foreach (var i in ProjectDictionary)
            {
                i.Value.Print();
            }
        }
    }
}
