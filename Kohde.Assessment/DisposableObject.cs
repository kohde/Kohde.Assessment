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

        //variable to check if Dispose was already called
        public bool disposed = false;

        public void PerformSomeLongRunningOperation()
        {
            //Call the HandleSomethingHappened once as there is no reason to call it 10 times
            //If you want to call it 10 times and still clear the counter, see my comment in the dispose method
            this.SomethingHappened += HandleSomethingHappened;

            //perform an actual long running event if you want to
            //foreach (var i in Enumerable.Range(1, 10))
            //{                
            //    Thread.Sleep(100);
            //}
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
            //Just nit picking, changes nothing functional
            this.Counter++;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing)
        {
            //Add a check to see if Dispose has already been called.
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    // Clear the SomethingHappened event when the object is disposed
                    this.SomethingHappened = null;

                    //this.Counter = 0; -> this can be called here if you want to clear the counter, but then the test will fail as counter = 0, instead of 1
                    //I have no idea why you want to keep the counters value or set it to 1 when you dispose the object
                }

                //Set disposed to true
                disposed = true;
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