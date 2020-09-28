namespace Kohde.Assessment
{
    public interface INameableAgeable
    {
        int Age { get; set; }
        string Name { get; set; }

        string GetDetails();
        string ToString();
    }
}