namespace Kohde.Assessment
{
    public class Cat : Animal
    {
        public string Food { get; set; }

        public Cat(string name, int age, string food) : base(name, age)
        {
            Food = food;
        }

        public Cat()
        {

        }

        public override string ToString()
        {
            return $"{GetDetails()}, {nameof(Food)}: {Food}";
        }
    }
}