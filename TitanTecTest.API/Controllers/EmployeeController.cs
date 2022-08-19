using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TitanTecTest.BL.Results;
using TitanTecTest.BL.Services.Employees.Dtos;
using TitanTecTest.BL.Services.ServicesPool;
using TitanTecTest.DAL.Filters;
using TitanTecTest.DAL.Models;

namespace TitanTecTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : BaseController
    {
        private IMapper _mapper;

        public EmployeeController(IServicePool servicePool, IHttpContextAccessor httpContextAccesor,IMapper mapper) : base(servicePool, httpContextAccesor)
        {
            _mapper = mapper;
        }




        [HttpGet("{id}")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(ApiResult))]
        public async Task<ApiResult> GetEmployee(int id)
        {                                                                                                       
            
            var result = await AllServices.EmployeeService.GetEmployee(id);                                                                                     
            return await Task.FromResult(new ApiResult<EmployeeResult>(true, message: "Success")
            {
                Result= AllServices.MappingService.Map<EmployeeResult>(result)
            });
        }

        [HttpGet]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(ApiResult<ListResult<EmployeeResult>>))]
        public async Task<ApiResult> GetEmployees(int? page, int? pageLength,string searchQuery)
        {
            EmployeeFilter filter = new EmployeeFilter
            {
                Page = page!=null ?(int)page:0,
                PageLength= pageLength != null ? (int)pageLength : 10,
                SearchQuery=searchQuery!=null ? searchQuery : null
            };
            
            var result = await AllServices.EmployeeService.GetEmployees(filter);
            return await Task.FromResult(new ApiResult<ListResult<EmployeeResult>>(true, message: "Success")
            {
                Result = new ListResult<EmployeeResult>()
                {
                    Items = AllServices.MappingService.Map<List<EmployeeResult>>(result)

                }
            });
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiResult))]
        public async Task<ApiResult> PutEmployee(UpdateEmployeeDto employee)
        {            
            if (await AllServices.EmployeeService
                .UpdateEmployee(AllServices.MappingService.Map<Employee>(employee),employee.EmployeeFiles))
                return await Task.FromResult(this.BasicSuccessHandler());
            return await Task.FromResult(this.BasicErrorHandler("EntityNotUpdate"));


        }

        //POST: api/Users
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiResult))]
        public async Task<ApiResult> PostEmployee(CreateEmployeeDto employee)
        {

            if(await AllServices.EmployeeService.
                CreateEmployee(AllServices.MappingService.Map<Employee>(employee),employee.EmployeeFiles))
            return await Task.FromResult(this.BasicSuccessHandler());
            return await Task.FromResult(this.BasicErrorHandler("OperationFailed"));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiResult))]
        public async Task<ApiResult> DeleteEmployee(int id)
        {
            if(await AllServices.EmployeeService.GetEmployee(id) is null)
                return await Task.FromResult(this.BasicErrorHandler("EntityNotFound"));
            if (await AllServices.EmployeeService.DeleteEmployee(id))
            return await Task.FromResult(this.BasicSuccessHandler());
            return await Task.FromResult(this.BasicErrorHandler("EntityNotDeleted"));
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiResult<UploadFileResult>))]
        public async Task<ApiResult> Upload(IFormFile file)
        {
            var result= await AllServices.FileService.UploadImageAsync(string.Empty, false);
            
            return await Task.FromResult(new ApiResult<UploadFileResult>(true, message: "Success")
            {
                Result = result
                
            });

        }








    }
}
