namespace Kohde.Assessment
{
    public class Dog : Entity
    {
        public string Food { get; set; }

        //public Dog(string name, int age, string food) : base (name, age)
        //{
        //    Food = food;
        //}
        public override string GetDetails()
        {
            return base.GetDetails() + $" Food: {Food}";
        }
    }
}