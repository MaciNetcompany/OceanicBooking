using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseComponent.Entitities
{
    public class BookingsJPA
    {
        public Guid ID { get; set; }
        public int FromCityId{ get; set; }
        public int ToCityId { get; set; }
        public int Weight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int DeliveryTime { get; set; }
        public Boolean IsRefrigerated { get; set; }
        public Boolean ContainsCautiousGoods { get; set; }
        public Boolean ContainsWeapons { get; set; }
        public DateTime RequestedAtDate { get; set; }
  
    }
}
