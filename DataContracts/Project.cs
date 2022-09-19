using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    internal class Project : BaseEntity
    {
        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public int MaxHours { get; set; }
        public int LeaderUserId { get; set; }
    }
}