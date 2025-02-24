# ContactManagement_API  

## Overview  

The Contact Management API is a .NET 8 Web API application designed to manage companies, contacts, and countries. It follows Clean/Onion/Vertical Slice architecture and implements CRUD operations, logging, error handling, unit testing, and API documentation.  

## Technologies Used  

- .NET 8  
- Entity Framework Core (EF Core) Code-First  
- AutoMapper  
- Dependency Injection  
- Logging with `ILogger`  
- Unit Testing (xUnit, Moq)  
- Swagger API Documentation  

## Features  

- **Company Management**: Create, read, update, and delete companies.  
- **Contact Management**: Create, read, update, and delete contacts.  
- **Country Management**: Create, read, update, and delete countries.  
- **Logging**: Centralized error and request logging.  
- **Error Handling**: Proper error messages and HTTP status codes.  
- **Unit Testing**: Ensuring service reliability.  
- **Dependency Injection**: Loose coupling and better testability.  
- **Swagger Documentation**: API documentation for easy interaction.  

---

## Setup & Installation  

### Prerequisites  

- Install .NET 8 SDK  
- Install SQL Server (or use an alternative database with appropriate configuration)  

### Required NuGet Packages  

- `Microsoft.EntityFrameworkCore`  
- `Microsoft.EntityFrameworkCore.SqlServer`  
- `Microsoft.EntityFrameworkCore.Design`  
- `Microsoft.EntityFrameworkCore.Tools`  
- `AutoMapper`  
- `AutoMapper.Extensions.Microsoft.DependencyInjection`  
- `Microsoft.Extensions.Logging`  
- `xUnit`  
- `Moq`  
- `Swashbuckle.AspNetCore` (for Swagger API documentation)
  
---

## API Endpoints  

### **Company Endpoints**  

- `POST /api/company` - Create a new company  
- `GET /api/company` - Get all companies  
- `GET /api/company/{id}` - Get a company by ID  
- `PUT /api/company/{id}` - Update a company  
- `DELETE /api/company/{id}` - Delete a company  

### **Contact Endpoints**  

- `POST /api/contact` - Create a new contact  
- `GET /api/contact` - Get all contacts  
- `GET /api/contact/{id}` - Get a contact by ID  
- `PUT /api/contact/{id}` - Update a contact  
- `DELETE /api/contact/{id}` - Delete a contact  

### **Country Endpoints**  

- `POST /api/country` - Create a new country  
- `GET /api/country` - Get all countries  
- `GET /api/country/{id}` - Get a country by ID  
- `PUT /api/country/{id}` - Update a country  
- `DELETE /api/country/{id}` - Delete a country  

---

## Services Implementation  

- **CompanyService**: Handles business logic for companies.  
- **ContactService**: Handles business logic for contacts.  
- **CountryService**: Handles business logic for countries.  
- **IRepository**: Generic repository for CRUD operations.
- **IContactRepository**: A reposotiry specifically for getting contacts with company and country

---

## Logging & Error Handling  

- Uses `ILogger` for logging errors and warnings.  
- Wraps API calls in `try-catch` blocks for proper exception handling.  

---

## Unit Testing  

- Tests are located in the `UnitTests/` project.  
- Uses **xUnit** and **Moq** for testing services.  

---

## Conclusion  

This project follows a **Clean Architecture** approach with separation of concerns, making it **scalable** and **maintainable**. It includes logging, testing, and API documentation, ensuring **reliability** and **usability**.  
