using DataContracts.DataObjects;


namespace Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        string Insert(T entity);
        void Delete(string id);
        IEnumerable<T?> GetAll();
    }
}