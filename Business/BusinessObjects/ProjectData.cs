using DataContracts.DataObjects;

namespace Business.BusinessObjects
{
    public class ProjectData
    {
        public delegate string IsActiveChangedHandler(string msg);
        public event IsActiveChangedHandler? IsActiveChanged;
        public Project? Project { get; private set; }
        public List<User> EmployeesList = new List<User>();

        public ProjectData(Project project, List<User>? employeesList = null)
        {
            Project = project;
            EmployeesList = employeesList ?? new List<User>();
        }

        public void AddEmploy(User newEmploy)
        {
            EmployeesList?.Add(newEmploy);
            IsActiveChanged?.Invoke($"Add new employ for the {Project.Name}");
        }
    }
}
