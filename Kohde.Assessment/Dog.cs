namespace Kohde.Assessment
{
    public class Dog : Mammal
    {
        public string Food { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Food: {Food}";
        }
    }
}