namespace DataContracts.DataObjects
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public string Comment { get; set; }

        public virtual void Print() { }
    }
}