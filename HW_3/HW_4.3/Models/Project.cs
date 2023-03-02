using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StertedDate { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
