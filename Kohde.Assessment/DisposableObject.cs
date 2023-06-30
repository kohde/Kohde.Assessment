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
        }

        public void RaiseEvent(string data)
        {
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
                SomethingHappened = default;
            }

            // Free native resources
            Counter = 1;
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