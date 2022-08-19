using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TitanTecTest.BL.Helpers;
using TitanTecTest.BL.Services.BaseServices;
using TitanTecTest.BL.Services.Employees.Dtos;
using TitanTecTest.BL.Services.ServicesPool;
using TitanTecTest.DAL.Filters;
using TitanTecTest.DAL.Models;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.BL.Services.Employees
{
    public class EmployeeService : BaseService, IBaseService
    {

        public EmployeeService(IUnitOfWork unitOfWork, ServicePool otherServices, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, otherServices, httpContextAccessor)
        {

        }
        public async Task<List<Employee>> GetEmployees(EmployeeFilter filter)
        {
            int count = 0;
            var list = UnitOfWork.EmployeeRepository.GetFilteredItems(filter, out count);
            foreach (var employee in list)
            {
                employee.Files = UnitOfWork.EmployeeFileRepository.GetItems(0, int.MaxValue, e => e.EmployeeId == employee.Id);
                
                foreach (var file in employee.Files)
                {
                    file.Name = EnumHelper.GetUrl(file.Name);
                }
            }
            
            return await Task.FromResult(list);
        }
        public Task<Employee> GetEmployee(int id)
        {
            try
            {
                var employee = UnitOfWork.EmployeeRepository.GetById(id);
                if (employee is not null)
                {
                    employee.Files = UnitOfWork.EmployeeFileRepository.GetItems(0, int.MaxValue, e => e.EmployeeId == employee.Id);
                    foreach (var file in employee.Files)
                    {
                        file.Name = EnumHelper.GetUrl(file.Name);

                    }
                }
                return Task.FromResult(employee);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task <bool> CreateEmployee(Employee employee,List<string>files)
        {
            try
            {
                foreach(var file in files)
                {
                    var employeeFile = new EmployeeFile()
                    {
                        Name = file,
                        FileSize = OtherServices.FileService.CalculteFileSize(file)
                    };
                    employee.Files.Add(employeeFile);
                }   
                 UnitOfWork.EmployeeRepository.Insert(employee);
                 UnitOfWork.SaveAllChanges();
                return await Task.FromResult(true);

            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee,List<string> files)
        {
            try
            {
                employee.Files = UnitOfWork.EmployeeFileRepository.GetItems(0, int.MaxValue, e => e.EmployeeId == employee.Id);
                if (employee.Files.Count > 0)
                {
                    
                    foreach (EmployeeFile file in employee.Files)
                    {
                        
                        if (File.Exists(Path.Combine(AppConst.ContentFolder, file.Name.Replace(AppConst.FileSiteURL, ""))))
                        {
                            File.Delete(Path.Combine(AppConst.ContentFolder, file.Name.Replace(AppConst.FileSiteURL, "")));
                        }
                        UnitOfWork.EmployeeFileRepository.Delete(file);
                    }
                }
                foreach (var file in files)
                {
                    var employeeFile = new EmployeeFile()
                    {
                        Name = file,
                        FileSize = OtherServices.FileService.CalculteFileSize(file),
                        EmployeeId = employee.Id

                    };
                    UnitOfWork.EmployeeFileRepository.Insert(employeeFile);
                }
                UnitOfWork.EmployeeRepository.Update(employee);
                UnitOfWork.SaveAllChanges();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw;
            }
           
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee= UnitOfWork.EmployeeRepository.GetById(id);
            try
            {
                employee.Files = UnitOfWork.EmployeeFileRepository.GetItems(0, int.MaxValue, e => e.EmployeeId == employee.Id);
                if (employee.Files.Count > 0)
                {

                    foreach (EmployeeFile file in employee.Files)
                    {
                        
                        if (File.Exists(Path.Combine(AppConst.ContentFolder, file.Name.Replace(AppConst.FileSiteURL, ""))))
                        {
                            File.Delete(Path.Combine(AppConst.ContentFolder, file.Name.Replace(AppConst.FileSiteURL, "")));
                        }
                        UnitOfWork.EmployeeFileRepository.Delete(file);
                      
                    }
                }
                UnitOfWork.EmployeeRepository.Delete(employee);
                UnitOfWork.SaveAllChanges();
                return true;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        

    }
}
