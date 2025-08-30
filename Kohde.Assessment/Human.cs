using System.Xml.Linq;

namespace Kohde.Assessment
{
    /// <summary>
    /// Human now inherits from Organism instead of repeating Name and Age.
    /// Added Gender as a unique property for Human.
    /// </summary>
    public class Human : Organism
    {
        public string Gender { get; set; }

        public override string GetDetails()
        {
            return $"Human - Name: {Name}, Age: {Age}, Gender: {Gender}";
        }

        //override ToString() since GetMethod("ToString") returns the ToString() method declared in the nearest ancestor (on UnitTest).
        public override string ToString()
        {
            return GetDetails();
        }
    }
}