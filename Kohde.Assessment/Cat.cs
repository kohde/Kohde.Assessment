using System.Xml.Linq;

namespace Kohde.Assessment
{
    public class Cat: Mammal
    {
		public string Food { get; set; }

		public Cat(string name, int age, string food): base(name, age)
		{
			Food = food;
		}

		public Cat() { }

		public override string ToString()
		{
			return GetDetails() + " Food: " + Food;
		}
	}
}