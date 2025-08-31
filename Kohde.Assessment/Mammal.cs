namespace Kohde.Assessment
{
    //Since There many similar creatures that have a name and age, we create a base class for them
    //This abstract class contains the common properties and methods
    //We can now add all simiar properties and methods here
    public abstract class Mammal: DisposableObject, IMammal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Mammal()
        {
        }
        public Mammal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string GetDetails()
        {
            return $"Name: {Name}, Age: {Age}";
        }
        public override string ToString()
        {
            return GetDetails();
        }
    }
}