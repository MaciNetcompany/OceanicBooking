using ExportingComponent.NewFolder;

namespace ExportingComponent.Interfaces
{
    public interface ICSVExporter
    {
        public bool SaveToCSV(IEnumerable<FlyRoute> routes);
    }
}
