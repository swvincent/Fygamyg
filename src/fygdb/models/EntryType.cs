using System;
using System.Collections.Generic;
using System.Text;

namespace fygdb.models
{
    public class EntryType
    {
        public int EntryTypeId { get; set; }
        public string EntryTypeName { get; set; }

        public List<JournalEntry> JournalEntries { get; set; }

        public override string ToString()
        {
            return EntryTypeName;
        }
    }
}
