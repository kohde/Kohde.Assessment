using Kohde.Assessment.Models.Interfaces;

namespace Kohde.Assessment.Models
{
    public abstract class BaseClass : IBaseClass
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Darren Potts: I am unsure about if GetDetails is required as ToString
        // can be used but Cat and Dog require it in the tests
        public string GetDetails()
        {
            return $"Name: {Name} Age: {Age}";
        }
    }
}