using System;
using System.Linq;

namespace Kohde.Assessment {
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation() {
            foreach (var i in Enumerable.Range(1, 10)) {
                this.SomethingHappened += HandleSomethingHappened;
            }
        }

        public void RaiseEvent(string data) {
            if (this.SomethingHappened != null) {
                this.SomethingHappened(data);
            }
        }

        private void HandleSomethingHappened(string foo) {
            this.Counter++;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                // Dispose managed resources
                if (this.SomethingHappened != null) {

                    this.SomethingHappened -= HandleSomethingHappened;

                }
            }
            // Free native resources            
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject() {
            Dispose(false);
        }
    }
}