namespace Kohde.Assessment
{
    public class Cat : Animal
    {
        public string Food { get; set; }

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