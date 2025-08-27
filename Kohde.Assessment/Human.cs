namespace Kohde.Assessment
{
	//Human implements Mammal abstract class so removed duplicate properties and methods
	public class Human : Mammal
    {
        public string Gender { get; set; }

		// added override ToString method to display human details
		public override string ToString()
        {
            return $"Human Name: {Name} Age: {Age} Gender: {Gender}";
        }
    }
}