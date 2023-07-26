namespace Kohde.Assessment
{
    public class MammalBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string GetDetails()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }
}
