using System.Xml.Linq;

namespace Kohde.Assessment
{
    /// <summary>
    /// Dog now inherits from Organism and only defines what is unique (Food).
    /// </summary>
    public class Dog : Organism
    {
        public string Food { get; set; }

        public override string GetDetails()
        {
            return $"Dog - Name: {Name}, Age: {Age}, Food: {Food}";
        }
    }
}