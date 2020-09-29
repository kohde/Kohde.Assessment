namespace Kohde.Assessment
{
    public interface IMammal
    {
        int Age { get; set; }
        string Name { get; set; }

        string GetDetails();
        string ToString();
    }
}