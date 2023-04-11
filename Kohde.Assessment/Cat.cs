using System.Collections.Generic;

namespace Kohde.Assessment
{
    public class Cat : Mammal
    {
        //private food property
        private string food;
        
        //public food getter and setter to access private property
        public string Food
        {
            get => food;
            set => food = value;
        }

        //Empty contructor not required, but usually good practice
        public Cat() { }

        //Cat constructer to create Cat object
        public Cat(string name, int age, string food)
        {
            Name = name;
            Age = age;
            this.food = food;
        }

        //Overriding abstract method getDetails with own implementation if you would like
        //public override string GetDetails()
        //{
        //    return base.GetDetails() + ", Food: " + food;
        //}

        //Default ToString method
        public override string ToString()
        {
            return base.ToString();
        }

        //usually equals and hascode methods are added for equality test, but not required

    }
}