using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace StudentManagementServices.Services.SeedingService
{
    public static class PrepDatabaseData
    {
        public static void PrepDataSeeding(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
        }

        private static void SeedData(DataContext context)
        {

            SeedingService.AutoSeedDepartments(context);


        }
    }
}
