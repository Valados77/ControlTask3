using DataContracts;

namespace Business.BusinesObjects
{
    public class ProjectData
    {
        public delegate void IsActiveChangedHandler(string msg);
        public event IsActiveChangedHandler? IsActiveChanged;
        public Project Project { get; private set; }
        public List<User> EmployeesList { get; private set; }

        public ProjectData(Project project)
        {
            Project = project;
        }

        public void AddEmploy(User newEmploy)
        {
            EmployeesList.Add(newEmploy);
            IsActiveChanged?.Invoke($"Add new employ for the {Project.Name}");
        }
    }
}
