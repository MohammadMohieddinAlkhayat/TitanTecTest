using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.DAL.Filters;
using TitanTecTest.DAL.Models;

namespace TitanTecTest.DAL.Repositories.IRepositories
{
    public interface IEmployeeFileRepository : IBaseRepository<EmployeeFile, EmployeeFileFilter>
    {

    }
}
