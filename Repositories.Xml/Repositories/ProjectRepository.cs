using Contracts;
using DataContracts;
using DataContracts.DataObjects;

namespace Repositories.Xml.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ObjectLists _objectLists;

        public ProjectRepository(ObjectLists objectLists)
        {
            _objectLists = objectLists;
        }

        public string Insert(Project project) // return project id
        {
            _objectLists.ProjectDataList.Add(project);
            return project.Id;
        }

        public void Delete(string id)
        {
            foreach (var project in _objectLists.ProjectDataList)
            {
                if (project.Id == id)
                {
                    _objectLists.ProjectDataList.Remove(project);
                    return;
                }
            }
        }

        public IEnumerable<Project?> GetAll() //TEST
        {
            return _objectLists.ProjectDataList;
        }

        public Project? Get(string id)
        {
            return _objectLists.ProjectDataList.FirstOrDefault(p => p.Id == id);
        }
    }
}