using System;

namespace VehicleTelemetryAPI.Models
{
    public class TelemetryData
    {
        public string VehicleId { get; set; }
        public double Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
