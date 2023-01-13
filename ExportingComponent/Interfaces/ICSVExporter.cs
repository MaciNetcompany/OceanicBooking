using DatabaseComponent.Entitities;
using ExportingComponent.NewFolder;

namespace ExportingComponent.Interfaces
{
    public interface ICSVExporter
    {
        public string SaveToCSV(IEnumerable<FlyRoute> routes);
        public string SaveToCSV(IEnumerable<BookingsJPA> routes, IEnumerable<CitiesJPA> cities, IEnumerable<FlightsJPA> flights);
    }
}
