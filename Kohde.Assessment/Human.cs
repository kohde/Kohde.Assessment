namespace Kohde.Assessment
{
    public class Human : Mammal
    {
        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age + " Gender: " + Gender;
        }
    }
}