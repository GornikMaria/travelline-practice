using System.Collections.Generic;

namespace Core.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        //public List<Client> Clients { get; set; }
        public List<BookingData> BookingData { get; set; }
    }
}
