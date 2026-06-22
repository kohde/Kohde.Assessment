namespace Kohde.Assessment
{
    public class Human: Animal
    {
        public string Gender { get; set; }

        public override string ToString()
        {
            return GetDetails();
        }
    }
}