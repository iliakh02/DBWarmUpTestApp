using DBWarmUpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWarmUpApp.Domain
{
    public class BlogDbContext: DbContext
    {
        //public static readonly ILoggerFactory testLoggerFactory
        //    = new LoggerFactory().AddProvider(builder => builder.AddConsole()); 
        public DbSet<Blog> Blogs { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            //options
            //    .UseLoggerFactory(testLoggerFactory)
            //    .EnableSensitiveDataLogging();
    }
}
