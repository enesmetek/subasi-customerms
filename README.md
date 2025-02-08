# Subasi Customer Management System (CustomerMS)

A Web API built on **.NET Core 6**, implementing **MediatR** and **CQRS** patterns for efficient customer management.

---

## 📌 Architectural Overview

This project demonstrates a customer management system focusing on scalable and maintainable architecture. Key features include:

- **Code-First Approach**: Utilizes Entity Framework's Code-First methodology for database creation and management.
- **Generic Repository Pattern**: Implements a generic repository for streamlined data access operations.
- **MediatR and CQRS**: Applies MediatR to facilitate the Command Query Responsibility Segregation pattern.
- **AutoMapper**: Simplifies object-object mapping.
- **FluentValidation**: Ensures robust input validation.
- **Global Exception Handling Middleware**: Provides centralized error handling.

---

## 🏗️ Project Components

### 🌐 Subasi.CustomerMS.API

The **Subasi.CustomerMS.API** project serves as the main application, handling HTTP requests and responses. It is structured to promote separation of concerns and adheres to best practices in API development.

---

## 🚀 Running the Project Locally

### 📌 Prerequisites

- **.NET 6.0 SDK** installed on your system.
- **SQL Server** or **LocalDB** for database operations.

### 🔧 Setup Instructions

1. **Clone the repository**:
   ```sh
   git clone https://github.com/enesmetek/subasi-customerms.git
   ```
2. **Navigate into the project directory**:
   ```sh
   cd subasi-customerms
   ```
3. **Restore dependencies**:
   ```sh
   dotnet restore
   ```
4. **Update the database**:
   ```sh
   dotnet ef database update --project Subasi.CustomerMS.API
   ```
5. **Build the solution**:
   ```sh
   dotnet build
   ```
6. **Run the application**:
   ```sh
   dotnet run --project Subasi.CustomerMS.API
   ```

   The API will be accessible at `https://localhost:5001` by default.

---

## 📡 API Endpoints

Below are the available endpoints in **Subasi.CustomerMS.API**:

| HTTP Method | Endpoint                 | Description               |
|-------------|--------------------------|---------------------------|
| `GET`       | `/api/customers`         | Retrieve all customers    |
| `GET`       | `/api/customers/{id}`    | Retrieve a specific customer by ID |
| `POST`      | `/api/customers`         | Create a new customer     |
| `PUT`       | `/api/customers/{id}`    | Update an existing customer |
| `DELETE`    | `/api/customers/{id}`    | Delete a customer         |

---

## 📜 License

This project is licensed under the **MIT License**.

---

## 🤝 Contributing

Contributions are welcome! Feel free to submit a pull request or open an issue.

---

## 📧 Contact

For any questions or issues, please reach out via GitHub Issues or email me at **[emkafali@gmail.com]**.

---

### 📢 Star the Repository ⭐

If you found this project useful, consider giving it a star on GitHub! 😊

---
