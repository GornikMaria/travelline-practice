using System.Collections.Generic;

namespace Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Car { get; set; }

        public List<Car> Cars { get; set; }

        public List<BookingData> BookingData { get; set; }
    }
}
