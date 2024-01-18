using HistoricalEventExporter.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalEventExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportController : ControllerBase
    {
        private readonly IEventExporter<EventTypes.TeamMemberInvitedEvent.TeamMemberInvitedEvent> _teamMemberInvitedEventExporter;
        private readonly IEventExporter<EventTypes.BookingMadeEvent.BookingMadeEvent> _bookingMadeEventExporter;

        public ExportController(
            IEventExporter<EventTypes.TeamMemberInvitedEvent.TeamMemberInvitedEvent> teamMemberInvitedEventExporter,
            IEventExporter<EventTypes.BookingMadeEvent.BookingMadeEvent> bookingMadeEventExporter
            )
        {
            _teamMemberInvitedEventExporter = teamMemberInvitedEventExporter;
            _bookingMadeEventExporter = bookingMadeEventExporter;
        }

        [HttpGet("StartExport")]
        public IActionResult Get()
        {
            _teamMemberInvitedEventExporter.StartExportAsync();
            _bookingMadeEventExporter.StartExportAsync();
            return Ok();
        }
    }
}
