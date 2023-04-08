using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFHasRelationsApp
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { set; get; }
        //public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
