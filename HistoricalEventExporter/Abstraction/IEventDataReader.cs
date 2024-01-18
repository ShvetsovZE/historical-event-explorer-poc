namespace HistoricalEventExporter.Abstraction
{
    public interface IEventDataReader<T>
    {
        Task<IEnumerable<T>> GetDataAsync();
    }
}
