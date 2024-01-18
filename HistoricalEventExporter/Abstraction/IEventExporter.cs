namespace HistoricalEventExporter.Abstraction
{
    public interface IEventExporter
    {
        Task StartExportAsync();
        Task StopExportAsync();
    }
}
