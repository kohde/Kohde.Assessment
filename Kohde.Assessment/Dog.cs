namespace Kohde.Assessment
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }

        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}