using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Grafana.Loki;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LoanApplicationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.Http("http://loki:3100/api/prom/push")
            //.WriteTo.GrafanaLoki("http://loki:3100", labels: new List<LokiLabel>
            //        {
            //           new LokiLabel {Key = "job", Value ="loan-api"},
            //           new LokiLabel {Key = "environement", Value ="dev"},
            //           new LokiLabel {Key = "app", Value ="loan-application-service"}
            //        }
            //)

            //.WriteTo.GrafanaLoki ("http://loki:3100", new LokiSinkConfiguration
            //{
            //        Label = new List<LokiLabel>
            //        {
            //            new LokiLabel {Key = "job", Value ="loan-api"},
            //            new LokiLabel {Key = "environement", Value ="dev"},
            //            new LokiLabel {Key = "app", Value ="loan-application-service"}
            //        }
            //}) 

            //.WriteTo.GrafanaLoki("http://loki:3100", labels: new Dictionary<string, string>{
            //    {"job", "loan-api"}
            //    {"environment", "development"},
            //    {"level", "info"}
            //})
            .CreateLogger();

            try
            {
                Log.Information("Starting application...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }
 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // Add this line to enable Serilog
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}