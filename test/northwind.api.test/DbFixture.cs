using System;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.Models;


namespace Northwind.Api.Test
{
    public class DbFixture : IDisposable
    {
        public DbFixture()
        {
            var builder = new DbContextOptionsBuilder<NorthwindContext>();

            builder.UseSqlServer("Server=localhost;Database=Northwind;User Id=sa;Password=Today123!;MultipleActiveResultSets=True");
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
