using Microsoft.Extensions.Logging;
using OpenMod.Common.Hotloading;
using System.IO;

namespace SilK.OpenMod.EntityFrameworkCore
{
    public sealed class PomeloMySqlConnectorResolver
    {
        public PomeloMySqlConnectorResolver(ILogger<PomeloMySqlConnectorResolver> logger)
        {
            if (!Hotloader.Enabled)
            {
                logger.LogCritical(
                    "Hotloader is not enabled and MySqlConnector v0.69 will not be able to load. Some plugins may not work as intended.");
                return;
            }

            using var stream = GetType().Assembly
                .GetManifestResourceStream("SilK.OpenMod.EntityFrameworkCore.libs.MySqlConnector.dll");

            if (stream == null)
            {
                logger.LogCritical(
                    "Could not retrieve MySqlConnector assembly stream. Some plugins may not work as intended.");
                return;
            }

            using var memStream = new MemoryStream();

            stream.CopyTo(memStream);

            var assemblyBytes = memStream.ToArray();

            Hotloader.LoadAssembly(assemblyBytes);

            logger.LogDebug("Loaded MySqlConnector v0.69 into Hotloader");
        }
    }
}
