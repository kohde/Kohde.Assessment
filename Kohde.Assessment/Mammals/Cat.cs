namespace Kohde.Assessment.Mammals
{
    public class Cat : Animal
    {
        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}