using System.Collections.Generic;

namespace Kohde.Assessment
{
    public class Dog : Animal
    {
        
        //Empty contructor not required, but usually good practice
        public Dog() { }

        //Dog constructer to create Dog object
        public Dog(string name, int age, string food)
        {
            Name = name;
            Age = age;
            Food = food;
        }

        //Overriding abstract method getDetails with own implementation
        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        //Default ToString method
        public override string ToString()
        {
            return base.ToString();
        }

        //Default Equals method
        public override bool Equals(object obj)
        {
            return obj is Dog dog &&
                   Name == dog.Name &&
                   Age == dog.Age &&
                   Food == dog.Food;
        }

        //Default GetHashCode method
        public override int GetHashCode()
        {
            int hashCode = -1123064597;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Food);
            return hashCode;
        }
    }
}