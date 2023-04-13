namespace Kohde.Assessment
{
    public class Dog: Mammal, IFood
    {
        public Dog() { }
        public Dog(int age, string name, string food) : base(age, name)
        {
            Food = food;
        }

        public string Food { get; set; }
    }
}