namespace Kohde.Assessment
{
    public class Cat : Entity
    {
        public string Food { get; set; }

        //public Cat(string name, int age, string food) : base (name, age)
        //{
        //    Food = food;
        //}

        public override string GetDetails()
        {
            return base.GetDetails() + $" Food: {Food}";
        }
    }
}