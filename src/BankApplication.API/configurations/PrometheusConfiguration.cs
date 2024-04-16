using Prometheus;

namespace BankApplication.API;

public static class PrometheusConfiguration
{
    public static void UsePrometheusConfiguration(this IApplicationBuilder app) 
    {
        var counter = Metrics.CreateCounter("BankApplicationAPI", "conta a solicitação para os endpoints da API",
                new CounterConfiguration
                {
                    LabelNames = new[] { "method", "endpoint" }
                });

            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });

            app.UseMetricServer();
            app.UseHttpMetrics();   
    }
}
