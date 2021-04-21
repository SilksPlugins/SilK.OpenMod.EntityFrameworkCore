using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.EntityFrameworkCore;
using System;

namespace SilK.OpenMod.EntityFrameworkCore
{
    public abstract class OpenModPomeloDbContext<TSelf> : OpenModDbContext<TSelf> where TSelf : OpenModPomeloDbContext<TSelf>
    {
        private readonly IServiceProvider _serviceProvider;

        protected OpenModPomeloDbContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _serviceProvider.GetRequiredService<PomeloMySqlConnectorResolver>();
        }

        protected OpenModPomeloDbContext(DbContextOptions<TSelf> options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _serviceProvider.GetRequiredService<PomeloMySqlConnectorResolver>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var connectionStringName = GetConnectionStringName();
            var connectionStringAccessor = _serviceProvider.GetRequiredService<IConnectionStringAccessor>();
            var connectionString = connectionStringAccessor.GetConnectionString(connectionStringName);

            optionsBuilder.UseMySql(connectionString!,
                options => { options.MigrationsHistoryTable(MigrationsTableName); });
        }
    }
}
