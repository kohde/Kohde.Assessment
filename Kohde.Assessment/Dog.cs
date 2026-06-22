namespace Kohde.Assessment
{
    public class Dog: Animal
    {
        public string Food { get; set; }

        public override string ToString()
        {
            return GetDetails();
        }
    }
}