# ByWay - Online Learning Platform

## Project Description

ByWay is an online learning platform designed to provide users with access to a variety of courses and instructors. It offers features such as user authentication, course management, instructor profiles, and a shopping cart system. The platform is built using .NET and incorporates technologies like ASP.NET Core, Entity Framework Core, AutoMapper, and FluentValidation.

## Features and Functionality

*   **User Authentication:**
    *   Registration and Login functionality implemented using ASP.NET Core Identity.
    *   JWT-based authentication for secure API access.
    *   `AccountController.cs`: Handles registration, login, and current user retrieval.
*   **Course Management:**
    *   Admins can create, read, update, and delete courses.
    *   `CourseController.cs`: Provides API endpoints for course management.
    *   `AdminController.cs`: Provides authorized endpoints for admin course management.
    *   Course details include name, picture URL, price, description, certification, total hours, level, category, and instructor.
*   **Instructor Profiles:**
    *   Admins can create, read, update, and delete instructor profiles.
    *   `InstuctorController.cs`: Provides API endpoints for instructor management.
    *   Instructor details include name, description, picture URL, rate, and job title.
*   **Shopping Cart:**
    *   Users can add courses to a shopping cart.
    *   `CartController.cs`: Provides API endpoints for cart management.
    *   Cart items include course name, price, quantity, and picture URL.
    *   Functionality to update item quantity, apply discounts, and clear the cart.
*   **Admin Dashboard:**
    *   Provides statistics on total instructors, courses, users, and enrollments.
    *   `AdminController.cs`: Includes an endpoint to retrieve dashboard statistics.
*   **Role-Based Authorization:**
    *   Admin roles are used to restrict access to certain functionalities.
    *   `AdminController.cs`: Secured with the `[Authorize(Roles = "Admin")]` attribute.
*   **Filtering and Pagination:**
    *   Listings of instructors and courses support filtering, searching and sorting.
    *   `InstructorFilterRequest.cs` and `CourseFilterRequest.cs`: define filtering parameters.
    *   `PagedRequest.cs` and `PagedResult.cs`: Define pagination parameters and results.

## Technology Stack

*   **ASP.NET Core:** Web framework for building APIs and web applications.
*   **Entity Framework Core (EF Core):** ORM for data access.
*   **SQL Server:** Database for storing application data.
    *   `AppDbContext.cs`: Defines the database context and applies configurations.
    *   EF Core Migrations are used to manage database schema changes.
*   **AutoMapper:** Object-object mapper to reduce boilerplate code for mapping between DTOs and domain entities.
    *   `MappingProfile.cs`: Defines the mapping configurations.
*   **FluentValidation:** Library for building strongly-typed validation rules.
    *   Validators are defined in the `ByWay.Application/Validations` directory.
*   **JWT (JSON Web Tokens):** For authentication and authorization.
    *   Configuration is stored in `appsettings.json` using the `JwtSettings.cs` DTO.
*   **ASP.NET Core Identity:** Manages user accounts, authentication, and authorization.
*   **C# 9 (or higher):** Programming language.

## Prerequisites

*   .NET SDK (version 6.0 or higher)
*   SQL Server instance
*   An IDE like Visual Studio or Visual Studio Code

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/ByWay-.git
    cd ByWay-
    ```

2.  **Configure the database:**

    *   Update the connection string in `ByWay.Infrastructure/appsettings.json` with your SQL Server instance details:

    ```json
    {
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=ByWayDB;Trusted_Connection=True;MultipleActiveResultSets=true",
        "IdentityConnection": "Server=your_server;Database=ByWayIdentityDB;Trusted_Connection=True;MultipleActiveResultSets=true"
      },
    }
    ```
    Replace `your_server`, `ByWayDB`, and `ByWayIdentityDB` with your server details and desired database names.

3.  **Apply EF Core Migrations:**

    *   Navigate to the `ByWay.Infrastructure` directory in the console.
    *   Run the following commands to apply migrations to both the main database and the Identity database:

    ```bash
    dotnet ef database update -c AppDbContext
    dotnet ef database update -c IdentityAppDbContext
    ```

4.  **Configure JWT Settings:**
    *   Update JWT settings in `appsettings.json`:

    ```json
      "jwtSettings": {
        "key": "YourSecretKeyForJWTAuthentication",
        "Issuer": "ByWayAPI",
        "Audience": "ByWayUsers",
        "DurationInMinutes": 60
      }
    ```

    *   Replace `"YourSecretKeyForJWTAuthentication"` with a strong, randomly generated key.

5.  **Build and Run the Application:**

    *   Navigate to the `ByWay` directory (project root) in the console.
    *   Run the following command to build and start the application:

    ```bash
    dotnet run
    ```

## Usage Guide

1.  **Register a new user account:**
    *   Send a POST request to `api/Account/register` with the required information (DisplayName, UserName, Email, Password) in the request body.
    *   Example request body:

    ```json
    {
    "displayName": "John Doe",
    "userName": "johndoe",
    "email": "john.doe@example.com",
    "password": "SecurePassword123"
    }
    ```

2.  **Login to an existing user account:**
    *   Send a POST request to `api/Account/login` with the email and password in the request body.
    *   Example request body:

    ```json
    {
    "email": "john.doe@example.com",
    "password": "SecurePassword123"
    }
    ```

3.  **Access protected API endpoints:**
    *   Include the JWT token in the `Authorization` header of the request.
    *   Header format: `Authorization: Bearer <token>`

4.  **Use Admin API Endpoints (Requires Admin Role):**
    *   Ensure the logged-in user has the "Admin" role.  This would typically be set during user creation or via a separate admin panel.
    *   Access admin-specific endpoints like creating courses or instructors.

## API Documentation

### Account Controller

*   `POST api/Account/register`: Registers a new user.
    *   Request body: `RegisterDto.cs`
    *   Response: `UserDto.cs`
*   `POST api/Account/login`: Logs in an existing user.
    *   Request body: `LoginDto.cs`
    *   Response: `UserDto.cs`
*   `GET api/Account/currentUser`: Gets the current user's information (requires authentication).
    *   Response: `UserDto.cs`
*   `GET api/Account/emailExists?email={email}`: Checks if an email address is already registered.
    *   Response: `bool`

### Course Controller

*   `GET api/Course`: Gets all courses.
    *   Response: `IEnumerable<CourseResponse.cs>`
*   `GET api/Course/{id}`: Gets a course by ID.
    *   Response: `CourseResponse.cs`
*    `POST api/Course`: Creates a new Course.
    * Request body : `CreateCourseRequest.cs`
    * Response:  `OK("Created Successfuly")`
*   `PUT api/Course/{id}`: Updates an existing course.
    * Request body : `UpdateCourseRequest.cs`
    * Response: `OK("Updated Successfully")`
*   `DELETE api/Course/{id}`: Deletes an existing course.
    * Response: `OK("Deleted Successfully")`

### Instructor Controller

*   `GET api/Instuctor`: Gets all instructors.
    *   Response: `IEnumerable<InstructorResponse.cs>`
*   `GET api/Instuctor/{id}`: Gets an instructor by ID.
    *   Response: `InstructorResponse.cs`
*   `POST api/Instuctor`: Creates a new instructor.
    *   Request body: `CreateInstructorRequest.cs`
    * Response:  `OK(request)`
*   `PUT api/Instuctor/{id}`: Updates an existing instructor.
    *   Request body: `UpdateInstructorRequest.cs`
    *   Response: `InstructorResponse.cs`
*   `DELETE api/Instuctor/{id}`: Deletes an existing instructor.
     * Response: `OK("Deleted Successfully")`

### Cart Controller

*   `GET api/Cart`: Gets the current user's cart (requires authentication).
    *   Response: `CartResponse.cs`
*   `POST api/Cart/addItem`: Adds a course to the cart (requires authentication).
    *   Request body: `CreateCartItemRequest.cs`
    *   Response: `CartResponse.cs`
*   `PUT api/Cart/updateItem/{itemId}`: Updates the quantity of an item in the cart (requires authentication).
    *   Request body: `UpdateCartItemRequest.cs`
    *   Response: `UpdateCartItemRequest.cs`
*   `POST api/Cart/applyDiscount?discount={discount}`: Applies a discount to the cart (requires authentication).
    *   Response: `string`
*   `DELETE api/Cart/clear`: Clears the cart (requires authentication).
    *   Response: `string`

### Admin Controller (Requires Admin Role)

*   `GET api/Admin/dashboard`: Gets dashboard statistics.
    *   Response: `AdminDashboardDto.cs`
*   `POST api/Admin/instructors`: Creates a new instructor.
    *   Request body: `CreateInstructorRequest.cs`
    *   Response: `InstructorResponse.cs`
*   `POST api/Admin/courses`: Creates a new course.
    *   Request body: `CreateCourseRequest.cs`
*   `GET api/Admin/instructors?PageNumber={pageNumber}&PageSize={pageSize}&SearchTerm={searchTerm}&SortBy={sortBy}&SortDirection={sortDirection}`: Gets all instructors with filtering and pagination.
    *   Response: `PagedResult<InstructorResponse.cs>`
*   `GET api/Admin/courses?PageNumber={pageNumber}&PageSize={pageSize}&SearchTerm={searchTerm}&SortBy={sortBy}&SortDirection={sortDirection}`: Gets all courses with filtering and pagination.
    *   Response: `PagedResult<CourseResponse.cs>`
*   `DELETE api/Admin/instructors/{id}`: Deletes an instructor.
*   `DELETE api/Admin/courses/{id}`: Deletes a course.

## Contributing Guidelines

We welcome contributions to the ByWay project! To contribute, please follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with clear, descriptive messages.
4.  Submit a pull request to the `master` branch.

Please ensure that your code adheres to the project's coding standards and includes appropriate unit tests.

## License Information

No license information was provided in the repository. Please specify a license to clarify the terms of use and distribution of this project. Examples include:

*   **MIT License:** A permissive license that allows almost anything with the proper copyright notice.
*   **Apache 2.0 License:** A permissive license with conditions addressing copyright and patent infringement.
*   **GNU GPL v3:** A copyleft license that requires derivative works to be licensed under the GPL as well.

To add a license:

1.  Choose a license from <https://choosealicense.com/>
2.  Create a file named `LICENSE` in the root directory of the repository.
3.  Copy the text of the license into the `LICENSE` file.
4.  Update this README to reflect the chosen license.


