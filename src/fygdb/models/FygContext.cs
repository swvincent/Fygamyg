using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace fygdb.models
{
    class FygContext : DbContext
    {
        public DbSet<JournalEntry> JournalEntries { get; set; }

        public FygContext()
        {
            // TODO: Switch to migrations
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
