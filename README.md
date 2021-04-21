# SilK.OpenMod.EntityFrameworkCore
A OpenMod plugin which adds the ability to use Pomelo's MySQL EF Core.

## Usage

There are three steps to including SilK.OpenMod.EntityFrameworkCore in your OpenMod plugin:

- Include the NuGet package in your project - `Install-Package SilK.OpenMod.EntityFrameworkCore`

- Add the PomeloMySqlConnectorResolver to your service configurator:
  ```cs
  public class ServiceConfigurator : IServiceConfigurator
  {
      public void ConfigureServices(IOpenModServiceConfigurationContext openModStartupContext,
          IServiceCollection serviceCollection)
      {
          ...
          serviceCollection.AddPomeloMySqlConnectorResolver();
          ...
      }
  }
  ```

- Change your database context's base type to `OpenModPomeloDbContext<>`:
  ```cs
  public class ExampleDbContext : OpenModDbContext<ExampleDbContext>
  {
      ...
  }
  ```
  to
  ```cs
  public class ExampleDbContext : OpenModPomeloDbContext<ExampleDbContext>
  {
      ...
  }
  ```
