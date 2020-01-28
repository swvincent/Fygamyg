using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fygdb.models;
using Microsoft.EntityFrameworkCore;

namespace fygdb
{
    public class FygHelper : IDisposable
    {
        private readonly FygContext context;

        public FygHelper()
        {
            context = new FygContext();
        }

        public List<JournalEntry> GetJournalEntries(int bookId, int chapter, int beginVerse, int endVerse)
        {
            var q = context.JournalEntries
                .Where(j => j.BookId == bookId);

            if (chapter > 0)
            { 
                q = q.Where(j => j.Chapter == chapter);

                if (beginVerse > 0 && endVerse > 0)
                {
                    q = q.Where(j => (j.BeginVerse >= beginVerse && j.BeginVerse <= endVerse) ||
                        (j.EndVerse >= beginVerse && j.EndVerse <= endVerse));
                }
            }
            else
            {
                q = q.Where(j => j.Chapter == 0);
            }

            return q.Include(j => j.Book)
                .ToList();
        }

        public JournalEntry AddJournalEntry(JournalEntry journalEntry)
        {
            context.JournalEntries.Add(journalEntry);
            context.SaveChanges();

            return journalEntry;
        }

        public List<Book> GetAllBooks()
        {
            return context.Books.OrderBy(b => b.BookId).ToList();
        }

        public List<EntryType> GetAllEntryTypes()
        {
            return context.EntryTypes.OrderBy(e => e.EntryTypeId).ToList();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).

                    context.Dispose();

                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FygHelper()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
