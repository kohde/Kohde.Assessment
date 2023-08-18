namespace Kohde.Assessment.Objects.Classes
{
    public abstract class Animal : Entity
    {
        public string Food { get; set; }

        public Animal(int age, string food, string name) : base(age, name)
        {
            Food = food;
        }

        public Animal() { }

        public override string ToString()
        {
            return $"{base.GetDetails()} Food: {Food}";
        }
    }
}