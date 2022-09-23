using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    internal class User : BaseEntity
    {
        public User(string username, 
            string password,
            string fullName, 
            bool isActive, 
            AccessRoles accessRole)
        {
            Id = string.Format("{0:d4}U", Count++);
            Username = username;
            Password = password;
            FullName = fullName;
            IsActive = isActive;
            AccessRole = accessRole;
        }

        public static int Count = 1;
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public AccessRoles AccessRole { get; set; }
    }
}

internal enum AccessRoles
{
    Client,
    Administrator
}