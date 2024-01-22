using MarketList.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketList.Tools
{
    public class DboContext : DbContext
    {

        private string _filePath;

        public DboContext(string filePath)
        {
            _filePath = filePath;
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_filePath}");
            base.OnConfiguring(optionsBuilder);
        }
      
      
    }
}
