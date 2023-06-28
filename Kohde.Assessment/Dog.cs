using Kohde.Assessment.Models;

namespace Kohde.Assessment
{
    public class Dog : BaseClass
    {
        public string Food { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age}";
        }
    }
}