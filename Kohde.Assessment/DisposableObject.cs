using System;
using System.Linq;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation()
        {
            SomethingHappened += HandleSomethingHappened;

            SomethingHappened?.Invoke("performing long operation");

        }

        public void RaiseEvent(string data)
        {
            SomethingHappened?.Invoke(data);
        }

        private void HandleSomethingHappened(string foo)
        {
            this.Counter = this.Counter + 1;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Unsubscribe all event handlers
                if (SomethingHappened != null)
                {
                    foreach (var d in SomethingHappened.GetInvocationList())
                    {
                        SomethingHappened -= (MyEventHandler)d;
                    }
                }
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