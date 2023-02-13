Admin dashboard
============================

Dashboard with admin login, admin panel

# dotnet CLI

## new webapp

```
dotnet new webapp -lang "C#" -f "net6.0" --auth Individual --use-local-db --no-https --kestrelHttpPort 8086 --use-program-main
```

## change data provider

1. remove SqlServer

```
dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
```

2. Install Prerequisites of PostgreSQL

```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
```

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design --version 2.0.0-preview1

Previously an Npgsql.EntityFrameworkCore.PostgreSQL.Design nuget package existed alongside the main package. Its contents have been merged into the main Npgsql.EntityFrameworkCore.PostgreSQL and no new version has been released.

dotnet remove package Npgsql.EntityFrameworkCore.PostgreSQL.Design

3. modify appsettings.json

```json
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=32768;Database=kids_bookstore;Username=postgres;Password=postgrespw"
  },
```

4. modify Program.cs

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
```

5. Run database Migration

delete Migrations folder under Data directory manully.

```
dotnet ef migrations add InitialCreate
```

Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'

5.2 modify migration(this is no need to do, as you can recreate migrations files)

```csharp
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
```

```csharp
HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
```

change to:

```csharp
HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
```

```csharp
Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
```

change to:

```csharp
Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
```

> The default value generation strategy has changed from the older SERIAL columns to the newer IDENTITY columns, introduced in PostgreSQL 10.

6. update database

```
dotnet ef database update
```