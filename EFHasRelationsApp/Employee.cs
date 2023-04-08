using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFHasRelationsApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { set; get; }
        public List<Project> Projects { get; set; } = new();

        //public EmployeeInfo? Info { set; get; }
        //public virtual Company? Company { set; get; }
        //public int? CompanyId { set; get; }
    }
}
