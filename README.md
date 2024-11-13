# CodeFirst Project

This project demonstrates a Code-First approach using Entity Framework Core with a PostgreSQL database. It includes a Web API project (`CodeFirst.WebApi`) and a data access project (`CodeFirst.Data`).

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL

## Setup

1. **Clone the repository**:
   ```sh
   git clone <repository-url>
   cd CodeFirst
   ```

2. **Update the database connection string**:
   Modify the connection string in `CodeFirst.WebApi/appsettings.Development.json` to match your PostgreSQL setup:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=CodeFirstDb1;Username=<your-username>;Password=<your-password>;Trust Server Certificate=true"
     }
   }
   ```

3. **Restore the packages**:
   ```sh
   dotnet restore
   ```

4. **Build the solution**:
   ```sh
   dotnet build
   ```

5. **Apply migrations and update the database**:
   ```sh
   dotnet ef migrations add InitialCreate --project CodeFirst.Data --startup-project CodeFirst.WebApi
   dotnet ef database update --project CodeFirst.Data --startup-project CodeFirst.WebApi
   ```

## Running the Application

1. **Navigate to the Web API project directory**:
   ```sh
   cd CodeFirst.WebApi
   ```

2. **Run the application**:
   ```sh
   dotnet run
   ```

3. **Access the Swagger UI**:
   Open your browser and navigate to `https://localhost:5001/swagger` to explore the API endpoints.

## Project Structure

- `CodeFirst.Data`: Contains the data access layer, including the `DbContext` and entity classes.
- `CodeFirst.WebApi`: Contains the Web API project, including controllers and configuration.

## Entity Classes

### GameEntity

```csharp
namespace CodeFirst.Data.Entities;

public class GameEntity : BaseEntity
{
    public string Name { get; set; }
    public string Platform { get; set; }
}
```

### MovieEntity

```csharp
namespace CodeFirst.Data.Entities;

public class MovieEntity : BaseEntity
{
    public string Title { get; set; }
    public string Genre { get; set; }
}
```

## DbContext

### CodeFirstDbContext

```csharp
using CodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data.Context;

public class CodeFirstDbContext : DbContext
{
    public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options)
    {
    }

    public DbSet<MovieEntity> Movies => Set<MovieEntity>();
    public DbSet<GameEntity> Games => Set<GameEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CodeFirstDb1;Username=<your-username>;Password=<your-password>");
    }
}
```

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
