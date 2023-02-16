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

        public string GetDetails()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}
