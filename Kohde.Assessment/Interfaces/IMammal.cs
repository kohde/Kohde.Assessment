namespace Kohde.Assessment.Interfaces
{
    public interface IMammal
    {
        string Name { get; set; }

        int Age { get; set; }

        string GetDetails();
    }
}