namespace Kohde.Assessment
{
    public class Cat : INameAge
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }

        public Cat(string name, int age, string food)
        {
            Name = name;
            Age = age;
            Food = food;
        }

        public Cat() { }

        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}