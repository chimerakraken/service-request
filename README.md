I'll update your README to reflect the correct request models for POST and PUT. Here's the updated version:  

---

# Service Request API

## Overview

The **Service Request API** is a web service built with .NET Core and Entity Framework Core using SQLite as the database. It provides endpoints to create, retrieve, update, and delete service requests.

## Features

- Create a new service request
- Retrieve existing service requests
- Update service requests
- Delete service requests
- Uses SQLite as the database
- Enum values are stored and returned as strings
- Uses AutoMapper for DTO mapping
- Returns `204 No Content` if no service requests are found

## Prerequisites

- .NET SDK 9.0+
- SQLite

## Setup

1. Clone the repository:
   ```sh
   git clone <repository-url>
   cd service-request
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Apply migrations:
   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
4. Run the application:
   ```sh
   dotnet run
   ```

## Enum Handling

To ensure **ServiceStatusType** enums are handled as strings in both input and output:

- Enums are serialized and deserialized as strings in JSON requests and responses.
- Swagger will display enum values as text instead of integer representations.

## API Endpoints

### GET: Retrieve all service requests
- **Route:** `api/ServiceRequest`
- **Response Codes:**
  - `200 OK` - List of service requests
  - `204 No Content` - No service requests available

### GET: Retrieve service request by ID
- **Route:** `api/ServiceRequest/{id}`
- **Response Codes:**
  - `200 OK` - Single service request
  - `404 Not Found` - Service request not found

### POST: Create a new service request
- **Route:** `api/ServiceRequest`
- **Request Body:**
  ```json
  {
    "buildingCode": "B123",
    "description": "Aircon maintenance required",
    "currentStatus": "Open",
    "createdBy": "admin",
    "createdDate": "2025-03-27T10:00:00Z",
    "lastModifiedBy": null,
    "lastModifiedDate": null
  }
  ```
- **Response Codes:**
  - `201 Created` - Service request successfully created
  - `400 Bad Request` - Invalid request data

### PUT: Update service request by ID
- **Route:** `api/ServiceRequest/{id}`
- **Request Body:**
  ```json
  {
    "buildingCode": "B123",
    "description": "Updated description",
    "lastModifiedBy": "admin"
  }
  ```
- **Response Codes:**
  - `200 OK` - Service request successfully updated
  - `400 Bad Request` - Invalid request data
  - `404 Not Found` - Service request not found

### DELETE: Delete service request by ID
- **Route:** `api/ServiceRequest/{id}`
- **Response Codes:**
  - `200 OK` - Service request successfully deleted
  - `404 Not Found` - Service request not found

## Notes

- Ensure migrations are applied before running the API.
- Uses **AutoMapper** for mapping DTOs to entities.
- Returns `204 No Content` for empty lists instead of `200 OK` with an empty array.
- **CreatedDate** is set when a new request is created, while **LastModifiedBy** and **LastModifiedDate** are updated when a request is modified.
