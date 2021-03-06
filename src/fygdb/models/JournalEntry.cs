﻿using System;

namespace fygdb.models
{
    public class JournalEntry
    {
        public int JournalEntryId { get; set; }
        public int Chapter { get; set; }
        public int BeginVerse { get; set; }
        public int EndVerse { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int EntryTypeId { get; set; }
        public EntryType EntryType { get; set; }

        public string VersesText
        {
            get
            {
                if (HasVerses())
                    return InternalVersesText();
                else
                    return "";
            }
        }

        public string ChapterText
        {
            get
            {
                if (HasChapter())
                    return Chapter.ToString();
                else
                    return "";
            }
        }

        public bool HasVerses() => BeginVerse > 0 && EndVerse > 0;

        private string InternalVersesText()
        {
            if (BeginVerse != EndVerse)
                return $"{BeginVerse}-{EndVerse}";
            else
                return BeginVerse.ToString();
        }

        public bool HasChapter() => Chapter > 0;
    }
}
