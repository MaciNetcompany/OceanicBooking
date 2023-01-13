using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportingComponent.Models;

namespace ExportingComponent.NewFolder
{
    public class FlyRoute
    {
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
    }
}
