# FireAlert API

FireAlert is a comprehensive ASP.NET Core Web API application designed to manage and track fire alerts. It features endpoints for creating, reading, updating, and deleting fire alerts, as well as managing user data and integrating with an external fire data service.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Setting up the Database](#setting-up-the-database)
  - [Running the Application](#running-the-application)
  - [Using Docker](#using-docker)
- [API Endpoints](#api-endpoints)
  - [FireAlertController](#firealertcontroller)
  - [UserController](#usercontroller)
- [Data Transfer Objects (DTOs)](#data-transfer-objects-dtos)
  - [CreateFireAlertDto](#createfirealertdto)

## Technologies Used

- **ASP.NET Core**: Framework for building the API.
- **Entity Framework Core**: ORM for database operations.
- **AutoMapper**: Library for mapping between objects.
- **SQL Server**: Database system.
- **HttpClient**: For making HTTP requests.
- **Docker**: Containerization platform.

## Prerequisites

- .NET SDK 8.0
- Docker (for containerized deployment)
- SQL Server (for the database)

## Project Structure

- **Controllers**: API endpoints and request processing.
  - `FireAlertController`: Manages fire alerts.
  - `UserController`: Manages user data.
- **DTOs**: Data Transfer Objects for API communication.
- **Services**: Contains business logic.
  - `FireApi`: Integrates with an external fire data API.
- **Data**: Database context.
  - `ApplicationDbContext`.
- **Models**: Database entities.
- **Dockerfile**: Steps to containerize the application.

## Getting Started

### Setting up the Database

1. Ensure SQL Server is running and accessible.
2. Configure the connection string in `appsettings.json` or as an environment variable.

### Running the Application

1. Restore the dependencies:
    ```bash
    dotnet restore
    ```
2. Build the project:
    ```bash
    dotnet build
    ```
3. Run the application:
    ```bash
    dotnet run
    ```

### Using Docker

To build and run the application using Docker:

1. Build the Docker image:
    ```bash
    docker build -t firealert-api .
    ```
2. Run the Docker container:
    ```bash
    docker run -d -p 5067:5067 -p 5068:5068 firealert-api
    ```

## API Endpoints

### FireAlertController

- **GET /api/firealert/getFireAlerts**: Retrieves all fire alerts.
- **POST /api/firealert**: Creates a new fire alert.
- **PUT /api/firealert/{id}**: Updates an existing fire alert by ID.
- **DELETE /api/firealert/{id}**: Deletes a fire alert by ID.
- **GET /api/firealert/getFires**: Fetches and imports fire data from an external API.

### UserController

- **GET /api/user**: Retrieves all users.
- **POST /api/user**: Creates a new user.
- **PUT /api/user/{id}**: Updates an existing user by ID.
- **DELETE /api/user/{id}**: Deletes a user by ID.

## Data Transfer Objects (DTOs)

### CreateFireAlertDto

```csharp
public class CreateFireAlertDto
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string FireDescription { get; set; }
    public string ContactPhoneNumber { get; set; }
    public string ContactName { get; set; }
}
