using Core.Models;
using System.Collections.Generic;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IBookingDataRepository : IRepository<BookingData>
    {
        public List<BookingData> GetAll();
        public BookingData GetById(int id);
    }
}
