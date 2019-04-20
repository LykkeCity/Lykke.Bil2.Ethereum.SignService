using System;
using JetBrains.Annotations;
using Lykke.Bil2.Ethereum.SignService.Services;
using Lykke.Bil2.Ethereum.SignService.Settings;
using Lykke.Bil2.Sdk.SignService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Bil2.Ethereum.SignService
{
    [UsedImplicitly]
    public class Startup
    {
        private const string IntegrationName = "Ethereum";

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildBlockchainSignServiceProvider<AppSettings>(options =>
            {
                options.IntegrationName = IntegrationName;

                // Register required service implementations:

                options.TransactionSignerFactory = ctx =>
                    new TransactionSigner
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.AddressGeneratorFactory = ctx =>
                    new AddressGenerator
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                // To access settings for any purpose, (f.e. to register additional services,
                // taking in account that usually it shouldn't be necessary in sign service),
                // uncomment code below:
                //
                // options.UseSettings = settings =>
                // {
                //     services.AddSingleton<IService>(new ServiceImpl(settings.CurrentValue.ServiceSettingValue));
                // };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            app.UseBlockchainSignService(options =>
            {
                options.IntegrationName = IntegrationName;
            });
        }
    }
}
