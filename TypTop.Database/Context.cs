using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TypTop.Database
{
    public class Context : DbContext
    {
        public string ConnectionString { get; set; }
        public Context(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserLevel> UserLevel { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<World> World { get; set; }
        public DbSet<Word> Word { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //set WorldId as unique
            builder.Entity<Level>()
                .HasIndex(l => l.WorldId)
                .IsUnique();

            //set Index as unique
            builder.Entity<Level>()
                .HasIndex(l => l.Index)
                .IsUnique();

            //set UserId and LevelId as composite primary key
            builder.Entity<UserLevel>()
                .HasKey(l => new { l.UserId, l.LevelId });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);


    }
}
