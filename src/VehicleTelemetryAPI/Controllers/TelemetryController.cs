using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleTelemetryAPI.Models;

namespace VehicleTelemetryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelemetryController : ControllerBase
    {
        private static readonly List<TelemetryData> _telemetryData = new List<TelemetryData>();

        [HttpPost]
        public IActionResult Post([FromBody] TelemetryData telemetry)
        {
            if (telemetry == null || string.IsNullOrEmpty(telemetry.VehicleId))
            {
                return BadRequest("Invalid telemetry data.");
            }

            telemetry.Timestamp = DateTime.UtcNow;
            _telemetryData.Add(telemetry);
            return CreatedAtAction(nameof(Get), new { vehicleId = telemetry.VehicleId }, telemetry);
        }

        [HttpGet("{vehicleId}")]
        public IActionResult Get(string vehicleId)
        {
            if (string.IsNullOrEmpty(vehicleId))
            {
                return BadRequest("VehicleId is required.");
            }

            var data = _telemetryData.Where(t => t.VehicleId == vehicleId).ToList();

            if (data == null || data.Count == 0)
            {
                return NotFound("Telemetry data not found for vehicleId: " + vehicleId);
            }

            return Ok(data);
        }
    }
}
