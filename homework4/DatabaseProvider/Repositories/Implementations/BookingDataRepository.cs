using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProvider.Repositories.Implementations
{
    public class BookingDataRepository : Repository<BookingData>, IBookingDataRepository
    {
        public BookingDataRepository(ApplicationContext context) 
            : base(context)
        {
        }

        public List<BookingData> GetAll()
        {
            return Entities.ToList();
        }

        public BookingData GetById(int id)
        {
            return Entities.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
