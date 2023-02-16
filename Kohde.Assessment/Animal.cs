namespace Kohde.Assessment
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected Animal(string name, int age)
        {
            Age = age;
            Name = name;
        }

        protected Animal()
        {

        }

        public abstract string GetDetails();

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
