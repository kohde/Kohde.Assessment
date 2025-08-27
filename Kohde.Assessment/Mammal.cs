namespace Kohde.Assessment
{
	//Mammal inherets from IMammal interface
	//abstract class so that no objects of type Mammal are created
	public abstract class Mammal : IMammal
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public string GetDetails()
		{
			//changed it to use string interpolation
			return $"Name: {Name} Age: {Age}";
		}
	}
}