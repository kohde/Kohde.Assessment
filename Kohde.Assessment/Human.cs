using Kohde.Assessment;

namespace Kohde.Assessment
{
    public class Human : Mammal
    {
        public string Gender { get; set; }

        public override string ToString()
        {
            return base.GetDetails();
        }
    }
}