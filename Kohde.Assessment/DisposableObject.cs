using System;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        private bool disposed = false;

        public void PerformSomeLongRunningOperation()
        {
            SomethingHappened += HandleSomethingHappened;
        }

        public void RaiseEvent(string data)
        {
            if (this.SomethingHappened != null)
            {
                SomethingHappened.Invoke(data);
            }
        }

        private void HandleSomethingHappened(string foo)
        {
            Counter++;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    if (SomethingHappened != null)
                    {
                        foreach (var handler in SomethingHappened.GetInvocationList())
                        {
                            SomethingHappened -= (MyEventHandler)handler;
                        }
                    }
                }
                // Free native resources
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }
    }
}