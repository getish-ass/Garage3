﻿using Garage3.Data;
using Garage3.Data.Data;

namespace Garage3.Extensions
{
    public static class  ApplicationBuilderExtensions
    {

        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<Garage3Context>();


                try
                {
                    await SeedData.InitAsync(db);
                }
                catch (Exception e)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(string.Join(" ", e.Message));
                    //throw;
                }
            }

            return app;
        }






    }
}
