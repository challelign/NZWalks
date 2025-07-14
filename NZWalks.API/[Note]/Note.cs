namespace NZWalks.API._Note_
{
    public class Note
    {

        /* 
        Npgsql.EntityFrameworkCore.PostgreSQL
        Microsoft.EntityFrameworkCore.Tools
        System.IdentityModel.Tokens.Jwt
        Microsoft.AspNetCore.Authentication.JwtBearer
        Microsoft.IdentityModel.Tokens
        Microsoft.AspNetCore.Identity.EntityFrameworkCore
        
         */

        /*

                MyApp/
        ├── Core/
        │   ├── Domain/           ⟵ Entities (business models)
        │   └── Application/      ⟵ DTOs, Interfaces, Logic
        ├── Infrastructure/       ⟵ Repository Implementations, DbContext
        └── WebAPI/               ⟵ API Controllers (uses AutoMapper, DTOs)




        [Presentation Layer] (e.g., ASP.NET Controller)
            |
            |-- Receives CreateCustomerDto
            v
        [Application Layer]
            |
            |-- Uses AutoMapper to map DTO to Entity
            |-- Uses ICustomerRepository to add entity
            v
        [Domain Layer]
            |
            |-- Contains Customer Entity
            v
        [Infrastructure Layer]
            |
            |-- Implements ICustomerRepository using DbContext
            |-- DbContext saves entity to the database



                | Concept      | Layer                                         | Purpose                             | Example                                      |
        | ------------ | --------------------------------------------- | ----------------------------------- | -------------------------------------------- |
        | `DbContext`  | Infrastructure                                | Access database via EF Core         | `ApplicationDbContext : DbContext`           |
        | `DTO`        | Presentation/App                              | Transfer data safely between layers | `CreateCustomerDto`                          |
        | `Entity`     | Domain                                        | Core domain logic and identity      | `Customer` entity                            |
        | `Repository` | Interface: App/Domain<br>Impl: Infrastructure | Abstraction over data access        | `ICustomerRepository` & `CustomerRepository` |
        | `AutoMapper` | Application                                   | Maps between DTOs and entities      | `mapper.Map<Customer>(dto)`                  |




            🔄 How Everything Works Together
    🧩 Application Flow:
    User sends a request to API (Presentation).

    API controller maps DTO to input and calls a use case handler (Application).

    Handler retrieves an entity via a repository interface.

    Repository interface is implemented by Infrastructure, which uses DbContext to query the database.

    The entity performs business logic (Domain).

    Changes are saved back to DB.

    Response DTO is mapped and returned.

                 */
    }
}
