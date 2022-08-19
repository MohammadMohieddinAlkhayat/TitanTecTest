using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.BL.Services.ServicesPool;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.BL.Services.BaseServices
{
    public class BaseService: IBaseService
    {
        public IUnitOfWork UnitOfWork { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }
        public IServicePool OtherServices { get; }

        public IMapper Mapper
        {
            get
            {
                return (IMapper)HttpContextAccessor?.HttpContext?.RequestServices.GetService(typeof(IMapper));
            }
        }

        public BaseService(IUnitOfWork unitOfWork,ServicePool otherServices, IHttpContextAccessor httpContextAccessor)
        {
            UnitOfWork = unitOfWork;
            HttpContextAccessor = httpContextAccessor;
            OtherServices = otherServices;
        }



    }
}
