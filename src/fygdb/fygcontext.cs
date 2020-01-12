using fygmodels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace fygdb
{
    class FygContext : DbContext
    {
        public DbSet<JournalEntry> JournalEntries { get; set; }

        public FygContext()
        {
            //TODO: Should use this or migrations?
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=test.fygamyg;");

            // base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JournalEntry>().ToTable("JournalEntries");
        }
    }
}
}
