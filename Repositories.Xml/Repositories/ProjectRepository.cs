using Business;
using Contracts;
using DataContracts.DataObjects;

namespace Repositories.Xml.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataFacade _projectData;

        public ProjectRepository(DataFacade projectData)
        {
            _projectData = projectData;
        }

        public string Insert(Project entity) // return project id
        {
            return _projectData.AddNewProjectData(entity.Name);
        }

        public void Delete(string id)
        {
            foreach (var projectData in _projectData.ReturnAllProject())
            {
                if (projectData.Project?.Id == id)
                {
                    _projectData.ReturnAllProject().Remove(projectData);
                    return;
                }
            }
        }

        public IEnumerable<Project?> GetAll()
        {
            return _projectData.ReturnAllProject().Select(x => x.Project);
        }

        public Project? Get(string id)
        {
            foreach (var projectData in _projectData.ReturnAllProject())
            {
                if (projectData.Project?.Id == id)
                {
                    var newProject = projectData.Project;
                    return newProject;
                }
            }

            return null;
        }
    }
}