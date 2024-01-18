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
            var batchSize = 150;

            var batches = Batch<T>(eventsList.ToList(), batchSize);

            foreach (var batch in batches)
            {
                var publishTask = batch.Select(evnt => PublishEventAsync(evnt));
                await Task.WhenAll(publishTask);
                _logger.LogInformation(batchSize + " events published");
            }
        }

        private async Task PublishEventAsync(T @event)
        {
            await Task.Delay(500);
            _logger.LogInformation($"Publishing {@event.GetType().Name}");
        }

        static List<List<T>> Batch<T>(List<T> source, int batchSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / batchSize)
                .Select(g => g.Select(x => x.Value).ToList())
                .ToList();
        }
    }
}
