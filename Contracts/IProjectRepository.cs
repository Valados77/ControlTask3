using DataContracts.DataObjects;
namespace Contracts;

public interface IProjectRepository
{
    Project? Get(string id);
}