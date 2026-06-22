namespace Kohde.Assessment
{
    public class Cat: Animal
    {
        public string Food { get; set; }

        public override string ToString()
        {
            return GetDetails();
        }
    }
}