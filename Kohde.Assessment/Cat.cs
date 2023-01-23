namespace Kohde.Assessment
{
  // made the class inherent from the new base class
  // for less and cleaner code
  public class Cat : Mammal.Mammal
  {
    public string Food { get; set; }

    // created default constructor
    public Cat()
    {
        
    }

    // created another constructor for easier and cleaner declarations
    public Cat(string name, int age, string food = null) : base(name, age)
    {
      Name = name;
      Age = age;
      Food = food;
    }

    // made the method override the base classes' one
    // to include the new property that is not in the base class
    public override string GetDetails()
    {
      return $"Name: {Name} Age: {Age} Food: {Food}";
    }

    // override the ToString method to make it more meaningful
    public override string ToString()
    {
      return GetDetails();
    }
  }
}