using System;
using System.Linq;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;
        private bool disposed = false;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation()
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                this.SomethingHappened += HandleSomethingHappened;
            }
        }

        public void RaiseEvent(string data)
        {
            if (this.SomethingHappened != null)
            {
                this.SomethingHappened(data);
            }
        }

        private void HandleSomethingHappened(string foo)
        {
            this.Counter = this.Counter + 1;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) // Check if event hasnt been desposed yet
            {
                if (disposing)
                {
                    // Dispose managed resources
                    if (this.SomethingHappened != null)
                    {
                        foreach (var eventHandler in this.SomethingHappened.GetInvocationList())
                        {
                            this.SomethingHappened -= (MyEventHandler)eventHandler; // Remove each event at a time from the SomethingHappend event
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