using System;

namespace Kohde.Assessment
{
    public class Cat: Animal
    {
        public string Food { get; protected set; }

        public Cat(string name, int age, string food): base(name, age)
        {
            this.Food = food ?? throw new ArgumentNullException(nameof(food));
        }

        public Cat()
        {
            
        }

        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}