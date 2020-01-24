namespace Kohde.Assessment
{
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}