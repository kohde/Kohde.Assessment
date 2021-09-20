namespace Kohde.Assessment
{
    public class Dog : Mammal
    {
        public override string GetDetails()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }
}