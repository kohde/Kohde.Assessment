namespace Kohde.Assessment
{
    public class Human : Animal
    {
        public string Gender { get; set; }

        public override string GetDetails()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            return $"{GetDetails()}, {nameof(Gender)}: {Gender}";
        }
    }
}