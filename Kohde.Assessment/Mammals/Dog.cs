using System;

namespace Kohde.Assessment.Mammals
{
    public class Dog : Animal, IDisposable
    {
        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        public void Dispose()
        {
            Console.WriteLine("I am going to the farm");
        }
    }
}