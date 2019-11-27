using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TypTop.Database
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=127.0.0.1;Database=Test;User Id=sa;Password = SuperDB@Top01;");
    }
}
