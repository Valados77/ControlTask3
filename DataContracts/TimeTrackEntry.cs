﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    internal class TimeTrackEntry : BaseEntity
    {
        public TimeTrackEntry(string userId, 
            string projectId, 
            int value)
        {
            UserId = userId;
            ProjectId = projectId;
            Value = value;
            Date = DateTime.Now;
        }
        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public int Value { get; }
        public DateTime Date { get; }
    }
}
