using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SilK.OpenMod.EntityFrameworkCore
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public static class ServiceConfiguratorExtensions
    {
        public static IServiceCollection AddPomeloMySqlConnectorResolver(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<PomeloMySqlConnectorResolver>();

            return serviceCollection;
        }
    }
}