using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Scraper.Classes;

namespace Scraper
{
    public class DBContext:DbContext
    {
        private const string connectionString = "server=localhost;port=3306;database=forum;user=root";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }
        public virtual DbSet<E90Prekes> E90Prekes { get; set; }
        public virtual DbSet<E60Prekes> E60Prekes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
