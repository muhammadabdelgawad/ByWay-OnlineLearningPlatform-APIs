# ByWay-

## Project Description

ByWay is an ASP.NET Core Web API project designed for managing online courses, instructors, and user authentication. It includes functionalities for administrators to manage courses and instructors, user authentication and authorization using JWT, and a shopping cart feature for course enrollment.

## Features and Functionality

*   **User Authentication and Authorization:**
    *   User registration and login using email and password.
    *   JWT (JSON Web Tokens) for secure authentication.
    *   Admin role-based authorization for accessing administrative functionalities.
    *   Token generation using settings from `jwtSettings` configuration.
    *   Account activation status to control user access.

*   **Course Management:**
    *   Create, read, update, and delete courses.
    *   Course details include name, picture URL, price, description, certification, total hours, level, category, and instructor.
    *   Categorization of courses and association with instructors.
    *   Course sections and lectures for structured learning.

*   **Instructor Management:**
    *   Create, read, update, and delete instructors.
    *   Instructor details include name, description, picture URL, rate, and job title.
    *   Association of instructors with courses.

*   **Shopping Cart:**
    *   Add, update, and clear items in the shopping cart.
    *   Apply discounts to the cart.
    *   Cart persistence with user association.

*   **Admin Dashboard:**
    *   Statistics on total instructors, courses, users, and enrollments.
    *   Access to admin functions restricted to authorized users.

## Technology Stack

*   **ASP.NET Core:** Framework for building the Web API.
*   **C#:** Programming language.
*   **Entity Framework Core (EF Core):** ORM (Object-Relational Mapper) for database interactions.
*   **SQL Server:** Database for storing application data.
*   **AutoMapper:** Object-object mapper to reduce boilerplate code.
*   **FluentValidation:** Library for building strongly-typed validation rules.
*   **Microsoft.AspNetCore.Identity:** Framework for user management.
*   **JWT (JSON Web Tokens):** For authentication and authorization.

## Prerequisites

*   .NET SDK (version 7.0 or later)
*   SQL Server installed and running
*   Visual Studio or other suitable IDE

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/ByWay-
    cd ByWay-
    ```

2.  **Configure the database:**

    *   Update the connection strings in `ByWay.Infrastructure/DependencyInjection.cs` and `ByWay.APIs/Extensions/IdentityExtensions.cs` (or `appsettings.json` if those values are referenced there.) The connection strings should look something like this:

    ```csharp
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    ```

    Replace `"DefaultConnection"` and `"IdentityConnection"` with your actual connection string values. Make sure both of your database connection strings point to a valid SQL Server instance.

    Example `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=ByWayDB;User Id=your_user_id;Password=your_password;TrustServerCertificate=True",
        "IdentityConnection": "Server=your_server;Database=ByWayIdentityDB;User Id=your_user_id;Password=your_password;TrustServerCertificate=True"
      },
      "jwtSettings": {
        "key": "YourSecretKeyForJwtToken",
        "Audience": "http://localhost",
        "Issuer": "ByWay",
        "DurationInMinutes": 60
      }
    }
    ```

3.  **Apply database migrations:**

    *   Navigate to the `ByWay.Infrastructure` directory in your terminal.
    *   Run the following commands to create and update the database:

    ```bash
    dotnet ef database update -c AppDbContext
    dotnet ef database update -c IdentityAppDbContext
    ```

    If you encounter errors, ensure that the Entity Framework Core tools are installed:

    ```bash
    dotnet tool install --global dotnet-ef
    ```

4.  **Configure JWT Settings:**

    *   Ensure the `jwtSettings` section in `appsettings.json` is properly configured.  Specifically, the `key`, `Audience`, and `Issuer` values should reflect your desired configuration.  **Important:** The `key` should be a strong, randomly generated string and kept secret.

5.  **Build and run the project:**

    ```bash
    cd ByWay
    dotnet build
    dotnet run
    ```

    This will start the API, typically on `https://localhost:5001` or `http://localhost:5000`.

## Usage Guide

Once the API is running, you can access the endpoints using tools like Postman, Swagger UI, or any HTTP client.

*   **Authentication:**
    *   `POST /api/Account/register`: Register a new user.  Requires `DisplayName`, `UserName`, `Email`, and `Password`.
    *   `POST /api/Account/login`: Log in an existing user.  Requires `Email` and `Password`.  Returns a JWT.
    *   `GET /api/Account/currentUser`: Get the current user's information (requires authentication).
    *   Include the JWT in the `Authorization` header of subsequent requests as `Bearer <your_jwt>`.

*   **Courses:**
    *   `GET /api/Course`: Get all courses.
    *   `GET /api/Course/{id}`: Get a course by ID.
    *   `POST /api/Course`: Create a new course (requires Admin privileges).
    *   `PUT /api/Course/{id}`: Update a course (requires Admin privileges).
    *   `DELETE /api/Course/{id}`: Delete a course (requires Admin privileges).

*   **Instructors:**
    *   `GET /api/Instuctor`: Get all instructors.
    *   `GET /api/Instuctor/{id}`: Get an instructor by ID.
    *   `POST /api/Instuctor`: Create a new instructor (requires Admin privileges).
    *   `PUT /api/Instuctor/{id}`: Update an instructor (requires Admin privileges).
    *   `DELETE /api/Instuctor/{id}`: Delete an instructor (requires Admin privileges).

*   **Shopping Cart:**
    *   `GET /api/Cart`: Get the current user's cart (requires authentication).
    *   `POST /api/Cart/addItem`: Add an item to the cart (requires authentication). Requires `CourseId`, `CourseName`, `PictureUrl`, `Price`, and `Quantity`.
    *   `PUT /api/Cart/updateItem/{itemId}`: Update an item in the cart (requires authentication). Requires `CourseId` and `Quantity`.
    *   `POST /api/Cart/applyDiscount?discount={discount}`: Apply a discount to the cart (requires authentication).
    *   `DELETE /api/Cart/clear`: Clear the cart (requires authentication).

*   **Admin:**
    *   `GET /api/Admin/dashboard`: Get dashboard statistics (requires Admin privileges).
    *   `POST /api/Admin/instructors`: Create an instructor (requires Admin privileges). Requires `Name`, `Description`, `PictureUrl`, `Rate`, and `JobTitle`.
    *   `POST /api/Admin/courses`: Create a course (requires Admin privileges). Requires `CourseName`, `PictureUrl`, `Price`, `Description`, `Rate`, `Certification`, `TotalHours`, `Level`, `Category`, and `Instructor`.
    *   `GET /api/Admin/instructors`: Get all instructors (requires Admin privileges).
    *   `DELETE /api/Admin/instructors/{id}`: Delete an instructor (requires Admin privileges).
    *   `DELETE /api/Admin/courses/{id}`: Delete a course (requires Admin privileges).

## API Documentation

Swagger UI is enabled in development environments. After running the application, navigate to `https://localhost:5001/swagger` or `http://localhost:5000/swagger` to view the API documentation.

## Contributing Guidelines

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Commit your changes with descriptive commit messages.
4.  Push your changes to your fork.
5.  Submit a pull request.
