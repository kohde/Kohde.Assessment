using System;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Xml.Linq;
using Kohde.Assessment.AssessmentA;

namespace Kohde.Assessment
{
  // We inherit from a base class Mammal(IMammal)
  // and then for the Food property I used IMammalFood for the contract (in this case its overkill but there for example completeness)
  public class Dog : Mammal, IMammalFood, IDisposable
  {
    // To detect redundant calls
    private bool mDisposedValue;

    public string Food { get; set; }

    // default constructor
    public Dog()
    {
      this.Name = "";
      this.Age = 0;
      this.Food = "";
    }

    // Using the constructor to set the parameters and do some validations
    public Dog(string pName, int pAge, string pFood)
    {
      // Ensure the object we are creating is valid with some checks 
      if (string.IsNullOrEmpty(pName))
        throw new ArgumentException("The Name must be specified", nameof(pName));

      if (pAge <= 0)
        throw new ArgumentException("The age is invalid", nameof(pAge));

      if (string.IsNullOrEmpty(pFood))
        throw new ArgumentException("The Food must be specified", nameof(pFood));

      this.Name = pName;
      this.Age = pAge;
      this.Food = pFood;
    }

    // Override the abstract method from the mammal base class
    public override string GetDetails()
    {
      return $"Name: {Name}, Age: {Age}, Food: {Food}";
    }








    // Public implementation of Dispose pattern
    public void Dispose()
    {
      Dispose(true);
    }

    // Protected implementation of Dispose pattern
    protected virtual void Dispose(bool pDisposing)
    {
      // Check to see if Dispose has already been called
      if (!mDisposedValue)
      {
        // If pDisposing is false then the method has been called from the finalizer 
        if (pDisposing)
        {
          // Dispose managed objects here
        }

        // Free unmanaged resources here

        mDisposedValue = true;
      }

      // We should also Call the base class implementation to dispose as well (I have not implemented that here)
      //base.Dispose(pDisposing);
    }


  }
}