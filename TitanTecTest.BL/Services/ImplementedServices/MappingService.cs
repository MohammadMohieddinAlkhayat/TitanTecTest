using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.BL.Services.BaseServices;
using TitanTecTest.BL.Services.ServicesPool;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.BL.Services.ImplementedServices
{
    public class MappingService : BaseService, IBaseService
    {
        public MappingService(IUnitOfWork unitOfWork,ServicePool otherServices, IHttpContextAccessor httpContextAccessor) : base(unitOfWork,otherServices, httpContextAccessor)
        {
        }
        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public Destination Map<Source, Destination>(Source source, Action<IMappingOperationOptions<Source, Destination>> options)
        {
            return Mapper.Map(source, options);
        }

    }
}
