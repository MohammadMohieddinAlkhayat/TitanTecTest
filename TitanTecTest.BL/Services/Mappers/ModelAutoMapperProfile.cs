using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.BL.Results;
using TitanTecTest.BL.Services.Employees.Dtos;
using TitanTecTest.DAL.Models;

namespace TitanTecTest.BL.Services.Mappers
{
    public class ModelAutoMapperProfile:Profile
    {
        public  ModelAutoMapperProfile()
        {
            //CreateMap<CreateEmployeeDto, Employee>();

            //CreateMap<Employee, EmployeeResult>();
            

            //CreateMap<List<Employee>, ListResult<EmployeeResult>>()
            //  .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));



        }
    }
}
