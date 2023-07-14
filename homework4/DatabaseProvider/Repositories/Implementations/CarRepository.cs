using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Repositories.Implementations
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        
        public CarRepository(ApplicationContext context)
            : base(context)
        {
        }
        public List<Car> GetAll()
        {
            return Entities.Include(b => b.Client).ToList();
        }

        public List<Car> GetByAuthorId(int id)
        {
            return Entities.Include(b => b.Client).Where(b => b.ClientId == id).ToList();
        }

        public Car GetById(int id)
        {
            return Entities.Include(b => b.Client).Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
