using DataContracts.DataObjects;

namespace Business.BusinesObjects
{
    public class ProjectData
    {
        public delegate string IsActiveChangedHandler(string msg);
        public event IsActiveChangedHandler? IsActiveChanged;
        public Project Project { get; private set; }
        public List<User> employeesList = new List<User>();

        public ProjectData(Project project, List<User>? employeesList = null)
        {
            Project = project;
            this.employeesList = employeesList ?? new List<User>();
        }

        public void AddEmploy(User newEmploy)
        {
            employeesList?.Add(newEmploy);
            IsActiveChanged?.Invoke($"Add new employ for the {Project.Name}");
        }
    }
}
