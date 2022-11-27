using Contracts;
using DataContracts;
using DataContracts.DataObjects;

namespace Repositories.Xml.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ObjectLists _objectLists;

    public UserRepository(ObjectLists objectLists)
    {
        _objectLists = objectLists;
    }

    public string Insert(User user) // return User id
    {
        _objectLists.UserDataList.Add(user);
        return user.Id;
    }

    public void Delete(string id)
    {
        _objectLists.UserDataList.RemoveAll(u => u.Id == id);
    }

    public IEnumerable<User?> GetAll()
    {
        return _objectLists.UserDataList;
    }

    public User? Get(string id)
    {
        return _objectLists.UserDataList.FirstOrDefault(u => u.Id == id);
    }
}