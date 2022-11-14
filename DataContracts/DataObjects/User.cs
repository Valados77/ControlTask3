namespace DataContracts.DataObjects
{
    public class User : BaseEntity
    {
        public static int Count = 1;

        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public Enums.AccessRoles AccessRole { get; set; }

        public User(string username,
            string password,
            Enums.AccessRoles accessRole)
            : this(username, password, accessRole, "unknown")
        {
            Id = string.Format("{0:d4}U", Count++); //U-user
            Username = username;
            Password = password;
            AccessRole = accessRole;
        }

        public User(string username,
            string password,
            Enums.AccessRoles accessRole,
            string fullName)
        {
            Username = username;
            Password = password;
            FullName = fullName;
        }

        public override void Print()
        {
            Console.WriteLine($"ID: {Id}\t" +
                              $"Username: {Username}\t" +
                              $"Full name: {FullName}\t" +
                              $"Is active: {IsActive}\t" +
                              $"Access role: {AccessRole}");
        }
    }
}