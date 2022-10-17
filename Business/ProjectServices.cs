using DataContracts;

namespace Business
{
    internal class ProjectServices
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

        public void Print(List<ProjectData> projectDatas)
        {
            foreach (var project in projectDatas)
            {
                Console.WriteLine("Project: {0}", project.Project.Name);
                Console.WriteLine("---------------------------------");
                foreach (var employ in project.EmployeesList)
                {
                    Console.WriteLine(employ.Id);
                }
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------------------------------");
            }
        }
    }
}
