namespace Kohde.Assessment
{
    public class Cat : Mammals
    {
        public string Food { get; set; }
        public override string GetDetails()
        {
            return base.ToString();
        }
        public override string ToString()
        {
            return $"{GetDetails()}, Food: {Food}";
        }
    }
}