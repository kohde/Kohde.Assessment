namespace Kohde.Assessment
{
    public class Cat : MammalBase, IPet
    {
        public Cat() { }
        public Cat(string food, string name, int age)
        {
            Food = food;
            Name = name;
            Age = age;
        }
        public string Food { get; set; }
    }
}