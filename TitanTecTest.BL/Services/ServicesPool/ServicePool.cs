using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanTecTest.BL.Services.BaseServices;
using TitanTecTest.BL.Services.Employees;
using TitanTecTest.BL.Services.ImplementedServices;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.BL.Services.ServicesPool
{
    public class ServicePool : IServicePool
    {

        private IUnitOfWork _unitofWork;
        private IHttpContextAccessor _httpContextAccessor;
        public ServicePool(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public Dictionary<Type, object> InitializedServices { get; set; } = new Dictionary<Type, object>();

        private object GetRepo(Type type)
        {
            object repo = null;
            var initialized = InitializedServices.TryGetValue(type, out repo);
            if (repo == null)
            {
                repo = Activator.CreateInstance(type, _unitofWork,this, _httpContextAccessor);
                InitializedServices[type] = repo;
            }
            return repo;
        }
        public IBaseService BaseService { get => (BaseService)GetRepo(typeof(BaseService)); }
        public EmployeeService EmployeeService { get => (EmployeeService)GetRepo(typeof(EmployeeService)); }
        public MappingService MappingService { get => (MappingService)GetRepo(typeof(MappingService)); }
        public FileService FileService { get => (FileService)GetRepo(typeof(FileService)); }

    }
}
