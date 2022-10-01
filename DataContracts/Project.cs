
namespace DataContracts
{
    public class Project : BaseEntity
    {
        public Project(string name)
            : this(name, DateTime.Now)
        {
            Id = string.Format("{0:d4}P", Count++); //P-project
            Name = name;
            CreationDateTime = DateTime.Now;
        }

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
            Console.WriteLine($"ID: {Id} \n" +
                              $"Name: {Name} \n" +
                              $"Expiration: {ExpirationDate} \n" +
                              $"Max hours: {MaxHours} \n" +
                              $"Leader userId {LeaderUserId} \n" +
                              "Created \n");
        }
    }
}