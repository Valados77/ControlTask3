
namespace DataContracts
{
    public class Project : BaseEntity
    {
        public Project() : this("unknown")
            {
                Id = string.Format("{0:d4}P", Count++); //P-project
                CreationDateTime = DateTime.Now;
            }

        public Project(string name)
            : this(name, DateTime.Now) { }

        public Project(string name,
                DateTime expirationDate)
                : this(name, expirationDate, 0) { }

        public Project(string name,
            DateTime expirationDate,
            int maxHours)
            : this(name, expirationDate, maxHours, "0000U") { }

        public Project(string name,
            DateTime expirationDate,
            int maxHours,
            string leaderUserId)
        {
            Name = name;
            ExpirationDate = expirationDate;
            MaxHours = maxHours;
            LeaderUserId = leaderUserId;
        }

        public static int Count = 1;

        public DateTime ViewingDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int MaxHours { get; set; }
        public int MaxHoursPerMonth { get; set; }
        public string LeaderUserId { get; set; }

        public override void Print()
        {
            Console.WriteLine($"ID: {Id}" +
                              $"Name: {Name}" +
                              $"Creation: {CreationDateTime}" +
                              $"Expiration: {ExpirationDate}" +
                              $"MaxHours: {MaxHours}" +
                              $"LeaderUserId {LeaderUserId}");
        }
    }
}