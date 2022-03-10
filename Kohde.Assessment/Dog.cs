using System;

namespace Kohde.Assessment
{
    //implemented Disposable interface
    public class Dog : Mammal,IDisposable
    {
        public string Food { get; set; }

        public void Dispose()
        {
            Food = null;
        }
    }
}