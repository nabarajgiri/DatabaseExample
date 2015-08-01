using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Framework.Models
{
    
    public class Course
    {
        public int Id{get; set;}
        public string Name { get; set;}
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public  string DurationType { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Status { get; set; }

    }
}
