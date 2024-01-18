namespace HistoricalEventExporter.Abstraction
{
    public interface IEventPublisher<T>
    {
        Task PublishEventsAsync(IEnumerable<T> eventsList);
    }
}
