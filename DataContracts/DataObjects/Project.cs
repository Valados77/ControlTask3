namespace DataContracts.DataObjects
{
    public class Project : BaseEntity
    {
        public static int Count = 1;

        public List<DateTime> ViewingDateTime { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int MaxHours { get; set; }
        public int MaxHoursPerMonth { get; set; }
        public string LeaderUserId { get; set; }

        public Project(string name)
            : this(name, DateTime.Now)
        {
            Id = $"{Count++:d4}P"; //P-project
            Name = name;
            SubmitDateTime = DateTime.Now;
            ViewingDateTime = new List<DateTime>();
            MaxHoursPerMonth = 0;
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
            Name = name;
            ExpirationDate = expirationDate;
            MaxHours = maxHours;
            LeaderUserId = leaderUserId;
        }
    }
}