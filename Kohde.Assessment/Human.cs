namespace Kohde.Assessment
{
    public class Human : Mammal
    {
        public string Gender { get; set; }

        public override string GetDetails()
        {
            return $"{base.GetDetails()} Gender: {Gender}";
            
        }
        public override string ToString()
        {
            return GetDetails();
        }
    }
}