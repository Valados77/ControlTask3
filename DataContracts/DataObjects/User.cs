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
        public string ProjectIdForUser { get; set; }

        public User(string username,
            string password,
            Enums.AccessRoles accessRole)
            : this(username, password, accessRole, "unknown")
        {
            Id = $"{Count++:d4}U"; //U-user
            Username = username;
            Password = password;
            AccessRole = accessRole;
        }

        public User(string username,
            string password,
            Enums.AccessRoles? accessRole,
            string fullName)
        {
            Username = username;
            Password = password;
            FullName = fullName;
        }
    }
}