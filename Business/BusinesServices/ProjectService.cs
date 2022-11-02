using Business.BusinesObjects;

namespace Business.BusinesServices
{
    internal class ProjectService
    {
        public Dictionary<string, ProjectData> GetAllExpiredProjects(Dictionary<string, ProjectData> ProjectList)
        {
            var ExpiredProjects = ProjectList.Where(p => p.Value.Project.ExpirationDate >= DateTime.Now);

            return ExpiredProjects.ToDictionary(p => p.Key, p => p.Value);
        }

        public Dictionary<string, ProjectData> GetAllProjectsWihMoreEmployees(Dictionary<string, ProjectData> projectsList, int quantity)
        {
            var projects = projectsList.Where(p => p.Value.employeesList.Count >= quantity);
            return projects.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
