using System;
using System.Xml.Linq;
using Kohde.Assessment.AssessmentA;

namespace Kohde.Assessment
{
  // We inherit from a base class Mammal(IMammal)
  // and then for the gender I used IMammalGender to specify the contract for the Gender property (generally I would only do this if there were going to be more than one property)
  public class Human : Mammal
  {
    // I am leaving this as a string for simplicity and for the unit tests but we would probably want to change this to a enum
    public string Gender { get; set; }

    // Using the constructor to set the parameters and do some validations
    // (we could go into creating the class through factories but ive chosen this method for this)

    // default constructor
    public Human()
    {
      this.Name = "";
      this.Age = 0;
      this.Gender = "";
    }

    public Human(string pName, int pAge, string pGender)
    {
      // Ensure the object we are creating is valid with some checks 
      if (string.IsNullOrEmpty(pName))
        throw new ArgumentException("The Name must be specified", nameof(pName));

      if (pAge <= 0)
        throw new ArgumentException("The age is invalid", nameof(pAge));

      if (string.IsNullOrEmpty(pGender))
        throw new ArgumentException("The gender must be specified", nameof(pGender));

      if (!string.Equals(pGender, "F", StringComparison.OrdinalIgnoreCase) && !string.Equals(pGender, "M", StringComparison.OrdinalIgnoreCase))
        throw new ArgumentException("The gender is invalid", nameof(pGender));

      this.Name = pName;
      this.Age = pAge;
      this.Gender = pGender;
    }

    // Override the abstract method from the mammal base class
    public override string GetDetails()
    {
      return $"Name: {Name}, Age: {Age}, Gender: {Gender}";
    }

    // override the ToString method to pass 'TestA3'
    public override string ToString()
    {
      return GetDetails();
    }

  }
}