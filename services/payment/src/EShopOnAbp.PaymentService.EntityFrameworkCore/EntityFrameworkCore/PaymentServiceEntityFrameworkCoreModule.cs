﻿using EShopOnAbp.PaymentService.PaymentRequests;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace EShopOnAbp.PaymentService.EntityFrameworkCore
{
    [DependsOn(
        typeof(PaymentServiceDomainModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule)
        )]
    public class PaymentServiceEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PaymentServiceEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PaymentServiceDbContext>(options =>
            {
                options.AddRepository<PaymentRequest, PaymentRequestEfCoreRepository>();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also PaymentServiceMigrationsDbContextFactory for EF Core tooling. */
                options.UseSqlServer();
            });
        }
    }
}
