using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {

        public event MyEventHandler SomethingHappened;
        public int Counter { get; private set; }
        bool isDisposed = false;
        public void PerformSomeLongRunningOperation()
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                //bcodendaal:
                //My inclination is that the += operator is not the most efficient.
                //I am however not sure how to improve this performance without using 
                //something like a List<MyEventHandler>();

                this.SomethingHappened += HandleSomethingHappened;
            }
        }

        public void RaiseEvent(string data)
        {
            if (SomethingHappened != null)
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
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Dispose managed resourcesc
                    Counter = 1;
                    //the default for a reference type is Null. You can also use (default) here.
                    SomethingHappened = null;
                }
                // Free native resources
                isDisposed = true;
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