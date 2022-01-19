//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Diagnostics.HealthChecks;

//namespace DBWarmUpApp.WebApp.Extentions
//{
//    public static class BlogDdContextHealthCheck
//    {
//        public static IHealthChecksBuilder AddDbContextCheck<TContext>(this IHealthChecksBuilder builder, string? name = null, HealthStatus? failureStatus = null, IEnumerable<string>? tags = null, Func<TContext, CancellationToken, Task<bool>>? customTestQuery = null) where TContext : DbContext
//        {
//            Func<TContext, CancellationToken, Task<bool>> myCustomTestQuery = customTestQuery;
//            if (builder == null)
//            {
//                throw new ArgumentNullException("builder");
//            }

//            if (name == null)
//            {
//                name = typeof(TContext).Name;
//            }

//            if (myCustomTestQuery != null)
//            {
//                builder.Services.Configure(name, delegate (BlogDbContextHealthCheckOptions<TContext> options)
//                {
//                    options.CustomTestQuery = myCustomTestQuery;
//                });
//            }

//            return builder.AddCheck<DbContextHealthCheck<TContext>>(name, failureStatus, tags ?? Enumerable.Empty<string>());
//        }
//    }
//}
