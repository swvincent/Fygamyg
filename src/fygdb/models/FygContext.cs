using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace fygdb.models
{
    class FygContext : DbContext
    {
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }

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
            // Journal Entry

            modelBuilder.Entity<JournalEntry>().ToTable("JournalEntries");
            modelBuilder.Entity<JournalEntry>().HasKey(j => j.JournalEntryId);
            modelBuilder.Entity<JournalEntry>().Property(j => j.Title).IsRequired();
            modelBuilder.Entity<JournalEntry>().Property(j => j.NoteText).IsRequired();

            modelBuilder.Entity<JournalEntry>()
                .HasOne(j => j.Book)
                .WithMany(b => b.JournalEntries)
                .HasForeignKey(j => j.BookId);

            modelBuilder.Entity<JournalEntry>()
                .HasOne(j => j.EntryType)
                .WithMany(b => b.JournalEntries)
                .HasForeignKey(j => j.EntryTypeId);

            // Entry Type

            modelBuilder.Entity<EntryType>().ToTable("EntryTypes");
            modelBuilder.Entity<EntryType>().HasKey(e => e.EntryTypeId);
            modelBuilder.Entity<EntryType>().Property(e => e.EntryTypeName).IsRequired();

            modelBuilder.Entity<EntryType>().HasData(
                new EntryType { EntryTypeId = 1, EntryTypeName = "Academic"},
                new EntryType { EntryTypeId = 2, EntryTypeName = "Devotional" }
                );

            // Book

            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<Book>().Property(b => b.BookName).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Category).IsRequired();

            // TODO: Populate books from a JSON file or similar
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, BookName = "Genesis", Category = "OT" },
                new Book { BookId = 2, BookName = "Exodus", Category = "OT" },
                new Book { BookId = 3, BookName = "Leviticus", Category = "OT" },
                new Book { BookId = 4, BookName = "Numbers", Category = "OT" },
                new Book { BookId = 5, BookName = "Deuteronomy", Category = "OT" },
                new Book { BookId = 6, BookName = "Joshua", Category = "OT" },
                new Book { BookId = 7, BookName = "Judges", Category = "OT" },
                new Book { BookId = 8, BookName = "Ruth", Category = "OT" },
                new Book { BookId = 9, BookName = "1 Samuel", Category = "OT" },
                new Book { BookId = 10, BookName = "2 Samuel", Category = "OT" },
                new Book { BookId = 11, BookName = "1 Kings", Category = "OT" },
                new Book { BookId = 12, BookName = "2 Kings", Category = "OT" },
                new Book { BookId = 13, BookName = "1 Chronicles", Category = "OT" },
                new Book { BookId = 14, BookName = "2 Chronicles", Category = "OT" },
                new Book { BookId = 15, BookName = "Ezra", Category = "OT" },
                new Book { BookId = 16, BookName = "Nehemiah", Category = "OT" },
                new Book { BookId = 17, BookName = "Esther", Category = "OT" },
                new Book { BookId = 18, BookName = "Job", Category = "OT" },
                new Book { BookId = 19, BookName = "Psalms", Category = "OT" },
                new Book { BookId = 20, BookName = "Proverbs", Category = "OT" },
                new Book { BookId = 21, BookName = "Ecclesiastes", Category = "OT" },
                new Book { BookId = 22, BookName = "Song of Solomon", Category = "OT" },
                new Book { BookId = 23, BookName = "Isahiah", Category = "OT" },
                new Book { BookId = 24, BookName = "Jeremiah", Category = "OT" },
                new Book { BookId = 25, BookName = "Lamentations", Category = "OT" },
                new Book { BookId = 26, BookName = "Ezekiel", Category = "OT" },
                new Book { BookId = 27, BookName = "Daniel", Category = "OT" },
                new Book { BookId = 28, BookName = "Hosea", Category = "OT" },
                new Book { BookId = 29, BookName = "Joel", Category = "OT" },
                new Book { BookId = 30, BookName = "Amos", Category = "OT" },
                new Book { BookId = 31, BookName = "Obadiah", Category = "OT" },
                new Book { BookId = 32, BookName = "Jonah", Category = "OT" },
                new Book { BookId = 33, BookName = "Micah", Category = "OT" },
                new Book { BookId = 34, BookName = "Nahum", Category = "OT" },
                new Book { BookId = 35, BookName = "Habakkuk", Category = "OT" },
                new Book { BookId = 36, BookName = "Zephaniah", Category = "OT" },
                new Book { BookId = 37, BookName = "Haggai", Category = "OT" },
                new Book { BookId = 38, BookName = "Zechariah", Category = "OT" },
                new Book { BookId = 39, BookName = "Malachi", Category = "OT" },
                new Book { BookId = 40, BookName = "Matthew", Category = "NT" },
                new Book { BookId = 41, BookName = "Mark", Category = "NT" },
                new Book { BookId = 42, BookName = "Luke", Category = "NT" },
                new Book { BookId = 43, BookName = "John", Category = "NT" },
                new Book { BookId = 44, BookName = "Acts of the Apostles", Category = "NT" },
                new Book { BookId = 45, BookName = "Romans", Category = "NT" },
                new Book { BookId = 46, BookName = "1 Corinthians", Category = "NT" },
                new Book { BookId = 47, BookName = "2 Corinthians", Category = "NT" },
                new Book { BookId = 48, BookName = "Galatians", Category = "NT" },
                new Book { BookId = 49, BookName = "Ephesians", Category = "NT" },
                new Book { BookId = 50, BookName = "Philippians", Category = "NT" },
                new Book { BookId = 51, BookName = "Colossians", Category = "NT" },
                new Book { BookId = 52, BookName = "1 Thessalonians", Category = "NT" },
                new Book { BookId = 53, BookName = "2 Thessalonians", Category = "NT" },
                new Book { BookId = 54, BookName = "1 Timothy", Category = "NT" },
                new Book { BookId = 55, BookName = "2 Timothy", Category = "NT" },
                new Book { BookId = 56, BookName = "Titus", Category = "NT" },
                new Book { BookId = 57, BookName = "Philemon", Category = "NT" },
                new Book { BookId = 58, BookName = "Hebrews", Category = "NT" },
                new Book { BookId = 59, BookName = "James", Category = "NT" },
                new Book { BookId = 60, BookName = "1 Peter", Category = "NT" },
                new Book { BookId = 61, BookName = "2 Peter", Category = "NT" },
                new Book { BookId = 62, BookName = "1 John", Category = "NT" },
                new Book { BookId = 63, BookName = "2 John", Category = "NT" },
                new Book { BookId = 64, BookName = "3 John", Category = "NT" },
                new Book { BookId = 65, BookName = "Jude", Category = "NT" },
                new Book { BookId = 66, BookName = "Revelation", Category = "NT" }
                );
        }
    }
}
