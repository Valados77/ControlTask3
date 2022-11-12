using DataContracts.DataObjects;

namespace Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User? Get(string id);
    }
}