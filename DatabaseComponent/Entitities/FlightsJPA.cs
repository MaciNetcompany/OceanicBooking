using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseComponent.Entitities
{
    public class FlightsJPA
    {
        public Guid ID { get; set; }

        public BookingsJPA order_booking_id { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string category { get; set; }
        public int ParcelWeight { get; set; }
        public string dimension { get; set; }
        public int price { get; set; }
        public DateTime requestDate { get; set; }
    }
}
