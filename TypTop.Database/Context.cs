﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TypTop.Database
{
    public class Context : DbContext
    {
        public Context(string connectionString)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Word> Word { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("");
    }
}
