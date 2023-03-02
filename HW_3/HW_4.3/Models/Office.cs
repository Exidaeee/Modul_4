using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3.Models
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Ttitle { get; set; }
        public string Location { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
