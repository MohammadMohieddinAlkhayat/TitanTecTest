using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanTecTest.BL.Services.BaseServices;
using TitanTecTest.BL.Services.Employees;
using TitanTecTest.BL.Services.ImplementedServices;

namespace TitanTecTest.BL.Services.ServicesPool
{
    public interface IServicePool
    {
        IBaseService BaseService { get; }
        EmployeeService EmployeeService { get; }
        MappingService MappingService { get; }
        FileService FileService { get; }

    }
}
