# Library Management System

Library Management System is a simple web API application built using ASP.NET Core, Entity Framework Core, and SQL Server. 
It demonstrates a layered architecture with clean separation of concerns, dependency injection, and logging. 
The project supports basic CRUD operations for managing a library's book inventory, including adding, updating, deleting, and listing books.

## Features

- **CRUD Operations**: Manage books with Create, Read, Update, and Delete endpoints.
- **Layered Architecture**: Separation of business logic, data access, and API layers.
- **Entity Framework Core**: Integration with SQL Server for database operations.
- **Swagger UI**: API documentation and testing directly from the browser.
- **Logging**: Console and file logging using the built-in ASP.NET Core logging framework.
- **Dependency Injection**: Loose coupling of components via dependency injection.

## Technologies Used

- **ASP.NET Core 7.0**
- **Entity Framework Core**
- **SQL Server**
- **Swagger**

## Getting Started

### Prerequisites

To run this project locally, you need the following installed on your system:

- .NET 7.0 SDK or later
- SQL Server (LocalDB or Full SQL Server)
- Git

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/mustafadg0/LibraryManagementSystem.git
    cd LibraryManagementSystem
    ```

2. Restore the dependencies:

    ```bash
    dotnet restore
    ```

3. Set up the database. Make sure the connection string in `appsettings.json` matches your local SQL Server configuration. The default is:

    ```json
    "ConnectionStrings": {
      "LibraryDatabase": "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;"
    }
    ```

4. Apply the migrations and update the database:

    ```bash
    dotnet ef database update
    ```

5. Run the application:

    ```bash
    dotnet run
    ```

6. Open your browser and navigate to:

    ```
    https://localhost:5001/swagger/index.html
    ```

    This will launch Swagger UI where you can test the API endpoints.

## API Endpoints

- `GET /api/books` - Get a list of all books
- `GET /api/books/{id}` - Get a book by its ID
- `POST /api/books` - Add a new book
- `PUT /api/books/{id}` - Update an existing book
- `DELETE /api/books/{id}` - Delete a book by its ID

## Project Structure

The project follows a typical layered architecture:

- **Entities**: Contains domain models (e.g., `Book`).

