namespace Kohde.Assessment
{
  // made the class inherent from the new base class
  // for less and cleaner code
  public class Human : Mammal.Mammal
  {
    public string Gender { get; set; }

    // created default constructor
    public Human()
    {

    }

    // created another constructor for easier and cleaner declarations
    public Human(string name, int age, string gender = null) : base(name, age)
    {
      Name = name;
      Age = age;
      Gender = gender;
    }

    // made the method override the base classes' one
    // to include the new property that is not in the base class
    public override string GetDetails()
    {
      return $"Name: {Name}, Age: {Age}, Gender: {Gender}";
    }

    // override the ToString method to make it more meaningful
    public override string ToString()
    {
      return GetDetails();
    }
  }
}