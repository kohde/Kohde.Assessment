namespace Kohde.Assessment.Mammal
{
  // created a base class for similar type of classes to inherit
  // from + made the base class inherit from an interface to set
  // requirements
  public abstract class Mammal : IMammal
  {
    public string Name { get; set; }
    public int Age { get; set; }

    // created default constructor
    public Mammal()
    {

    }

    // created another constructor for easier and cleaner declarations
    protected Mammal(string name, int age)
    {
      Name = name;
      Age = age;
    }

    // made the method virtual so it can be overridden
    // by derived classes
    public abstract string GetDetails();
  }
}