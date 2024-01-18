using HistoricalEventExporter.Abstraction;
using Microsoft.Extensions.Logging;

namespace HistoricalEventExporter.Exporters
{
    public class EventExporter<T> : IEventExporter<T>, IHostedService
    {
        private readonly ILogger<EventExporter<T>> _logger;
        private readonly IEventDataReader<T> _eventDataReader;
        private readonly IEventPublisher<T> _eventPublisher;

        public EventExporter(
            IEventDataReader<T> eventDataReader,
            IEventPublisher<T> eventPublisher,
            ILogger<EventExporter<T>> logger)
        {
            _eventDataReader = eventDataReader;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starts Hosted service for {typeof(T).Name} event type export");

            var events = await _eventDataReader.GetDataAsync();
            _logger.LogInformation($"Found {events.Count()} events of type {typeof(T).Name}");
            
            await _eventPublisher.PublishEventsAsync(events);

           await StopAsync(cancellationToken);

        }

        public async Task StartExportAsync()
        {
            _logger.LogInformation($"Starts Exporting events type: {typeof(T).Name}");

            await StartAsync(new CancellationToken());
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Stops Hosted service for {typeof(T).Name} event type export");

        }

        public async Task StopExportAsync()
        {

            _logger.LogInformation($"Stops Exporting events type: {typeof(T).Name}");
        }

    }
}
