using System.ComponentModel;

namespace DataContracts
{
    public class ProjectInteraction
    {
        public static Project NewProject()
        {
            //TEST IMPLEMENTATION
            //---------------------------------------
            return new Project("test");
            //---------------------------------------
        }

        public static void AddNewExpirationDateTime(Project project, DateTime newDateTime)
        {
            project.ExpirationDate = newDateTime;
        }


    }
}
