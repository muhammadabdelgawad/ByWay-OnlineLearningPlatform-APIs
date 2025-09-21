# ByWay-

## Description

This repository contains the codebase for the ByWay application, an ASP.NET Core Web API designed for managing online courses and instructors. It provides functionalities for creating, reading, updating, and deleting (CRUD) courses and instructors, leveraging a layered architecture with domain entities, application contracts, and infrastructure services.

## Features and Functionality

*   **Course Management:**
    *   Create new courses with details such as name, picture URL, price, description, certification, total hours, level, category, and instructor.
    *   Retrieve a list of all courses.
    *   Retrieve a specific course by its ID.
    *   Update existing course information.
    *   Delete courses.

*   **Instructor Management:**
    *   Add new instructors with details such as name, description, picture URL, rate, and job title.
    *   Retrieve a list of all instructors.
    *   Retrieve a specific instructor by their ID.
    *   Update existing instructor information.
    *   Delete instructors.

*   **API Endpoints:**
    *   Well-defined API endpoints for interacting with courses and instructors.  See API Documentation below.

*   **Data Validation:**
    *   Utilizes FluentValidation for request validation, ensuring data integrity.  See `/ByWay.Application/Validations` directory.

*   **Object-Relational Mapping (ORM):**
    *   Uses Entity Framework Core (EF Core) for interacting with the database.

*   **Dependency Injection:**
    *   Employs dependency injection for loose coupling and testability.

*   **AutoMapper:**
    *   Uses AutoMapper to map between Domain Entities and DTOs.
    *   Mapping Profiles are found in `/ByWay.Application/Mapping/MappingProfile.cs`

## Technology Stack

*   **ASP.NET Core Web API:**  Framework for building the API.
*   **Entity Framework Core (EF Core):** ORM for database interaction.
*   **SQL Server:** Database system.
*   **AutoMapper:**  Object-object mapper.
*   **FluentValidation:** Validation library.
*   **C#:** Programming language.
*   **.NET 9.0:**  Runtime environment.  Verified from the migrations class.

## Prerequisites

*   [.NET SDK 9.0 or later](https://dotnet.microsoft.com/en-us/download)
*   SQL Server instance (local or remote)
*   An IDE such as Visual Studio or Visual Studio Code

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/ByWay-.git
    cd ByWay-
    ```

2.  **Update the database connection string:**

    *   Open the `appsettings.json` file in the `ByWay` directory.
    *   Modify the `DefaultConnection` string to point to your SQL Server instance.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=ByWayDB;User Id=your_user_id;Password=your_password;TrustServerCertificate=True;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

    Replace `your_server`, `ByWayDB`, `your_user_id`, and `your_password` with your actual SQL Server details. Make sure that  `TrustServerCertificate=True;` is used for a local dev SQL Server.

3.  **Apply database migrations:**

    *   Open a terminal or command prompt in the `ByWay.Infrastructure` directory.
    *   Run the following command to create the database and apply the migrations:

    ```bash
    dotnet ef database update
    ```

    This command assumes you have the EF Core tools installed globally. If not, you may need to install them:

    ```bash
    dotnet tool install --global dotnet-ef
    ```

4.  **Build and run the application:**

    *   Navigate to the `ByWay` directory.
    *   Run the following command to build and start the application:

    ```bash
    dotnet run
    ```

    The application will start, and you can access the API endpoints through the specified port (typically `https://localhost:7094` or `http://localhost:5294`).  See the console output after running `dotnet run`.

## Usage Guide

Once the application is running, you can use tools like Postman, Swagger UI, or any HTTP client to interact with the API endpoints.

### Example API Requests

#### Get All Courses

```http
GET /api/Course
```

#### Get Course by ID

```http
GET /api/Course/{id}
```

#### Create a New Course

```http
POST /api/Course
Content-Type: application/json

{
  "courseName": "Introduction to C#",
  "pictureUrl": "https://example.com/csharp.jpg",
  "price": 99.99,
  "description": "A beginner-friendly course on C# programming.",
  "rate": "FiveStar",
  "certification": "Certified C# Developer",
  "totalHours": 40,
  "level": "Beginner",
  "categoryId": 1,
  "instructorId": 1
}
```

#### Update an Existing Course

```http
PUT /api/Course/{id}
Content-Type: application/json

{
  "id": 1,
  "courseName": "Advanced C#",
  "pictureUrl": "https://example.com/advanced-csharp.jpg",
  "price": 149.99,
  "description": "An advanced course on C# programming.",
  "rate": "FiveStar",
  "certification": "Certified C# Developer",
  "totalHours": 60,
  "level": "Advanced",
  "categoryId": 1,
  "instructorId": 1
}
```

#### Delete a Course

```http
DELETE /api/Course/{id}
```

## API Documentation

The API provides endpoints for managing courses and instructors. Here's a summary of the available endpoints:

### Course Controller (`/api/Course`)

*   **GET**: Retrieves all courses.
*   **GET /{id}**: Retrieves a specific course by ID.
*   **POST**: Creates a new course.  Requires a JSON body conforming to the `CreateCourseRequest` DTO defined in `/ByWay.Application/DTOs/Course/CreateCourseRequest.cs`.
*   **PUT /{id}**: Updates an existing course. Requires a JSON body conforming to the `UpdateCourseRequest` DTO defined in `/ByWay.Application/DTOs/Course/UpdateCourseRequest.cs`.
*   **DELETE /{id}**: Deletes a course.

### Instructor Controller (`/api/Instuctor`)

*   **GET**: Retrieves all instructors.
*   **GET /{id}**: Retrieves a specific instructor by ID.
*   **POST**: Creates a new instructor. Requires a JSON body conforming to the `CreateInstructorRequest` DTO defined in `/ByWay.Application/DTOs/Instructor/CreateInstructorRequest.cs`.
*   **PUT /{id}**: Updates an existing instructor. Requires a JSON body conforming to the `UpdateInstructorRequest` DTO defined in `/ByWay.Application/DTOs/Instructor/UpdateInstructorRequest.cs`.
*   **DELETE /{id}**: Deletes an instructor.

## Contributing Guidelines

Contributions are welcome! Please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and ensure they are well-tested.
4.  Submit a pull request with a clear description of your changes.

