using System.Collections.Generic;

namespace Kohde.Assessment
{
    public class Human : Mammal
    {
        private string name;
        private int age;
        private string gender;
        public override string Name { get; set; }

        public override int Age { get; set; }
        public string Gender { get; set; }

        //Empty contructor not required, but usually good practice
        public Human() { }

        //Human constructer to create Human object
        public Human(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        //Overriding abstract method getDetails with own implementation
        public override string GetDetails()
        {
            return "Name: " + name + "Age: " + age;
        }

        //Default equals method to check object equality
        public override bool Equals(object obj)
        {
            return obj is Human human &&
                   name == human.Name &&
                   age == human.Age &&
                   gender == human.Gender;
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
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(gender);
            return hashCode;
        }


    }
}