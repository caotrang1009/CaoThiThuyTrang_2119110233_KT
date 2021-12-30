using Cau1.DAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class Department_BAL
    {
        Department_DAL dal = new Department_DAL();
        public List<Department_BEL> ReadDepartmentList()
        {
            List<Department_BEL> lstDepartment = dal.ReadDepartmentList();
            return lstDepartment;
        }
    }
}
