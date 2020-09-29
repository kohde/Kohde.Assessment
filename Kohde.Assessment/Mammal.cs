namespace Kohde.Assessment
{
    public abstract class Mammal : IMammal
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public string GetDetails() =>  "Name: " + Name + "Age: " + Age;

        public abstract override string ToString();
    }
}