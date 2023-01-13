using ExportingComponent.NewFolder;

namespace ExportingComponent.Interfaces
{
    public interface ICSVExporter
    {
        public string SaveToCSV(IEnumerable<FlyRoute> routes);
    }
}
