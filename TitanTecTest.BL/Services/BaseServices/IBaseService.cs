using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.BL.Services.ServicesPool;

namespace TitanTecTest.BL.Services.BaseServices
{
    public interface IBaseService
    {
        IHttpContextAccessor HttpContextAccessor { get; }

        
        IServicePool OtherServices { get; }

    }
}
