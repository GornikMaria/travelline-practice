using System.Collections.Generic;

namespace Core.Models
{
    public class BookingData
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Pay { get; set; }

        public List<Client> Clients { get; set; }
        public List<Car> Cars { get; set; }
    }
}
