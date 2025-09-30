# ByWay

## Project Description

ByWay is an ASP.NET Core Web API project designed to provide a platform for online courses and instructor management. It includes features for user authentication, course creation, instructor management, and course enrollment.

## Features and Functionality

*   **User Authentication:**
    *   Registration, login, and current user retrieval using JWT (JSON Web Tokens).
    *   Implements password hashing and validation using ASP.NET Core Identity.
    *   Includes email validation and lockout features.

*   **Course Management:**
    *   Create, read, update, and delete (CRUD) operations for courses.
    *   Supports course categorization and instructor assignment.
    *   Defines course levels (Beginner, Intermediate, Advanced, All).
    *   Includes sections and lectures within courses.

*   **Instructor Management:**
    *   CRUD operations for instructors.
    *   Instructor profiles include name, description, picture URL, job title, and rating.

*   **Course Sections and Lectures:**
    *   Courses are divided into sections, and sections contain lectures.
    *   Supports tracking lecture completion and duration.

*   **Data Persistence:**
    *   Utilizes Entity Framework Core for database interactions.
    *   Uses SQL Server as the database provider.

*   **Validation:**
    *   Uses FluentValidation for request validation (e.g., registration, login, course creation).

## Technology Stack

*   **ASP.NET Core Web API:** Framework for building the API.
*   **Entity Framework Core:** ORM for database access.
*   **SQL Server:** Database.
*   **AutoMapper:** Object-object mapper for DTOs and entities.
*   **FluentValidation:** Validation library.
*   **ASP.NET Core Identity:** Framework for managing user authentication and authorization.
*   **JWT (JSON Web Tokens):** For authentication.
*   **.NET 9.0:** Runtime Environment

## Prerequisites

*   .NET SDK 9.0 or later
*   SQL Server instance
*   An IDE such as Visual Studio or Visual Studio Code

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/ByWay-.git
    cd ByWay-
    ```

2.  **Set up the database:**

    *   **Create the `AppDbContext` database:**

        *   Open `ByWay.Infrastructure/appsettings.json` and verify the `DefaultConnection` connection string points to your SQL Server instance.  If not exist create `appsettings.json`.
            ```json
            {
              "ConnectionStrings": {
                "DefaultConnection": "Server=your_server;Database=ByWayDB;Integrated Security=True;TrustServerCertificate=True"
              }
            }
        
        *   Open a terminal in the `ByWay.Infrastructure` directory and run the following commands to create and update the database:

            ```bash
            dotnet ef database update -c AppDbContext
            ```

    *   **Create the `IdentityAppDbContext` database:**

        *   Open `ByWay.Infrastructure/appsettings.json` and verify the `IdentityConnection` connection string points to your SQL Server instance.
            ```json
            {
              "ConnectionStrings": {
                "IdentityConnection": "Server=your_server;Database=ByWayIdentityDB;Integrated Security=True;TrustServerCertificate=True"
              }
            }
            ```

        *   Open a terminal in the `ByWay.Infrastructure` directory and run the following commands to create and update the database:

            ```bash
            dotnet ef database update -c IdentityAppDbContext
            ```

3.  **Configure JWT settings:**

    *   Open `ByWay/appsettings.json` and configure the JWT settings:

        ```json
        {
          "jwtSettings": {
            "key": "Your_Super_Secret_Key",
            "Audience": "https://localhost:7226",
            "Issuer": "https://localhost:7226",
            "DurationInMinutes": 60
          }
        }
        ```

        *   Replace `"Your_Super_Secret_Key"` with a strong, randomly generated key.
        *   Adjust the `Audience` and `Issuer` to match your application's URL.

4.  **Build and run the application:**

    *   Navigate to the `ByWay` directory.
    *   Run the following command:

        ```bash
        dotnet build
        dotnet run
        ```

## Usage Guide

Once the application is running, you can access the API endpoints using tools like Swagger UI or Postman.

*   **Swagger UI:** Navigate to `https://localhost:7226/swagger` (or the appropriate URL based on your `launchSettings.json` configuration).

### Example Endpoints

*   **Register a new user:**

    *   `POST /api/Account/register`
    *   Request body:

        ```json
        {
          "displayName": "John Doe",
          "userName": "johndoe",
          "email": "john.doe@example.com",
          "password": "P@$$wOrd"
        }
        ```

*   **Login:**

    *   `POST /api/Account/login`
    *   Request body:

        ```json
        {
          "email": "john.doe@example.com",
          "password": "P@$$wOrd"
        }
        ```

*   **Get all courses:**

    *   `GET /api/Course`

*   **Create a new course:**

    *   `POST /api/Course`
    *   Request body:

        ```json
        {
            "courseName": "Introduction to C#",
            "pictureUrl": "https://example.com/csharp.jpg",
            "price": 49.99,
            "description": "A beginner-friendly course on C# programming.",
            "rate": "FiveStar",
            "certification": "Certified C# Developer",
            "totalHours": 20.5,
            "level": "Beginner",
            "categoryId": 1,
            "instructorId": 1
        }
        ```

## API Documentation

The API documentation is available through Swagger UI at `/swagger` endpoint.

### Authentication

Most endpoints require authentication using a JWT.  You will receive the token upon successful registration or login. Include the token in the `Authorization` header of your requests:

```
Authorization: Bearer <your_jwt_token>
```

## Contributing Guidelines

Contributions are welcome! To contribute to this project, follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes.
4.  Test your changes thoroughly.
5.  Submit a pull request.

