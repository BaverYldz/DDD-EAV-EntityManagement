# Employee Management System

A Web API developed with **.NET 9.0** to manage **Employees**, **Custom Attributes**, and **Attribute Values** using **Domain-Driven Design (DDD)** and the **Entity-Attribute-Value (EAV)** model.

## Technologies

- **Backend**: ASP.NET Core 9.0 (Web API)
- **Database**: MSSQL Server
- **ORM**: Entity Framework Core
- **Design**: Domain-Driven Design (DDD), Entity-Attribute-Value (EAV)
- **API Testing**: Scalar
   
## Domain-Driven Design (DDD)

This project uses **DDD** to separate business logic from infrastructure concerns. It focuses on:
- **Entities**: Core objects with a unique identity (e.g., `Employee`).
- **Repositories**: Interfaces for retrieving and saving entities.

## Entity-Attribute-Value (EAV) Model

The **EAV** model is used to store dynamic attributes. Custom attributes and their values are stored flexibly, allowing for easy updates without altering the database schema.

## API Endpoints

- **Employees**
  - `GET /api/employees`
  - `POST /api/employees`
  - `GET /api/employees/{id}`
  - `PUT /api/employees/{id}`
  - `DELETE /api/employees/{id}`
  
- **Custom Attributes**
  - `GET /api/customattributes`
  - `POST /api/customattributes`
  - `GET /api/customattributes/{id}`
  - `PUT /api/customattributes/{id}`
  - `DELETE /api/customattributes/{id}`

- **Attribute Values**
  - `GET /api/attributevalues`
  - `POST /api/attributevalues`
  - `GET /api/attributevalues/{id}`
  - `PUT /api/attributevalues/{id}`
  - `DELETE /api/attributevalues/{id}`

## Getting Started

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/employee-management-system.git
    ```

2. Install dependencies:

    ```bash
    cd employee-management-system
    dotnet restore
    ```

3. Run the application:

    ```bash
    dotnet run
    ```

4. The API will be available at `https://localhost:5001`.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
