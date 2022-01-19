using DBWarmUpApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWarmUpApp.Domain
{
    public class BlogRepository : IBlogRepository
    {
        BlogDbContext dbContext;

        public BlogRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(Blog blog)
        {
            try
                {
                dbContext.Blogs.Add(blog);
                dbContext.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public List<Blog> Blogs()
        {
            return dbContext.Blogs.ToList();
        }

        public async Task<bool> CanConnectAsync()
        {
            Console.WriteLine("Can connect async result:");
            return await dbContext.Database.CanConnectAsync();
        }
    }
}
