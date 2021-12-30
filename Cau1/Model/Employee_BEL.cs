using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.Model
{
    public class Employee_BEL
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Gender { get; set; }
        public string Place { get; set; }
        public Department_BEL Department { get; set; }
        public string DepartName { get { return Department.Name; } }

    }
}
