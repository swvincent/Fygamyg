using System;

namespace fygdb.models
{
    public class JournalEntry
    {
        public int ID { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int BeginVerse { get; set; }
        public int EndVerse { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }
    }
}
