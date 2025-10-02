# ByWay-

## Project Description

ByWay is an ASP.NET Core web API project designed for e-learning platform management. It provides functionalities for managing courses, instructors, user authentication, and shopping cart operations. The API exposes endpoints for creating, retrieving, updating, and deleting courses and instructors. It also handles user registration, login, authentication, and shopping cart functionalities like adding, updating, clearing and applying discounts.

## Features and Functionality

*   **Course Management:**
    *   Create, retrieve, update, and delete courses.
    *   Associate courses with categories and instructors.
    *   Manage course sections and lectures.
*   **Instructor Management:**
    *   Create, retrieve, update, and delete instructors.
    *   Assign instructors to courses.
*   **User Authentication and Authorization:**
    *   User registration and login with JWT-based authentication.
    *   Protected routes requiring authentication.
    *   Current user retrieval
*   **Shopping Cart Functionality:**
    *   Add courses to the cart.
    *   View and update cart items.
    *   Clear the cart.
    *   Apply discounts to the cart.
*   **Data Validation:**
    *   Request validation using FluentValidation.
*   **Data Persistence:**
    *   Uses Entity Framework Core for data access and persistence.
    *   Uses SQL Server as the database.

## Technology Stack

*   ASP.NET Core Web API
*   Entity Framework Core
*   SQL Server
*   AutoMapper
*   FluentValidation
*   Microsoft Identity
*   JWT (JSON Web Tokens)
*   C#

## Prerequisites

Before running the application, ensure you have the following installed:

*   .NET SDK (version 7.0 or later)
*   SQL Server
*   An IDE or text editor (e.g., Visual Studio, VS Code)

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/ByWay-.git
    cd ByWay-
    ```

2.  **Configure the database connection:**

    *   Update the connection strings in `ByWay.Infrastructure/appsettings.json` and `ByWay/appsettings.json` to point to your SQL Server instance.

    ```json
    // ByWay.Infrastructure/appsettings.json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=ByWayDB;Integrated Security=True;TrustServerCertificate=True"
      }
    }

    //ByWay/appsettings.json
    {
       "ConnectionStrings": {
         "IdentityConnection": "Server=your_server;Database=IdentityByWayDB;Integrated Security=True;TrustServerCertificate=True"
       },
    }
    ```

    Replace `your_server` with the actual server address.  Ensure the database names match your SQL Server configuration. The connection string `Integrated Security=True` assumes you're using Windows Authentication.  If using SQL Server Authentication, replace it with `User Id=your_user_id;Password=your_password;`.

3.  **Apply EF Core migrations:**

    *   Open a terminal in the `ByWay.Infrastructure` directory.
    *   Run the following commands to create and update the database:

    ```bash
    dotnet ef database update -s ../ByWay
    ```

    *   Open a terminal in the `ByWay.Infrastructure.Identity` directory.
    *   Run the following commands to create and update the database for Identity:

    ```bash
    dotnet ef database update -s ../ByWay
    ```

4.  **Build and run the application:**

    *   Open a terminal in the `ByWay` directory.
    *   Run the following commands:

    ```bash
    dotnet build
    dotnet run
    ```

## Usage Guide

The API endpoints can be accessed through any HTTP client, such as Postman or a web browser.

### Authentication

1.  **Register a new user:**

    *   Send a POST request to `/api/Account/register` with the following JSON payload:

    ```json
    {
        "displayName": "Your Name",
        "userName": "your_username",
        "email": "your_email@example.com",
        "password": "your_password"
    }
    ```

2.  **Login:**

    *   Send a POST request to `/api/Account/login` with the following JSON payload:

    ```json
    {
        "email": "your_email@example.com",
        "password": "your_password"
    }
    ```

    *   The response will contain a JWT token that needs to be included in the `Authorization` header of subsequent requests. Example: `Authorization: Bearer your_jwt_token`.

### Course Management

*   **Get all courses:** `GET /api/Course`
*   **Get a course by ID:** `GET /api/Course/{id}`
*   **Create a course:** `POST /api/Course`
    ```json
    {
        "courseName": "New Course",
        "pictureUrl": "http://example.com/image.jpg",
        "price": 99.99,
        "description": "Course description",
        "rate": "FourStar",
        "certification": "Certification details",
        "totalHours": 20.5,
        "level": "Intermediate",
        "category": "Category Name",
        "instructor": "Instructor Name",
        "categoryId": 1,
        "instructorId": 1
    }
    ```
*   **Update a course:** `PUT /api/Course/{id}`
    ```json
    {
        "id": 1,
        "courseName": "Updated Course Name",
        "pictureUrl": "http://example.com/updated_image.jpg",
        "price": 129.99,
        "description": "Updated course description",
        "rate": "FiveStar",
        "certification": "Updated certification details",
        "totalHours": 25.5,
        "level": "Advanced",
        "category": "Updated Category Name",
        "instructor": "Updated Instructor Name",
        "categoryId": 2,
        "instructorId": 2
    }
    ```
*   **Delete a course:** `DELETE /api/Course/{id}`

### Instructor Management

*   **Get all instructors:** `GET /api/Instuctor`
*   **Get an instructor by ID:** `GET /api/Instuctor/{id}`
*   **Create an instructor:** `POST /api/Instuctor`
    ```json
    {
        "name": "John Doe",
        "description": "Instructor description",
        "pictureUrl": "http://example.com/instructor.jpg",
        "rate": "FiveStar",
        "jobTitle": "FullstackDeveloper"
    }
    ```
*   **Update an instructor:** `PUT /api/Instuctor/{id}`
    ```json
    {
        "id": 1,
        "name": "Updated John Doe",
        "description": "Updated instructor description",
        "pictureUrl": "http://example.com/updated_instructor.jpg",
        "rate": "FourStar",
        "jobTitle": "BackendDeveloper"
    }
    ```
*   **Delete an instructor:** `DELETE /api/Instuctor/{id}`

### Cart Management

*   **Get the cart:** `GET /api/Cart` (Requires authentication)
*   **Add an item to the cart:** `POST /api/Cart/addItem` (Requires authentication)
    ```json
    {
        "courseId": 1,
        "courseName": "Sample Course",
        "pictureUrl": "http://example.com/sample_course.jpg",
        "price": 50.00,
        "quantity": 2
    }
    ```
*   **Update a cart item:** `PUT /api/Cart/updateItem/{itemId}` (Requires authentication)
    ```json
    {
        "courseId": 1,
        "quantity": 3
    }
    ```
*   **Apply discount to the cart:** `POST /api/Cart/applyDiscount?discount=0.1` (Requires authentication) Replace 0.1 with your desired discount percentage.
*   **Clear the cart:** `DELETE /api/Cart/clear` (Requires authentication)

## API Documentation

| Endpoint                  | Method | Description                                               | Request Body                                                                      | Response Body                                                                                                 | Authentication |
| ------------------------- | ------ | --------------------------------------------------------- | --------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | -------------- |
| `/api/Account/register`   | POST   | Registers a new user                                    | `RegisterDto`                                                                     | `UserDto`                                                                                                     | No             |
| `/api/Account/login`      | POST   | Logs in an existing user                                  | `LoginDto`                                                                        | `UserDto`                                                                                                     | No             |
| `/api/Account/currentUser`| GET    | Retrieves the currently logged-in user                      | None                                                                              | `UserDto`                                                                                                     | Yes            |
| `/api/Account/emailExists`| GET    | Checks if an email exists in the database                 | `email` query parameter                                                                                                       | `bool`                                                                                                       | No            |
| `/api/Course`             | GET    | Retrieves all courses                                   | None                                                                              | `IEnumerable<CourseResponse>`                                                                                  | No             |
| `/api/Course/{id}`        | GET    | Retrieves a course by its ID                              | None                                                                              | `CourseResponse`                                                                                              | No             |
| `/api/Course`             | POST   | Creates a new course                                    | `CreateCourseRequest`                                                             | Confirmation Message                                                                                            | No             |
| `/api/Course/{id}`        | PUT    | Updates an existing course                                | `UpdateCourseRequest`                                                             | Confirmation Message                                                                                            | No             |
| `/api/Course/{id}`        | DELETE | Deletes a course                                        | None                                                                              | Confirmation Message                                                                                            | No             |
| `/api/Instuctor`          | GET    | Retrieves all instructors                               | None                                                                              | `IEnumerable<InstructorResponse>`                                                                               | No             |
| `/api/Instuctor/{id}`     | GET    | Retrieves an instructor by ID                            | None                                                                              | `InstructorResponse`                                                                                            | No             |
| `/api/Instuctor`          | POST   | Creates a new instructor                                | `CreateInstructorRequest`                                                           | Request Details                                                                                               | No             |
| `/api/Instuctor/{id}`     | PUT    | Updates an existing instructor                          | `UpdateInstructorRequest`                                                           | `InstructorResponse`                                                                                            | No             |
| `/api/Instuctor/{id}`     | DELETE | Deletes an instructor                                     | None                                                                              | Confirmation Message                                                                                            | No             |
| `/api/Cart`               | GET    | Retrieves the user's cart                               | None                                                                              | `CartResponse`                                                                                                | Yes            |
| `/api/Cart/addItem`        | POST   | Adds an item to the user's cart                          | `CreateCartItemRequest`                                                             | `CartResponse`                                                                                                | Yes            |
| `/api/Cart/updateItem/{itemId}` | PUT    | Updates an item in the user's cart                       | `UpdateCartItemRequest`                                                             | `UpdateCartItemRequest`                                                                                             | Yes            |
| `/api/Cart/applyDiscount` | POST   | Applies a discount to the user's cart                     | `discount` query parameter                                                        | Confirmation Message                                                                                            | Yes            |
| `/api/Cart/clear`         | DELETE | Clears the user's cart                                  | None                                                                              | Confirmation Message                                                                                            | Yes            |

## Contributing Guidelines

Contributions are welcome! To contribute to this project, please follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes.
4.  Test your changes thoroughly.
5.  Submit a pull request.
