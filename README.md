# Subasi Customer MS Web API 

A Web API for test case builded on .NET Core 6. MediatR and CQRS patterns implemented.


## Road Map

#### Code-First
- Created the database in LocalDB using the Code First method by making the necessary configurations.

#### Generic Repository

- Set up a Generic Repository structure for database operations, and I performed Include and Foreign Key queries through the Customer Repository and Address Repository, which I inherited from the Generic Repository.

#### MediatR and CQRS Patterns

- I performed service operations via MediatR and CQRS patterns.

#### Controllers and Responses

- Returned the necessary responses from the controllers by adhering to the endpoints that specified in the test case.

#### AutoMapper and Fluent Validation

- Used Fluent Validation for validation processes and AutoMapper for mapping processes.

#### Global Exception Handling Middleware 

- Finally, took server errors under control through a Global Exception Handling Middleware.
## Run Locally

#### Prerequisites
- Git
- .NET 6.0
- SQL Server 

#### Clone the project

```bash
  git clone https://github.com/enesmetek/Subasi.CustomerMS.git
```

#### Change direction into API folder

```bash
  cd .\Subasi.CustomerMS.API
```

#### Build 

```bash
  dotnet build
```
#### dotnet ef installing  (if needed)

```bash
  dotnet tool install --global dotnet-ef
```

#### Database update

```bash
  dotnet ef database update
```
#### Run the project

```bash
  dotnet run
```
  
## API Endpoints

#### Lists All Customers

```http
  GET /api/Customers
```
#### Get Customer

```http
  GET /api/Customers/{id}
```
#### Get Addresses from Customer

```http
  GET /api/Customers/{id}/Addresses
```
#### Create Customer
```http
  POST /api/Customers
```
#### Update Customer

```http
  PUT /api/Customers/{id}
```
#### Delete Customer

```http
  DELETE /api/Customers/{id}
```
#### Lists All Addresses

```http
  GET /api/Addresses
```
#### Get Address

```http
  GET /api/Addresses/{id}
```
#### Create Address
```http
  POST /api/Addresses
```
#### Update Addresses

```http
  PUT /api/Addresses/{id}/
```
#### Delete Address

```http
  DELETE /api/Addresses/{id}
```
