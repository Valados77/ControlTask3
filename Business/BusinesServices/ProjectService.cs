using Business.BusinesObjects;
using DataContracts;

namespace Business.BusinesServices
{
    internal class ProjectService
    {
        public List<ProjectData> GetAllExpiredProjects(List<ProjectData> ProjectList)
        {
            var ExpiredProjects = ProjectList.Where(p => p.Project.ExpirationDate >= DateTime.Now);

            return ExpiredProjects.ToList();
        }

        public List<ProjectData> GetAllProjectsWihMoreEmployees(List<ProjectData> projectsList, int quantity)
        {
            var projects = projectsList.Where(p => p.EmployeesList.Count >= quantity);
            return projects.ToList();
        }
    }
}
