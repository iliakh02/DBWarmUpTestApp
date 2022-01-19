using DBWarmUpApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWarmUpApp.Domain
{
    public interface IBlogRepository
    {
        bool Add(Blog blog);
        List<Blog> Blogs();
        Task<bool> CanConnectAsync();
    }
}
