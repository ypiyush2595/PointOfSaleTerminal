using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PointOfSaleServices.Contracts;
using System;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("api/terminal")]
    public class PointOfSaleController : ControllerBase
    {
        private readonly ILogger<PointOfSaleController> _logger;

        private readonly IPointOfSaleTerminal _pointOfSaleTerminal;

        public PointOfSaleController(ILogger<PointOfSaleController> logger, IPointOfSaleTerminal pointOfSaleTerminal)
        {
            _logger = logger;
            _pointOfSaleTerminal = pointOfSaleTerminal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var amount = _pointOfSaleTerminal.CalculateTotal();
                return Ok(amount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("scan")]
        public IActionResult ScanItem([FromBody] string itemName)
        {
            try
            {
                _pointOfSaleTerminal.Scan(itemName);
                return Ok("Item Scanned successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

    }
}
