using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Route.Api.Data;

namespace Route.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
        var host=    CreateHostBuilder(args).Build();
            //3 提取服务，将服务在这dsf里拉出来，为了方便，但asdasd实际不这样操作324234
            using (var scope=host.Services.CreateScope())
            {
                try
                {
                    
                    var dbContext = scope.ServiceProvider.GetService<RouteDbContext>();
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.Migrate();//数据库迁移
                    
                }
                catch (Exception e)
                {
                    
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "Mgration Error!");
                }
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
