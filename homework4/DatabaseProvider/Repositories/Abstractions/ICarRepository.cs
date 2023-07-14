using Core.Models;
using System.Collections.Generic;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface ICarRepository : IRepository<Car>
    {
        public List<Car> GetAll();
        public Car GetById(int id);
        public List<Car> GetByAuthorId(int id);
    }
}
