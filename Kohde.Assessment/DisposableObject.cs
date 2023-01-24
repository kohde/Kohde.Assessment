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
      SomethingHappened += HandleSomethingHappened;
    }

    public void RaiseEvent(string data)
    {
      if (SomethingHappened != null)
      {
        SomethingHappened(data);
      }
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
        SomethingHappened -= HandleSomethingHappened;
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