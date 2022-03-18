using Microsoft.Win32.SafeHandles;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Kohde.Assessment.Implementations
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        #region Private Methods

        private bool _disposed;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        #endregion

        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation()
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                SomethingHappened += HandleSomethingHappened;
            }
        }

        public void RaiseEvent(string data)
        {
            if (SomethingHappened != null)
            {
                SomethingHappened(data);
            }
        }

        private void HandleSomethingHappened(string foo)
        {
            Counter += 1;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing = false)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _safeHandle.Dispose();
                SomethingHappened = null;
                Counter = 1;
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(true);
        }
    }
}