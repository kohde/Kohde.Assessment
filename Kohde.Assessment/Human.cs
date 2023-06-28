using Kohde.Assessment.Models;

namespace Kohde.Assessment
{
    public class Human : BaseClass
    {
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age}";
        }
    }
}