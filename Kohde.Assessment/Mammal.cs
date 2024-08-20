namespace Kohde.Assessment
{
	//Created an abstract class animal from which specific animals can inherit from
	public abstract class Mammal: IDetail
	{
		//Properties and methods not abstact so that child classes can use them
		public string Name { get; set; }
		public int Age { get; set; }

		public Mammal(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public Mammal() { }
	
		public string GetDetails()
		{
			return "Name: " + Name + " Age: " + Age;
		}
	}
}
