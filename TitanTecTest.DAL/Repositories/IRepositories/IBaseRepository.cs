using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.DAL.Filters;
using TitanTecTest.DAL.Models.EntityBase;

namespace TitanTecTest.DAL.Repositories.IRepositories
{
   public interface IBaseRepository<DbModel, Filter> where DbModel : class, IEntityBaseModel where Filter : BaseFilter
    {
        List<DbModel> GetItems(int page, int pageLength, Expression<Func<DbModel, bool>> condition = null);
        List<DbModel> GetFilteredItems(Filter filters, out int filteredRecords);
        DbModel GetById(int id);
        IEnumerable<DbModel> GetAll();
        DbModel Insert(DbModel newObj);
        void Update(DbModel newObj);
        void Delete(int id);
        void Delete(DbModel obj);

        bool IsActive(object id);

    }
}
