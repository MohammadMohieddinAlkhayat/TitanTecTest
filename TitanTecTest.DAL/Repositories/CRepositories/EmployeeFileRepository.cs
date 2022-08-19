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
    public class EmployeeFileRepository : BaseRepository<EmployeeFile, EmployeeFileFilter>, IEmployeeFileRepository
    {
        public EmployeeFileRepository(ApplicationDbContext db) : base(db)
        {
        }

        public override Expression<Func<EmployeeFile, bool>> IsActiveCondition => EmployeeFile => true;

        public override List<EmployeeFile> GetFilteredItems(EmployeeFileFilter filters, out int filteredRecords)
        {

            IQueryable<EmployeeFile> filteredEmployees = this.DBQueryable.AsQueryable();
            if (filters.EmployeeId.HasValue)
                filteredEmployees = filteredEmployees.Where(_item => _item.EmployeeId == filters.EmployeeId.Value&&!_item.IsDeleted);
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
        public override List<EmployeeFile> GetItems(int page, int pageLength, Expression<Func<EmployeeFile, bool>> condition = null)
        {
            var records = this.GetNewQuary().AsQueryable();

            if (condition != null)
                records = records.Where(condition);

            return records.Skip(page * pageLength).Take(pageLength).ToList();
        }
    }
}
