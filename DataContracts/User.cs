
namespace DataContracts
{
    public class User : BaseEntity
    {
        public static Dictionary<string, User> UserDictionary = new Dictionary<string, User>();
        public static int Count = 1;

        public delegate void AccountHandler(string message);
        public event AccountHandler? Notify;

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
            Notify?.Invoke(""); //DELETE
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
