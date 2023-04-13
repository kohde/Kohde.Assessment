namespace Kohde.Assessment
{
    public class Cat : Mammal, IFood
    {
        public Cat() { }
        public Cat(int age, string name, string food) : base(age, name)
        {
            Food = food;
        }
        public string Food { get; set; }
    }
}