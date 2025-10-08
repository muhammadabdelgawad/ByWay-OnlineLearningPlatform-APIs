# ByWay - Online Learning Platform

## Project Description

ByWay is an e-learning platform backend API built using Onion Architecture and .NET Core It provides functionalities for user authentication, course management, instructor management, and shopping cart operations. The API offers features for both regular users and administrative roles.

## Features and Functionality

*   **User Authentication:**
    *   Registration: Allows new users to create accounts with `DisplayName`, `UserName`, `Email`, and `Password`.  Uses the `RegisterDto` for registration requests. Implemented within `AccountController.cs`.
    *   Login: Authenticates existing users using `Email` and `Password`. Generates a JWT token upon successful login. Uses the `LoginDto` for login requests.  Implemented within `AccountController.cs`.
    *   Current User Retrieval: Retrieves user information based on the JWT token.  Implemented within `AccountController.cs`.
    *   Email Existence Check: Determines if a user with a given email address already exists in the system. Implemented within `AccountController.cs`.

*   **Course Management:**
    *   Course Creation (Admin only): Enables administrators to add new courses to the platform, including details such as `CourseName`, `PictureUrl`, `Price`, `Description`, `Certification`, `TotalHours`, `Level`, `CategoryId`, and `InstructorId`. Requires admin authentication. Implemented within `AdminController.cs`. Uses the `CreateCourseRequest` DTO and validated by `AdminCreateCourseValidator.cs`.
    *   Course Listing: Provides a paginated list of courses, with filtering and sorting options based on `CourseName`, `Level`, `CategoryId`, and `Price`.  Implemented within `CourseController.cs` and `AdminController.cs`. Uses the `CourseFilterRequest` DTO.
    *   Course Details: Retrieves detailed information for a specific course. Implemented within `CourseController.cs`.
    *   Course Update (Admin only):  Allows administrators to modify existing courses. Implemented within `AdminController.cs`.  Uses the `UpdateCourseRequest` DTO.
    *   Course Deletion (Admin only): Enables administrators to remove courses from the platform. Requires admin authentication. Implemented within `AdminController.cs`.

*   **Instructor Management:**
    *   Instructor Creation (Admin only): Allows administrators to add new instructors, including details such as `Name`, `Description`, `PictureUrl`, `Rate`, and `JobTitle`. Requires admin authentication. Implemented within `AdminController.cs`. Uses the `CreateInstructorRequest` DTO and validated by `AdminCreateInstructorValidator.cs`.
    *   Instructor Listing (Admin only): Provides a paginated list of instructors, with filtering and sorting options.  Implemented within `AdminController.cs`. Uses the `InstructorFilterRequest` DTO.
    *   Instructor Details: Retrieves detailed information for a specific instructor. Implemented within `InstuctorController.cs`.
    *   Instructor Update (Admin only): Allows administrators to modify existing instructor information. Implemented within `AdminController.cs`. Uses the `UpdateInstructorRequest` DTO.
    *   Instructor Deletion (Admin only): Enables administrators to remove instructors. Requires admin authentication. Implemented within `AdminController.cs`.

*   **Shopping Cart:**
    *   Cart Retrieval: Retrieves the current user's shopping cart. Implemented within `CartController.cs`.
    *   Add Item to Cart: Adds a course to the user's shopping cart.  Uses the `CreateCartItemRequest` DTO and implemented within `CartController.cs`.
    *   Update Cart Item Quantity: Modifies the quantity of a specific item in the cart. Implemented within `CartController.cs`. Uses the `UpdateCartItemRequest` DTO.
    *   Apply Discount: Applies a discount to the shopping cart total. Implemented within `CartController.cs`.
    *   Clear Cart: Empties the user's shopping cart. Implemented within `CartController.cs`.

*   **Admin Dashboard:**
    *   Provides key statistics, such as total instructors, courses, users, and enrollments. Accessible only to administrators. Implemented within `AdminController.cs`. Uses the `AdminDashboardDto`.

## Technology Stack

*   .NET
*   C#
*   ASP.NET Core Web API
*   Entity Framework Core (EF Core)
*   SQL Server
*   AutoMapper
*   FluentValidation
*   Microsoft.AspNetCore.Identity
*   JWT (JSON Web Tokens)

## Prerequisites

*   .NET SDK 9.0 or later.
*   SQL Server instance.

## Installation Instructions

1.  Clone the repository:

    ```bash
    git clone https://github.com/muhammadabdelgawad/ByWay-
    cd ByWay-
    ```

2.  Configure the database connection strings:

    *   Open `ByWay.Infrastructure/appsettings.json` and `ByWay/appsettings.json`.
    *   Modify the `DefaultConnection` in `ByWay.Infrastructure/appsettings.json` to point to your SQL Server instance for the main application database (e.g., `ByWay`).
        ```json
        "ConnectionStrings": {
          "DefaultConnection": "Server=your_server;Database=ByWay;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
        ```

    *   Modify the `IdentityConnection` in `ByWay/appsettings.json` to point to your SQL Server instance for the identity database (e.g., `ByWayIdentity`).
        ```json
        "ConnectionStrings": {
          "IdentityConnection": "Server=your_server;Database=ByWayIdentity;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
        ```

3.  Apply EF Core migrations:

    ```bash
    # Navigate to the Infrastructure directory
    cd ByWay.Infrastructure
    # Update the database
    dotnet ef database update -s ../ByWay
    # Navigate to the API directory
    cd ../ByWay
    #Update the Identity Database
    dotnet ef database update
    ```

4.  Configure JWT settings:
    * Open the `ByWay/appsettings.json` file.
    * Configure the JWT settings:

    ```json
    "jwtSettings": {
        "key": "Your_secret_key_Here",
        "Issuer": "ByWayAPI",
        "Audience": "ByWayUsers",
        "DurationInMinutes": 60
    }
    ```
   **Important:**  Replace `"Your_secret_key_Here"` with a strong, randomly generated secret key. Keep this key secure!

5.  Build and run the application:

    ```bash
    # Navigate to the API directory
    cd ByWay
    dotnet build
    dotnet run
    ```

    The API will be accessible at `https://localhost:{port}`, where `{port}` is specified in the `launchSettings.json` file.

## Usage Guide

### User Authentication

*   **Register:** `POST /api/Account/register`
    *   Request body: `RegisterDto`
    *   Returns: `UserDto` with user details and JWT token.
*   **Login:** `POST /api/Account/login`
    *   Request body: `LoginDto`
    *   Returns: `UserDto` with user details and JWT token.
*   **Get Current User:** `GET /api/Account/currentUser`
    *   Requires: JWT token in `Authorization` header (Bearer scheme).
    *   Returns: `UserDto` with user details and JWT token.

### Course Management (Admin only)

*   **Create Course:** `POST /api/Admin/courses`
    *   Requires: JWT token in `Authorization` header (Bearer scheme) and Admin role.
    *   Request body: `CreateCourseRequest`
    *   Returns: 200 OK if successful, 400 Bad Request if instructor doesn't exist or other validation errors.
*   **List Courses:** `GET /api/Admin/courses` and `GET /api/Course`
    *   Query parameters: `PageNumber`, `PageSize`, `SearchTerm`, `CourseName`, `Level`, `CategoryId`, `MinPrice`, `MaxPrice`, `SortBy`, `SortDirection`.
    *   Returns: `PagedResult<CourseResponse>`
*    **Update Course:** `PUT /api/Admin/courses/{id}`
    *   Requires: JWT token in `Authorization` header (Bearer scheme) and Admin role.
    *   Request body: `UpdateCourseRequest`
    *   Returns: 200 OK if successful, 400 Bad Request if instructor doesn't exist or other validation errors.
*   **Delete Course:** `DELETE /api/Admin/courses/{id}`
    *   Requires: JWT token in `Authorization` header (Bearer scheme) and Admin role.
    *   Returns: 200 OK if successful, 404 Not Found if course doesn't exist.

### Instructor Management (Admin only)

*   **Create Instructor:** `POST /api/Admin/instructors`
    *   Requires: JWT token in `Authorization` header (Bearer scheme) and Admin role.
    *   Request body: `CreateInstructorRequest`
    *   Returns: `InstructorResponse`
*   **List Instructors:** `GET /api/Admin/instructors`
    *   Query parameters: `PageNumber`, `PageSize`, `SearchTerm`, `Name`, `JobTitle`, `Rate`, `SortBy`, `SortDirection`.
    *   Returns: `PagedResult<InstructorResponse>`
*   **Get Instructor By ID:** `GET /api/Instuctor/{id}`
    *   Returns: `InstructorResponse`
*   **Update Instructor:** `PUT /api/Admin/instructors/{id}`
    *   Requires: JWT token in `Authorization` header (Bearer scheme) and Admin role.
    *   Request body: `UpdateInstructorRequest`
    *   Returns: 200 OK if successful, 400 Bad Request if instructor doesn't exist or other validation errors.
*   **Delete Instructor:** `DELETE /api/Admin/instructors/{id}`
    *   Requires: JWT token in `Authorization` header (Bearer scheme) and Admin role.
    *   Returns: 200 OK if successful, 404 Not Found if instructor doesn't exist.

### Shopping Cart

*   **Get Cart:** `GET /api/Cart`
    *   Requires: JWT token in `Authorization` header (Bearer scheme).
    *   Returns: `CartResponse`
*   **Add Item to Cart:** `POST /api/Cart/addItem`
    *   Requires: JWT token in `Authorization` header (Bearer scheme).
    *   Request body: `CreateCartItemRequest`
    *   Returns: `CartResponse`
*   **Update Cart Item:** `PUT /api/Cart/updateItem/{itemId}`
     *   Requires: JWT token in `Authorization` header (Bearer scheme).
     *   Request body: `UpdateCartItemRequest`
    *   Returns: `UpdateCartItemRequest`
*   **Apply Discount:** `POST /api/Cart/applyDiscount?discount={discount}`
    *   Requires: JWT token in `Authorization` header (Bearer scheme).
    *   Query parameter: `discount` (decimal value).
    *   Returns: 200 OK.
*   **Clear Cart:** `DELETE /api/Cart/clear`
    *   Requires: JWT token in `Authorization` header (Bearer scheme).
    *   Returns: 200 OK.

### Admin Dashboard (Admin only)

*   **Get Dashboard Stats:** `GET /api/Admin/dashboard`
    *   Requires: JWT token in `Authorization` header (Bearer scheme) and Admin role.
    *   Returns: `AdminDashboardDto`

## API Documentation

Detailed API documentation (including request/response schemas) can be generated using Swagger. Once the application is running, navigate to `https://localhost:{port}/swagger` in your browser.

## Contributing Guidelines

Contributions are welcome! Please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Write clear, concise, and well-documented code.
4.  Submit a pull request with a detailed description of your changes.


