namespace Kohde.Assessment.Mammals
{
    public class Human : Mammal
    {
        public string Gender { get; set; }

        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        public override string ToString()
        {
            return base.ToString() + ": " + Gender;
        }
    }
}