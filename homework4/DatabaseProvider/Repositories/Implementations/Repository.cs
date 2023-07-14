using DatabaseProvider.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace DatabaseProvider.Repositories.Implementations
{
    public class Repository<TEnity> : IRepository<TEnity>
        where TEnity : class
    {
        protected DbSet<TEnity> Entities { get; }
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
            Entities = _context.Set<TEnity>();
        }

        public void Add(TEnity entity)
        {
            Entities.Add(entity);
        }

        public void Add(IEnumerable<TEnity> entities)
        {
            Entities.AddRange(entities);
        }

        public void Remove(TEnity entity)
        {
            Entities.Remove(entity);
        }

        public void Remove(IEnumerable<TEnity> entities)
        {
            Entities.RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
