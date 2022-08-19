using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.DAL.Filters;
using TitanTecTest.DAL.Models.EntityBase;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.DAL.Repositories.CRepositories
{
    public abstract class BaseRepository<DbModel, Filter> : IBaseRepository<DbModel, Filter> where DbModel : class, IEntityBaseModel where Filter : BaseFilter
    {

        #region protected Attributes
        protected ApplicationDbContext _db { get; }
        private DbSet<DbModel> _dbSet { get; }
        protected IQueryable<DbModel> DBQueryable { get; set; }
        #endregion


        public abstract Expression<Func<DbModel, bool>> IsActiveCondition { get; }

        public BaseRepository(ApplicationDbContext db)
        {
            this._db = db;
            _dbSet = db?.Set<DbModel>();
            DBQueryable = _dbSet.AsQueryable();
        }
        public void Delete(int id)
        {
            DbModel obj = this.GetById(id);
            this.Delete(obj);
        }
        public void Delete(DbModel obj)
        {
            _dbSet.Attach(obj);
            _dbSet.Remove(obj);
        }

        public IEnumerable<DbModel> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public DbModel Insert(DbModel newObj)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<DbModel> added = _dbSet.Add(newObj);
            return added.Entity;
        }

        public void Update(DbModel newObj)
        {

            _db.Entry(newObj).State = EntityState.Modified;
          
        }

        public DbModel GetById(int id)
        {
            Microsoft.EntityFrameworkCore.Metadata.IProperty keyProperty = _db.Model.FindEntityType(typeof(DbModel)).FindPrimaryKey().Properties[0];
            return DBQueryable.FirstOrDefault(e => EF.Property<int>(e, keyProperty.Name) == (int)id);

        }

        

        /// <summary>
        /// Render DbModel After Geting it from Db To Get Related Datea
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected virtual DbModel RenderDbModel(DbModel model)
        {
            return model;
        }


        /// <summary>
        /// Render ListOf Models after getting them from databaseto get related data
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        protected List<DbModel> RenderDbModels(List<DbModel> models)
        {
            models.ForEach(item =>
            {
                RenderDbModel(item);
            });
            return models;
        }

        protected IQueryable<DbModel> GetNewQuary(bool readOnlyData = false)
        {
            if (readOnlyData)
                return _db.Set<DbModel>().AsNoTracking();
            return _db.Set<DbModel>().AsQueryable();
        }


    
        protected List<DbModel> TakeActiveItemFromQuery(int pageNum, int pageLength, IQueryable<DbModel> query)
        {
            query = query.Where(IsActiveCondition);
            return query.Skip(pageNum * pageLength).Take(pageLength).ToList();
        }
        public virtual DbModel GetById(object id)
        {
            if (id == null)
                return null;
            int realId = -1;
            bool isParsedSuccess = int.TryParse(id.ToString(), out realId);
            Microsoft.EntityFrameworkCore.Metadata.IProperty keyProperty = _db.Model.FindEntityType(typeof(DbModel)).FindPrimaryKey().Properties[0];
            DbModel result = null;
            if (isParsedSuccess)
            {
                result = DBQueryable.FirstOrDefault(e => EF.Property<int>(e, keyProperty.Name) == (int)id);
            }
            else
            {
                result = DBQueryable.FirstOrDefault(e => EF.Property<string>(e, keyProperty.Name) == (string)id);
            }
            return RenderDbModel(result);
        }


        public bool IsActive(object id)
        {
            DbModel element = this.GetById(id);
            return IsActive(element);
        }

        public abstract List<DbModel> GetFilteredItems(Filter filters, out int filteredRecords);

        public virtual List<DbModel> GetItems(int page, int pageLength, Expression<Func<DbModel, bool>> condition = null)
        {
            IQueryable<DbModel> query = (condition != null) ? GetNewQuary().Where(condition).AsQueryable() : GetNewQuary().AsQueryable();
            List<DbModel> result = query.Skip(page * pageLength).Take(pageLength).ToList();
            return RenderDbModels(result);
        }

    }
}
