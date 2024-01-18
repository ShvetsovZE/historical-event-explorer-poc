using HistoricalEventExporter.Abstraction;
using Microsoft.Extensions.Logging;

namespace HistoricalEventExporter.Exporters
{
    public class EventExporter<T> : IEventExporter<T>, IHostedService
    {
        private readonly ILogger<EventExporter<T>> _logger;

        public EventExporter(
            ILogger<EventExporter<T>> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starts Hosted service for {typeof(T).Name} event type export");

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
