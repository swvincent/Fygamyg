using System;
using System.Collections.Generic;
using System.Text;

namespace fygdb.models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Category { get; set; }

        public List<JournalEntry> JournalEntries { get; set; }

        public override string ToString()
        {
            return BookName;
        }
    }
}
