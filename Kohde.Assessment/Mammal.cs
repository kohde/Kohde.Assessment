using System.Xml.Linq;

namespace Kohde.Assessment
{
    public interface IMammal
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    public interface IGender
    {
        string Gender { get; set; }
    }

    public interface IFood
    {
        string Food { get; set; }
    }

    public abstract class Mammal: IMammal
    {
        protected Mammal() { }

        protected Mammal(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; set; }
        public string Name { get; set; }
       
        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }

}