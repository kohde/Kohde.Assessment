namespace Kohde.Assessment
{
    public class Dog : Animal
    {
        public string Food { get; set; }

        public Dog(string name, int age, string food) : base(name, age)
        {
            Food = food;
        }

        public Dog()
        {
        }

        public override string GetDetails()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            return $"{GetDetails()}, {nameof(Food)}: {Food}";
        }
    }
}