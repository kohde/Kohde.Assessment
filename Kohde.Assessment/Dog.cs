using System;

namespace Kohde.Assessment
{
    public class Dog : MammalBase, IDisposable, IPet
    {
        public Dog() { }
        public Dog(string food, string name, int age) {
            Food = food;
            Name = name;
            Age = age;
        }
        public string Food { get; set; }

        private bool isDisposed = false;

        //If you want all mammals to be Disposable, the base class should implement the IDisposable interface.
        public void Dispose()
        {
            //check if the dispose method has been called already
            //the dispose method must be idempotent to ensure that resources are always cleaned up effectively.
            if (!isDisposed )
            {
                //code to dispose resources would go here.
                Console.WriteLine("Disposing Dog resources...");
            }
        }
    }
}