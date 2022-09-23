using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    internal class Project : BaseEntity
    {
        public Project(string name, 
            string expirationDate, 
            int maxHours, 
            string leaderUserId)
        {
            Id = string.Format("{0:d4}P", Count++);
            Name = name;
            ExpirationDate = expirationDate;
            MaxHours = maxHours;
            LeaderUserId = leaderUserId;
        }

        public static int Count = 1;

        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public int MaxHours { get; set; }
        public string LeaderUserId { get; set; }
    }
}