using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities.Users;

namespace WebApp.Data.DbContexts
{
    public class WebAppDbContext:DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        { }
        public virtual DbSet<User> Users { get; set; }
    }
}
