namespace Kohde.Assessment.Mammal
{
  // created an interface to set some requirements for the base class
  internal interface IMammal
  {
    string Name { get; set; }
    int Age { get; set; }
    string GetDetails();
  }
}