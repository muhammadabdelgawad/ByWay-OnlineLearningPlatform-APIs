# ByWay-

## Description

ByWay- is an ASP.NET Core application designed for managing courses and instructors, potentially for an online learning platform. It features a Domain-Driven Design (DDD) approach, separating concerns into Domain, Application, and Infrastructure layers. The application utilizes Entity Framework Core for data access and provides a basic API structure.

## Features and Functionality

*   **Course Management:**  Create, read, update, and delete course information, including name, description, price, certification, total hours, level, category, and instructor.
*   **Instructor Management:** Create, read, update, and delete instructor information, including name, description, picture URL, rate, and job title.
*   **Category Management:** (Implicit, based on `Category.cs`) Defines categories for courses.
*   **Generic Repository Pattern:** Implements a generic repository for data access abstraction.
*   **Unit of Work Pattern:** Manages database transactions and provides access to repositories.
*   **Entity Framework Core:**  Provides an ORM for interacting with a SQL Server database.
*   **API Endpoints:** Includes a basic `WeatherForecastController` as a placeholder/example.

## Technology Stack

*   .NET 9 (Likely, based on project structure and dependencies)
*   ASP.NET Core
*   Entity Framework Core
*   SQL Server
*   C#

## Prerequisites

*   .NET SDK (version 9 or later)
*   SQL Server instance
*   An IDE such as Visual Studio or Visual Studio Code

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/ByWay-
    cd ByWay-
    ```

2.  **Update the Database Connection String:**

    Modify the connection string in the `appsettings.json` file of the main project (`ByWay`) to point to your SQL Server instance.  Example:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=ByWayDB;Trusted_Connection=True;MultipleActiveResultSets=true"
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

    Replace `your_server` with the actual server name or address. Ensure that the database `ByWayDB` exists or will be created by EF Core Migrations.

3.  **Apply Entity Framework Core Migrations:**

    Navigate to the `ByWay.Infrastructure` directory in the command line.

    ```bash
    cd ByWay.Infrastructure
    ```

    Run the following commands to add a migration (if no existing migration exists) and update the database:

    ```bash
    dotnet ef migrations add InitialCreate --project ByWay.Infrastructure --startup-project ../ByWay
    dotnet ef database update --project ByWay.Infrastructure --startup-project ../ByWay
    ```

    This will create the necessary database tables based on the entities defined in the `ByWay.Domain` project.

4.  **Build and Run the Application:**

    Navigate back to the root directory (`ByWay`)

    ```bash
    cd ..
    dotnet build
    dotnet run
    ```

    This will start the ASP.NET Core application.  By default, it will run on `https://localhost:7000` and `http://localhost:5000`.

## Usage Guide

1.  **Access the API:**

    Open your web browser and navigate to `https://localhost:7000/swagger` (or `http://localhost:5000/swagger` if using HTTP) to access the Swagger UI.  This will allow you to explore the available API endpoints and test them.

2.  **Explore the API Endpoints:**

    The Swagger UI will display the available API endpoints, including the `WeatherForecastController`.  More endpoints would need to be added for Course and Instructor management.  Example endpoints (that would need to be created in a new controller) :

    *   `GET /Courses`:  Retrieves all courses.
    *   `GET /Courses/{id}`: Retrieves a specific course by ID.
    *   `POST /Courses`: Creates a new course.
    *   `PUT /Courses/{id}`: Updates an existing course.
    *   `DELETE /Courses/{id}`: Deletes a course.
    *   `GET /Instructors`: Retrieves all instructors.
    *   `GET /Instructors/{id}`: Retrieves a specific instructor by ID.
    *   `POST /Instructors`: Creates a new instructor.
    *   `PUT /Instructors/{id}`: Updates an existing instructor.
    *   `DELETE /Instructors/{id}`: Deletes an instructor.

## API Documentation

The API documentation can be found using Swagger UI at `/swagger` endpoint once the application is running.

Based on the existing files the following entities/models will have API endpoints (examples only, actual endpoints need to be created):

*   **Courses:**
    *   `CourseName`: string
    *   `PictureUrl`: string
    *   `Price`: decimal
    *   `Description`: string
    *   `Certification`: string
    *   `TotalHours`: double
    *   `Level`: enum (Beginner, Intermediate, Advanced, All)
    *   `CategoryId`: int
    *   `InstructorId`: int
*   **Instructors:**
    *   `Name`: string
    *   `Description`: string
    *   `PictureUrl`: string
    *   `Rate`: enum (OneStar, TwoStar, ThreeStar, FourStar, FiveStar)
    *   `JobTitle`: enum (FullstackDeveloper, BackendDeveloper, FrontendDeveloper, UXUIDesigner)

## Contributing Guidelines

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with descriptive commit messages.
4.  Test your changes thoroughly.
5.  Submit a pull request to the `master` branch.

## License Information

No license is specified in the repository.  Please add a license file (e.g., `LICENSE.txt`) with the appropriate license text (e.g., MIT, Apache 2.0, GPL) to specify how others can use your code.  For example, to use MIT license, add this in LICENSE.txt:

