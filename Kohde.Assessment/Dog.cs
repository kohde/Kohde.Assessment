using System;

namespace Kohde.Assessment
{
    public class Dog: Animal
    {
        public string Food { get; protected set; }

        public Dog(string name, int age, string food): base(name, age)
        {
            this.Food = food ?? throw new ArgumentNullException(nameof(food));
        }

        public Dog()
        {
            
        }

        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}