using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseComponent.Entitities
{
    public class TravelSegmentJPA
    {
        public Guid Id { get; set; }
        public Boolean isTrain { get; set; }
        public Boolean isBoat { get; set; }
        public Boolean isFlight { get; set; }
        public string suborigin { get; set; }
        public string subdestination { get; set; }
        public int price { get; set; }
        public int duration { get; set; }
        public BookingsJPA bookingid { get; set; }
    }
}
