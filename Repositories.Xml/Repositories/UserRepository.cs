using Business;
using Contracts;
using DataContracts.DataObjects;

namespace Repositories.Xml.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataFacade _userData;

    public UserRepository(DataFacade userData)
    {
        _userData = userData;
    }

    public string Insert(User entity) // return User id
    {
        return _userData.AddNewUserData(entity.Username, entity.Password, entity.AccessRole);
    }

    public void Delete(string id)
    {
        foreach (var userData in _userData.ReturnAllUser())
        {
            if (userData.User?.Id == id)
            {
                _userData.ReturnAllUser().Remove(userData);
                return;
            }
        }
    }

    public IEnumerable<User?> GetAll()
    {
        return _userData.ReturnAllUser().Select(x => x.User);
    }

    public User? Get(string id)
    {
        foreach (var userData in _userData.ReturnAllUser())
        {
            if (userData.User?.Id == id)
            {
                var newUser = userData.User;
                return newUser;
            }
        }

        return null;
    }
}