using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.DAL.Repositories.CRepositories
{
    public class UnitOfWork : IUnitOfWork

    {
        ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public Dictionary<Type, object> InitializedRepos = new Dictionary<Type, object>();

        public IEmployeeRepository EmployeeRepository { get => (IEmployeeRepository)GetRepo(typeof(EmployeeRepository));}
        public IEmployeeFileRepository EmployeeFileRepository { get => (IEmployeeFileRepository)GetRepo(typeof(EmployeeFileRepository)); }

        
        private object GetRepo(Type type)
        {
            object repo = null;
            var initialized = InitializedRepos.TryGetValue(type, out repo);
            if (repo == null)
            {
                repo = Activator.CreateInstance(type, _dbContext);
                InitializedRepos[type] = repo;
            }
            return repo;
        }
        public virtual bool SaveAllChanges(bool updateLoggingInfo = true)
        {
            return _dbContext.ChangeTracker.HasChanges() ? _dbContext.SaveChanges() > 0 ? true : false : false;
        }

    }
}
