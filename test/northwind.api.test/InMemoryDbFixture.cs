using System;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.Models;

namespace Northwind.Api.Test
{
    public class InMemoryDbFixture : IDisposable
    {
        public InMemoryDbFixture()
        {
            var builder = new DbContextOptionsBuilder<NorthwindContext>();

            builder.UseInMemoryDatabase("NorthwindContext");
            DbContext = new NorthwindContext(builder.Options);
        }

        public NorthwindContext DbContext { get; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing) {
                    DbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
