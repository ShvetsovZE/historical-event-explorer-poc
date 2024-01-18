namespace HistoricalEventExporter.Abstraction
{
    public interface IEventExporter<T>
    {
        Task StartExportAsync();
        Task StopExportAsync();
    }
}
