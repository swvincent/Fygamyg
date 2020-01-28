using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using fygdb.models;
using Microsoft.EntityFrameworkCore;

namespace fygdb
{
    public class EntryTypeHelper : IDisposable
    {
        private readonly FygContext context;

        public EntryTypeHelper()
        {
            context = new FygContext();
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
