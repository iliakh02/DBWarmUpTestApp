using Microsoft.EntityFrameworkCore;

namespace DBWarmUpApp.WebApp.Extentions
{
    internal class BlogDbContextHealthCheckOptions<TContext> where TContext : DbContext
    {
        public Func<TContext, CancellationToken, Task<bool>> CustomTestQuery { get; set; }
    }
}
