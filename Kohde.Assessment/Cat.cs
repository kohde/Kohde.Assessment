using System.Xml.Linq;

namespace Kohde.Assessment
{
    /// <summary>
    /// Cat now inherits from Organism instead of duplicating Name and Age.
    /// Fixed original bug where Food was not included in GetDetails()
    /// and added better formatting.
    /// </summary>
    public class Cat : Organism
    {
        public string Food { get; set; }

        public override string GetDetails()
        {
            return $"Cat - Name: {Name}, Age: {Age}, Food: {Food}";
        }
    }
}