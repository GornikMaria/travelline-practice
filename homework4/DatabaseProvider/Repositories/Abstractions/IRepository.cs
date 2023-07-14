using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity);
        public void Add(IEnumerable<TEntity> entities);
        public void Remove(TEntity entity);
        public void Remove(IEnumerable<TEntity> entities);
        public void SaveChanges();
    }
}
