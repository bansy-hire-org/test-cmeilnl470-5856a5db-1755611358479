using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using VehicleTelemetryAPI.Controllers;
using VehicleTelemetryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace VehicleTelemetryAPI.Tests
{
    public class TelemetryControllerTests
    {
        private TelemetryController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new TelemetryController();
        }

        [Test]
        public void Post_ValidTelemetry_ReturnsCreatedAtAction()
        {
            var telemetry = new TelemetryData { VehicleId = "TestVehicle", Speed = 60, Latitude = 34.0522, Longitude = -118.2437 };
            var result = _controller.Post(telemetry) as CreatedAtActionResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(nameof(_controller.Get), result.ActionName);
            Assert.AreEqual(201, result.StatusCode);
        }

        [Test]
        public void Post_InvalidTelemetry_ReturnsBadRequest()
        {
            var result = _controller.Post(null) as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void Get_ExistingVehicleId_ReturnsOk()
        {
            // Pre-populate data (simulating data already posted)
            _controller.Post(new TelemetryData { VehicleId = "ExistingVehicle", Speed = 50, Latitude = 34.0522, Longitude = -118.2437 });
            var result = _controller.Get("ExistingVehicle") as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var data = result.Value as List<TelemetryData>;
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Any(t => t.VehicleId == "ExistingVehicle"));
        }

        [Test]
        public void Get_NonExistingVehicleId_ReturnsNotFound()
        {
            var result = _controller.Get("NonExistingVehicle") as NotFoundObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Get_EmptyVehicleId_ReturnsBadRequest()
        {
            var result = _controller.Get(string.Empty) as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
