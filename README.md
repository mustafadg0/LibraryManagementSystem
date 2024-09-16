# Library Management System

Library Management System is a simple web API application built using **ASP.NET Core**, **Entity Framework Core**, and **SQL Server**. It demonstrates a layered architecture with clean separation of concerns, dependency injection, and logging. The project supports basic CRUD operations for managing a library's book inventory, including adding, updating, deleting, and listing books.

Additionally, the project leverages **RabbitMQ** to implement a microservices architecture, enabling asynchronous messaging between services.

## Features

- **CRUD Operations**: Manage books with Create, Read, Update, and Delete endpoints.
- **Layered Architecture**: Separation of business logic, data access, messaging, and API layers.
- **Entity Framework Core**: Integration with SQL Server for database operations.
- **Swagger UI**: API documentation and testing directly from the browser.
- **Logging**: Console and file logging using the built-in ASP.NET Core logging framework.
- **Dependency Injection**: Loose coupling of components via dependency injection.
- **Standardized API Responses with `Result<T>`**: API responses are wrapped in a standardized format with success status and messages.
- **Microservices with RabbitMQ**: The project utilizes RabbitMQ for asynchronous communication between microservices.

## Technologies Used

- **ASP.NET Core 7.0**
- **Entity Framework Core**
- **SQL Server**
- **RabbitMQ**: For messaging between microservices.
- **Swagger**

## Getting Started

### Prerequisites

To run this project locally, you need the following installed on your system:

- .NET 7.0 SDK or later
- SQL Server (LocalDB or Full SQL Server)
- RabbitMQ (Installed locally or via Docker)
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

5. Run RabbitMQ locally or via Docker:

    ```bash
    docker run -d --hostname rabbitmq --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
    ```

6. Run the application:

    ```bash
    dotnet run
    ```

7. Open your browser and navigate to:

    ```
    https://localhost:5001/swagger/index.html
    ```

    This will launch Swagger UI where you can test the API endpoints.

## API Endpoints

- `GET /api/books` - Get a list of all books
- `GET /api/books/{id}` - Get a book by its ID
- `POST /api/books` - Add a new book (Triggers RabbitMQ message)
- `PUT /api/books/{id}` - Update an existing book
- `DELETE /api/books/{id}` - Delete a book by its ID

## Project Structure

The project follows a typical layered architecture:

- **Entities**: Contains domain models (e.g., `Book`).
- **Business**: Contains the service layer responsible for business logic and interaction between the API and data layers. Also, it manages communication with RabbitMQ.
- **Data**: Contains the repository layer that handles data access and interaction with the database.
- **Messaging**: Manages communication between services using RabbitMQ for asynchronous message passing.
- **WebAPI**: Contains the API layer that handles HTTP requests and responses.

## Microservices with RabbitMQ

The project utilizes **RabbitMQ** to implement microservices for asynchronous communication. This is done by using a **producer-consumer model**:
- **RabbitMQPublisher**: When a new book is added to the library, a message is published to a message queue via RabbitMQ.
- **RabbitMQConsumer**: A separate service listens to the queue and processes messages asynchronously. This could be used for notifications, logging, or further processing.

## Result<T> Class for Standardized API Responses

The project includes a `Result<T>` class which standardizes API responses by wrapping the actual data and providing additional fields such as success status and messages. This ensures consistency in API responses and improves error handling.
