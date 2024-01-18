using HistoricalEventExporter.Abstraction;
using Microsoft.Extensions.Logging;

namespace HistoricalEventExporter.Exporters
{
    public class EventExporter : IEventExporter, IHostedService
    {
        private readonly ILogger<EventExporter> _logger;

        public EventExporter(
            ILogger<EventExporter> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starts Hosted service");

        }

        public async Task StartExportAsync()
        {
            _logger.LogInformation("Starts Exporting");
            await StartAsync(new CancellationToken());
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stops Hosted service");

        }

        public async Task StopExportAsync()
        {

            _logger.LogInformation("Stops Exporting");
        }
    }
}
