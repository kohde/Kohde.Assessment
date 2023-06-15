namespace Kohde.Assessment.Mammals
{
    public abstract class Mammal : IDetailsProvider
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public abstract string GetDetails();

        public override string ToString()
        {
            return Name + ": " + Age;
        }
    }
}