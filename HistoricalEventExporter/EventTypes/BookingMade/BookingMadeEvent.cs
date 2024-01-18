namespace HistoricalEventExporter.EventTypes.BookingMadeEvent
{
    public record BookingMadeEvent
    {
        public int OrganisationId { get; init; }
    }
}
