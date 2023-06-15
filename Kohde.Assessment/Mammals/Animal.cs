namespace Kohde.Assessment.Mammals
{
    public abstract class Animal : Mammal
    {
        public string Food { get; set; }

        public override string ToString()
        {
            return base.ToString() + ": " + Food;
        }
    }
}