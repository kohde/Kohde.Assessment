using System.Collections.Generic;

namespace Kohde.Assessment
{
    public class Human : Mammal
    {
        //private gender property
        private string gender;

        //public gender getter and setter to access private property
        public string Gender { 
            get => gender;
            set => gender = value;
        }

        //Empty contructor not required, but usually good practice
        public Human() { }

        //Human constructer to create Human object
        public Human(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            this.gender = gender;
        }

        //Overriding abstract method getDetails with own implementation if you would like
        //public override string GetDetails()
        //{
        //    return base.GetDetails() + ", Gender: " + gender;
        //}


        //Default ToString method
        public override string ToString()
        {
            return base.ToString();
        }

        //usually equals and hascode methods are added for equality test, but not required
    }
}