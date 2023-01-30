namespace Kohde.Assessment
{
    public class Human : Mammals
    {
        public string Gender { get; set; }
        public override string GetDetails()
        {
            return base.ToString();
        }
        public override string ToString()
        {
            return $"{GetDetails()}, Gender: {Gender}";
        }
    }
}