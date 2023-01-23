﻿using System;

namespace Kohde.Assessment
{
  public delegate void MyEventHandler(string foo);

  public class DisposableObject : IDisposable
  {
    public event MyEventHandler SomethingHappened;

    public int Counter { get; private set; }

    public void PerformSomeLongRunningOperation()
    {
      this.SomethingHappened += HandleSomethingHappened;
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
        this.SomethingHappened -= HandleSomethingHappened;
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