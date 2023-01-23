namespace Kohde.Assessment.Mammal
{
  // created a base class for similar type of classes to inherit
  // from + made the base class inherit from an interface to set
  // requirements
  public abstract class Mammal : IMammal
  {
    public string Name { get; set; }
    public int Age { get; set; }

    protected Mammal(string name, int age)
    {
      Name = name;
      Age = age;
    }

    public abstract string GetDetails();
  }
}
