using DataContracts;

namespace Business
{
    internal class ProjectData
    {
        public delegate void IsActiveChanged(string msg);
        public event IsActiveChanged? Notify;
        public Project Project { get; private set; }
        public List<User> EmployeesList { get; private set; }

        public ProjectData(Project project)
        {
            Project = project;
        }

        public void AddEmploy(User newEmploy)
        {
            EmployeesList.Add(newEmploy);
            Notify?.Invoke($"Add new employ for the {Project.Name}");
        }
    }
}
