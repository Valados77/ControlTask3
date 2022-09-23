using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    internal abstract class BaseEntity
    {
        public string Id { get; set; }
        public string Comment { get; set; }

        
    }
}
