using HistoricalEventExporter.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalEventExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportController : ControllerBase
    {
        private readonly IEventExporter _exporter;
        public ExportController(IEventExporter exporter)
        {
            _exporter = exporter;
        }

        [HttpGet("StartExport")]
        public IActionResult Get()
        {
            _exporter.StartExportAsync();
            return Ok();
        }
    }
}
