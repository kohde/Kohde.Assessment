using System;
using System.Linq;
using System.Threading;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation()
        {
            // Im not sure why you would create multiple events like this so we are going to just skip hooking up the event again every time
            foreach (var i in Enumerable.Range(1, 10))
            {
                if (this.SomethingHappened != null)
                  continue;

                this.SomethingHappened += HandleSomethingHappened;
            }

            // Probably wanted to do just this:
            // Thread.Sleep(3000); // long operation
            // this.SomethingHappened += HandleSomethingHappened;
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
            if (disposing)
            {
                // Dispose managed resources
                this.SomethingHappened = null;
            }

            // Free native resources
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