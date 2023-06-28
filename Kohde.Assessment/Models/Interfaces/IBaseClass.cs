namespace Kohde.Assessment.Models.Interfaces
{
    public interface IBaseClass
    {
        string Name { get; set; }
        int Age { get; set; }
        string GetDetails();
    }
}