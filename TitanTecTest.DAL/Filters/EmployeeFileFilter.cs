using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanTecTest.DAL.Filters
{
    public class EmployeeFileFilter : BaseFilter
    {
        public bool? Status { get; set; }

        public int?  EmployeeId { get; set; }

    }
}
