using Microsoft.Extensions.Logging;
using System;

namespace Kachok.Infrastructure.Logging
{
    public class RequestLoggerProvider : ILoggerProvider
    {


        public RequestLoggerProvider(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            //if (categoryName.StartsWith("Kachok"))
            //{
                return new RequestLogger(categoryName, _serviceProvider);
            //}
            //else
            //{
            //    return new NullLogger();
            //}
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private IServiceProvider _serviceProvider;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DBLoggerProvider() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
