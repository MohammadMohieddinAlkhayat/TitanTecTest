using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TitanTecTest.DAL.Repositories.IRepositories
{
  public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeFileRepository EmployeeFileRepository { get; }
        bool SaveAllChanges(bool updateLoggingInfo = true);
    }
}
