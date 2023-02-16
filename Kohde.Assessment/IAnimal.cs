namespace Kohde.Assessment
{
    public interface IAnimal
    {
        string Name { get; set; }
        int Age { get; set; }

        string GetDetails();
    }
}
