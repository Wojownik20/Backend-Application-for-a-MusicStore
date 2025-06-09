using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;

namespace MusicStore.WebApi.Extensions
{
    public static class HealthCheckEndpointExtensions
    {
        public static void MapHealthCheckEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        status = report.Status.ToString(),
                        checks = report.Entries.Select(e => new
                        {
                            name = e.Key,
                            status = e.Value.Status.ToString(),
                            error = e.Value.Exception?.Message
                        })
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(
                        response,
                        new JsonSerializerOptions { WriteIndented = true }
                    ));
                }
            });
        }
    }
}
