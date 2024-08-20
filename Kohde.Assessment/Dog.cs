namespace Kohde.Assessment
{
    public class Dog: Mammal
    { 
        public string Food { get; set; }

		public Dog(string name, int age, string food): base(name, age)
		{
			Food = food;
		}

		public Dog() { }

		public override string ToString()
		{
			return GetDetails() + " Food: " + Food;
		}
	}
}