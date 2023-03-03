
namespace Kohde.Assessment
{
    public abstract class Mammal : IMammalBase
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }

        public virtual string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

    }
}
