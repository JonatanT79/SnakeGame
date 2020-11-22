using Microsoft.EntityFrameworkCore;
using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Data
{
    class HighscoreContext : DbContext
    {
        DbSet<HighScore> HighScore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = SnakeGame; Trusted_Connection = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
