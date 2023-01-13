using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseComponent.Entitities;
using ExportingComponent.Models;

namespace ExportingComponent.NewFolder
{
    public class FlyRoute
    {
        private Guid bookingID;
        public long RouteID { get; set; }
        public DateTime Date { get; set; }
        public string SourcePoint { get; set; }
        public string DestinationPoint { get; set; }
        public decimal Weight { get; set; }
        public decimal[] Dimensions { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public IEnumerable<object> ToListOfRecords()
        {
            var records = new List<object>();
            records.Add(RouteID);
            records.Add(Date);
            records.Add(SourcePoint);
            records.Add(DestinationPoint);
            records.Add(Weight);
            records.Add(Dimensions);
            records.Add(Price);
            records.Add(Category);
            return records;
        }
        public string ToCSVRow()
        {
            return $@"{this.RouteID},{this.Date},{this.SourcePoint},{this.DestinationPoint},{this.Weight},{this.Dimensions[0]};{this.Dimensions[1]};{this.Dimensions[2]},{this.Price},{this.Category}";
        }

        public void PopulateFromBookingDB(BookingsJPA booking)
        {
            this.Category=booking.ContainsWeapons?"Weapons":(booking.ContainsCautiousGoods? "Cautious goods":(booking.IsRefrigerated?"Refrigerated":"None"));
            this.Date = booking.RequestedAtDate;
            this.DestinationPoint = booking.ToCityId.ToString();
            this.SourcePoint = booking.FromCityId.ToString();
             this.Dimensions = new decimal[3] { booking.Width, booking.Height, booking.Length };
             this.Weight=booking.Weight;
             this.bookingID = booking.ID;
             // this.Price=booking.
        }


        public void PopulateFromCitiesDB(IEnumerable<CitiesJPA> cities)
        {
            var startCity = cities.Single(x => x.Id.ToString().Equals(this.SourcePoint));
            var endCity = cities.Single(x => x.Id.ToString().Equals(this.DestinationPoint));
            this.SourcePoint = startCity.Name;
            this.DestinationPoint = endCity.Name;
        }
        public void PopulateFromFlightsDB(IEnumerable<FlightsJPA> flights)
        {
            var relevantFlights = flights.Where(x => x.order_booking_id == this.bookingID);
            decimal price = 0;
            foreach (var relevantFlight in relevantFlights)
            {
                price+=relevantFlight.price;
            }
        }
    }
}
