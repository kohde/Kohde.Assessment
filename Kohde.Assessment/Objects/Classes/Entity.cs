using Kohde.Assessment.Objects.Interfaces;

namespace Kohde.Assessment.Objects.Classes
{
    public abstract class Entity : IEntity
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Entity() { }

        protected Entity(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public virtual string GetDetails()
        {
            return $"Name: {Name} Age: {Age}";
        }
    }
}