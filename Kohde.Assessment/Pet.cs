namespace Kohde.Assessment
{
    //Pet is a Mammal that has a food property
    //This is an abstract class as we will never have an instance of Pet that is not a specific type of animal
    //Here we can add all properties and methods common to all animals
    public abstract class Pet : Mammal
    {
        public string Food { get; set; }
        public Pet(string name, int age, string food) : base(name, age)
        {
            Food = food;
        }
        public Pet() : base()
        {
        }
    }
}