﻿using System;
using System.Linq;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        //Subscribe the event handler once only.
        //Also check if it has already been subscribed before attempting to subscribe.
        public void PerformSomeLongRunningOperation()
        {
            MyEventHandler handler = HandleSomethingHappened;

            if (this.SomethingHappened == null)
            {
                this.SomethingHappened += handler;

                for (int i = 1; i <= 9; i++)
                {
                    this.SomethingHappened += handler;
                }
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
            if (disposing)
            {
                if (this.SomethingHappened != null)
                {
                    foreach (var handler in this.SomethingHappened.GetInvocationList())
                    {
                        this.SomethingHappened -= (MyEventHandler)handler;
                    }
                }

                // Dispose managed resources
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