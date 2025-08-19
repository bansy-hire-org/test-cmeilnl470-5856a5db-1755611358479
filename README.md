# Vehicle Telemetry API

This is a simple .NET REST API for collecting and retrieving vehicle telemetry data.

## Setup

1.  Install the .NET SDK (version 5.0 or later).
2.  Clone the repository.
3.  Navigate to the `src/VehicleTelemetryAPI` directory.
4.  Run `dotnet restore` to install dependencies.
5.  Run `dotnet build` to build the project.
6.  Run `dotnet run` to start the API.

## Running Tests

1. Navigate to the `tests/VehicleTelemetryAPI.Tests` directory.
2. Run `dotnet test` to execute the unit tests.

## API Endpoints

*   **POST /telemetry**: Accepts telemetry data in JSON format.
*   **GET /telemetry/{vehicleId}**: Retrieves telemetry data for a specific vehicle ID.
