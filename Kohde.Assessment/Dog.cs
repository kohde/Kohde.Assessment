using System;

namespace Kohde.Assessment
{
    public class Dog : INameAge, IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }

        public Dog(string name, int age, string food)
        {
            Name = name;
            Age = age;
            Food = food;
        }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Dog() { }

        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        public void Dispose() { }
    }
}