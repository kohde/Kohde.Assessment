namespace Kohde.Assessment.Objects.Interfaces
{
    public interface IEntity
    {
        int Age { get; set; }
        string Name { get; set; }

        string GetDetails();
    }
}