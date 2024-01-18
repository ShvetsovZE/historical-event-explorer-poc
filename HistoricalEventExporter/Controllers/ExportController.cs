using HistoricalEventExporter.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalEventExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportController : ControllerBase
    {
        private readonly IEventExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent> _teamMemberInvitedEventExporter;
        private readonly IEventExporter<BookingMadeEvent.BookingMadeEvent> _bookingMadeEventExporter;

        public ExportController(
            IEventExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent> teamMemberInvitedEventExporter,
            IEventExporter<BookingMadeEvent.BookingMadeEvent> bookingMadeEventExporter
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
