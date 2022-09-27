
namespace DataContracts
{
    public class User : BaseEntity
    {
        public User() : this("unknown")
        {
            Id = string.Format("{0:d4}U", Count++); //U-user
        }

        public User(string username)
            : this(username, "unknown") { }

        public User(string username,
            string password)
            : this(username, password, "unknown") { }

        public User(string username,
            string password, 
            string fullName) 
            : this(username, password, fullName, AccessRoles.Employee) { }

        public User(string username, 
            string password,
            string fullName,
            AccessRoles accessRole)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            AccessRole = accessRole;
        }

        public static int Count = 1;
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public AccessRoles AccessRole { get; set; }

        public override void Print()
        {
            Console.WriteLine($"ID: {Id}\t" +
                              $"Username: {Username}\t" +
                              $"FullName: {FullName}\t" +
                              $"IsActive: {IsActive}\t" +
                              $"AccessRole: {AccessRole}");
        }
    }
}

public enum AccessRoles
{
    Admin,
    Leader,
    Employee
}