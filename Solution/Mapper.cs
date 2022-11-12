using Business;
using Contracts;
using Repositories.Xml.Repositories;

namespace Solution
{
    public class Mapper
    {
        private readonly DataFacade _userData;

        public Mapper(DataFacade userData)
        {
            _userData = userData;
        }

        public IUserRepository GetUserRepository()
        {
            return new UserRepository(_userData);
        }

        public IProjectRepository GetProjectRepository()
        {
            return new ProjectRepository(_userData);
        }
    }
}