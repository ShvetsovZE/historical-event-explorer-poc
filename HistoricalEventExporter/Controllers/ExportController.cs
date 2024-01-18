using HistoricalEventExporter.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalEventExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportController : ControllerBase
    {
        private readonly IEventExporter<TeamMemberInvitedEvent> _teamMemberInvitedEventExporter;
        private readonly IEventExporter<BookingMadeEvent> _bookingMadeEventExporter;

        public ExportController(
            IEventExporter<TeamMemberInvitedEvent> teamMemberInvitedEventExporter,
            IEventExporter<BookingMadeEvent> bookingMadeEventExporter
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
