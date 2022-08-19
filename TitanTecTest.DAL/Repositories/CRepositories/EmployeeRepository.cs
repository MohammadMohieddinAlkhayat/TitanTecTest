using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.DAL.Filters;
using TitanTecTest.DAL.Models;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.DAL.Repositories.CRepositories
{
    public class EmployeeRepository : BaseRepository<Employee, EmployeeFilter>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
        }

        public override Expression<Func<Employee, bool>> IsActiveCondition => Employee => true;


        public override List<Employee> GetFilteredItems(EmployeeFilter filters, out int filteredRecords)
        {
            this.DBQueryable = this.DBQueryable.Include(c => c.Files);
            IQueryable<Employee> filteredEmployees = DBQueryable.AsQueryable();
            //status filtering
            if (filters.Status.HasValue)
                filteredEmployees = filteredEmployees.Where(_item => _item. IsActive== filters.Status.Value&&!_item.IsDeleted);

            //search query
            if (!string.IsNullOrEmpty(filters.SearchQuery))
                filteredEmployees = filteredEmployees
                    .Where(_item =>
                    _item.Name.Contains(filters.SearchQuery));

            switch (filters.OrderBy)
            {
                default:
                    filteredEmployees = filteredEmployees.OrderByDescending(i => i.LastModificationTime);
                    break;
            }

            filteredRecords = filteredEmployees.Count();
            filteredEmployees = filteredEmployees.Skip(filters.ElementsToBeSkipedCount).Take(filters.PageLength);
            return filteredEmployees.ToList();
        }

        public override List<Employee> GetItems(int page, int pageLength, Expression<Func<Employee, bool>> condition = null)
        {
            var records = this.GetNewQuary().Include(c => c.Files)
                .AsQueryable();

            if (condition != null)
                records = records.Where(condition);

            return records.Skip(page * pageLength).Take(pageLength).ToList();
        }
    }
}
