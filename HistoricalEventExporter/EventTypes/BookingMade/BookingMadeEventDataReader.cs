using HistoricalEventExporter.Abstraction;

namespace HistoricalEventExporter.EventTypes.BookingMadeEvent
{
    public class BookingMadeEventDataReader : IEventDataReader<BookingMadeEvent>
    {
        public async Task<IEnumerable<BookingMadeEvent>> GetDataAsync()
        {
            //TODO: Replace With real data source
            var bookingMadeEvents = new List<BookingMadeEvent>();

            for (int i = 0; i < 1000; i++)
            {
                bookingMadeEvents.Add(new BookingMadeEvent { OrganisationId = i });
            }

            await Task.Delay(1000);

            return bookingMadeEvents;
        }
    }
}
