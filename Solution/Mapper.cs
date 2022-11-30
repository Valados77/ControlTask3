using Contracts;
using DataContracts;
using Repositories.Xml.Repositories;

namespace Solution
{
    public class Mapper
    {
        private readonly ObjectLists _objectLists;

        public Mapper(ObjectLists objectLists)
        {
            _objectLists = objectLists;
        }

        public IUserRepository GetUserRepository()
        {
            return new UserRepository(_objectLists);
        }

        public IProjectRepository GetProjectRepository()
        {
            return new ProjectRepository(_objectLists);
        }
    }
}