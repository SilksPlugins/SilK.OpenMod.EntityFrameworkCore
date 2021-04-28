# SilK.OpenMod.EntityFrameworkCore
A OpenMod plugin which adds the ability to use Pomelo's MySQL EF Core.

> **DISCLAIMER:** The hotloader for OpenMod cannot be disabled or else this won't work.

## Usage

There are three steps to including SilK.OpenMod.EntityFrameworkCore in your OpenMod plugin:

- Include the NuGet package in your project - `Install-Package SilK.OpenMod.EntityFrameworkCore`

- Add the PomeloMySqlConnectorResolver to your container configurator:
  ```cs
  public class ContainerConfigurator : IContainerConfigurator
  {
      public void ConfigureContainer(IOpenModServiceConfigurationContext openModStartupContext,
          ContainerBuilder containerBuilder)
      {
          ...
          containerBuilder.AddPomeloMySqlConnectorResolver();
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
