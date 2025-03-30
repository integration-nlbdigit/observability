using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;
 
namespace LoanApplicationService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient(); // Register HttpClient
            // Add health checks (optional, but useful for monitoring)
            services.AddHealthChecks();
            services.AddSwaggerGen();
 
 
            // OpenTelemetry configuration
            services.AddOpenTelemetry()
                .WithMetrics( builder =>
                {
                    builder
                        .AddAspNetCoreInstrumentation()
                        //.AddHttpClientInstrumentation() // Instrumentation for outgoing HttpClient requests
                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("LoanApplicationService"))
                        .AddConsoleExporter(); // Optional: Log traces in the console
                        //.addPrometheusExporter();  // This line enables Prometheus metrics export

                    builder.AddHttpClientInstrumentation();
                });
            services.AddHttpClient(); // If needed for other calls
        }
 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loan Application Service v1"));
            
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map API controllers
                endpoints.MapHealthChecks("/health");
                endpoints.MapMetrics("/metrics"); // Expose metrics endpoint for Prometheus
            });
        }
    }
}