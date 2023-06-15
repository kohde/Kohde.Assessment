using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        private const int HandlerCount = 10;

        public async Task PerformSomeLongRunningOperationAsync()
        {
            foreach (var i in Enumerable.Range(1, HandlerCount))
            {
                this.SomethingHappened += HandleSomethingHappened;
            }

            await Task.CompletedTask;
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
                this.Counter = 1;
                //you should not need to unsubscribe from each handler, since the handler and subscribers are in
                //the same class, so there will no longer be any references, opposed to outside classes subscribing on the handler.
                foreach (var i in Enumerable.Range(1, HandlerCount))
                {
                    this.SomethingHappened -= HandleSomethingHappened;
                }

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