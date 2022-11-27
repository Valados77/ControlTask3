using Business.BusinessObjects;


namespace Business.BusinessServices
{
    public class ProjectService
    {
        public List<ProjectData> GetAllExpiredProjects(List<ProjectData> projectList)
        {
            var expiredProjects =
                projectList.Where(p => p.Project.ExpirationDate >= DateTime.Now);

            return expiredProjects.ToList();
        }

        public List<ProjectData> GetAllProjectsWihMoreEmployees(List<ProjectData> projectsList, int quantity)
        {
            var projects =
                projectsList.Where(p => p.EmployeesList.Count >= quantity);

            return projects.ToList();
        }
    }
}