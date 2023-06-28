using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Data.Helprs
{
    public class BaseModel
    {
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set;}
        public string? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
