using System.Collections.Generic;

namespace Kohde.Assessment
{
    public class Human : Sapien
    {               

        //Empty contructor not required, but usually good practice
        public Human() { }

        //Human constructer to create Human object
        public Human(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        //Overriding abstract method getDetails with own implementation
        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        //Default equals method to check object equality
        public override bool Equals(object obj)
        {
            return obj is Human human &&
                   Name == human.Name &&
                   Age == human.Age &&
                   Gender == human.Gender;
        }

        //Default ToString method
        public override string ToString()
        {
            return base.ToString();
        }

        //Default getHashcode method 
        public override int GetHashCode()
        {
            int hashCode = -1497452382;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Gender);
            return hashCode;
        }
    }
}