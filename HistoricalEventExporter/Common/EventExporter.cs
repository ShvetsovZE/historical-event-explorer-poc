using HistoricalEventExporter.Abstraction;
using Microsoft.Extensions.Logging;

namespace HistoricalEventExporter.Exporters
{
    public class EventExporter<T> : BackgroundService, IEventExporter<T>
    {
        private readonly ILogger<EventExporter<T>> _logger;
        private readonly IEventDataReader<T> _eventDataReader;
        private readonly IEventPublisher<T> _eventPublisher;
        private bool _ranManually = false; // added to skip startup execution

        public EventExporter(
            IEventDataReader<T> eventDataReader,
            IEventPublisher<T> eventPublisher,
            ILogger<EventExporter<T>> logger)
        {
            _eventDataReader = eventDataReader;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }


        public async Task StartExportAsync()
        {
            _logger.LogInformation($"Starts Exporting events type: {typeof(T).Name}");
            _ranManually = true;

            await ExecuteAsync(new CancellationToken());
        }

        public async Task StopExportAsync()
        {

            _logger.LogInformation($"Stops Exporting events type: {typeof(T).Name}");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_ranManually)
            {               
                    _logger.LogInformation($"Starts Background service for {typeof(T).Name} event type export");

                    var events = await _eventDataReader.GetDataAsync();
                    _logger.LogInformation($"Found {events.Count()} events of type {typeof(T).Name}");

                    await _eventPublisher.PublishEventsAsync(events);
                _logger.LogInformation($"Finished exporting events of type {typeof(T).Name}");
            }
            else
            {
                _logger.LogInformation($"Skipping startup execution");
            }
        }
    }
}
