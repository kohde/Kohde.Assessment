using System;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation()
        {
            //the issue here is that each call subscribed the same handler multiple times (10x in the loop)
            //which caused the event to fire repeatedly for no reason leads to memory leak risk
            //The fix to this is to ensure handler is only subscribed once.

            //foreach (var i in Enumerable.Range(1, 10))
            //{
            //    this.SomethingHappened += HandleSomethingHappened;
            //}

            this.SomethingHappened -= HandleSomethingHappened; // remove if already attached
            this.SomethingHappened += HandleSomethingHappened; // attach once
        }

        public void RaiseEvent(string data)
        {
            // the issue here is `if (SomethingHappened != null)` is not thread-safe.
            // another thread could unsubscribe between the null check and the invocation.
            // The fix to this is to use null-conditional invoke, wich is thread-safe in this problem

            //if (this.SomethingHappened != null)
            //{
            //    this.SomethingHappened(data);
            //}

            SomethingHappened?.Invoke(data);
        }

        private void HandleSomethingHappened(string foo)
        {
            Counter++;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", Counter, foo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
                // Unsubscribe event handler on dispose to avoid memory leaks
                SomethingHappened -= HandleSomethingHappened;

                // set the event to null when disposing as this ensures no subscribers remain
                SomethingHappened = null;
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