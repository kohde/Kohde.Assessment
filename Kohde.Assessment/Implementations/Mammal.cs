using Kohde.Assessment.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Kohde.Assessment.Implementations
{
    public abstract class Mammal : IMammal, IDisposable
    {
        #region Private Methods

        private bool _disposed;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        #endregion

        #region Abstract Properties       

        public abstract string Name { get; set; }

        public abstract int Age { get; set; }

        #endregion

        #region Abstract Methods

        public abstract string GetDetails();

        #endregion

        #region Disposable Methods

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing = false)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _safeHandle.Dispose();
            }

            _disposed = true;
        } 

        #endregion
    }
}