using System;
using System.CodeDom;

namespace Kohde.Assessment
{
    public class Human: Animal
    {
        public string Gender { get; protected set; }

        public Human(string name, int age, string gender): base(name, age)
        {
            this.Gender = gender ?? throw new ArgumentNullException(nameof(gender));
        }

        public Human()
        {
            
        }

        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}