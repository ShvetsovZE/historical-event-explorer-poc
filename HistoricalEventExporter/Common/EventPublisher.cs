using HistoricalEventExporter.Abstraction;
using Microsoft.Extensions.Logging;

namespace HistoricalEventExporter.Common
{
    public class EventPublisher<T> : IEventPublisher<T>
    {
        private readonly ILogger<EventPublisher<T>> _logger;  
       
        public EventPublisher(ILogger<EventPublisher<T>> logger)
        {
            _logger = logger;

        }
        public async Task PublishEventsAsync(IEnumerable<T> eventsList)
        {
            foreach (var @event in eventsList)
            {
                _logger.LogInformation($"Publishing {@event.GetType().Name}");
            }
        }
    }
}
