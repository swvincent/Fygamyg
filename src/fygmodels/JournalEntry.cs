using System;

namespace fygmodels
{
    public class JournalEntry
    {
        public int ID { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int AlphaVerse { get; set; }
        public int OmegaVerse { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }
    }
}
