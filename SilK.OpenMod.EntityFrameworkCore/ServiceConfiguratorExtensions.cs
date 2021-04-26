using Autofac;
using JetBrains.Annotations;

namespace SilK.OpenMod.EntityFrameworkCore
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public static class ServiceConfiguratorExtensions
    {
        public static void AddPomeloMySqlConnectorResolver(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<PomeloMySqlConnectorResolver>()
                .AsSelf()
                .SingleInstance()
                .AutoActivate();
        }
    }
}