﻿namespace Kohde.Assessment
{
    public class Cat:Mammal
    {
        //initially added contructors for the classes but decided againt it
        //when it broke some of the other methods provided with the solution
        //Also implemented the override string for each class
        /*        public Cat(string name, int age, string food)
                {
                    Name = name;
                    Age = age;
                    Food = food;
                }*/
        public override string ToString() { return "Name: " + Name + " Age: " + Age; }
    }
}