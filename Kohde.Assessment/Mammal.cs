namespace Kohde.Assessment
{
    public abstract class Mammal : IEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual string GetDetails()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}