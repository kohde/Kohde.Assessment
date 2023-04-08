﻿using System.Collections.Generic;

namespace Kohde.Assessment
{
    public class Cat : Mammal//Animal
    {
        private string name;
        private int age;
        private string food;
        public override string Name { get; set; }
        public override int Age { get; set; }
        public string Food { get; set; }


        //Empty contructor not required, but usually good practice
        public Cat() { }

        //Cat constructer to create Cat object
        public Cat(string name, int age, string food)
        {
            this.name = name;
            this.age = age;
            this.food = food;
        }



        //Overriding abstract method getDetails with own implementation
        public override string GetDetails()
        {
            return "Name: " + name + "Age: " + age;
        }

        //Default ToString method
        public override string ToString()
        {
            return base.ToString();
        }

        //Default Equals method
        public override bool Equals(object obj)
        {
            return obj is Cat cat && name == cat.Name && age == cat.Age && food == cat.Food;
        }

        //Default GetHashCode method
        public override int GetHashCode()
        {
            int hashCode = -1123064597;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(food);
            return hashCode;
        }
    }
}