namespace Kohde.Assessment
{
    public abstract class Mammals : IMammalDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract string GetDetails();
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
