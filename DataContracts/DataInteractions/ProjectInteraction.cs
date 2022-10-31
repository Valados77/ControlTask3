using DataContracts.DataObjects;

namespace DataContracts.DataInteractions
{
    public class ProjectInteraction
    {
        public static Project AddNewProject(string projectName)
        {
            //TEST IMPLEMENTATION
            //---------------------------------------
            Project addProject = new Project(projectName);
            DataDictionaries.ProjectDictionary.Add(addProject.Id, addProject);

            return addProject;
            //---------------------------------------
        }

        public static void AddNewExpirationDateTime(Project project, DateTime newDateTime)
        {
            project.ExpirationDate = newDateTime;
        }


    }
}
