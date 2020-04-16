using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Amazon.Extensions.Configuration.SystemsManager;

namespace ParamStoreAWSRazor
{
    public class Program
    {
        public static void Main()
        {
            //CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder().Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder() =>
            WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder
                        .AddSystemsManager("/SQSDashboard", reloadAfter: TimeSpan.FromSeconds(1));
                }).UseStartup<Startup>();
    }
}
