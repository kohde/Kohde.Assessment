namespace Kohde.Assessment
{
    public interface IMammalDetails
    {
        string Name { get; set; }
        int Age { get; set; }
        string GetDetails();
    }
}
