using System;

namespace Kohde.Assessment.Objects.Classes
{
    public class Dog : Animal, IDisposable
    {
        public Dog() { }

        public Dog(int age, string food, string name) : base(age, food, name)
        { }

        public void Dispose()
        {
            Console.WriteLine("Disposing in action...");
        }
    }
}