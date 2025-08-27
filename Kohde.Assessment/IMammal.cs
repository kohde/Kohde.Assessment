namespace Kohde.Assessment
{
	//interface for Mammal classes to define common properties and methods
	public interface IMammal
	{
		string Name { get; set; }
		int Age { get; set; }

		string GetDetails();
	}
}