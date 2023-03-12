namespace Kohde.Assessment.AssessmentA
{
  // We define the classes 'contract' in the interfaces
  public abstract class Mammal : IMammal
  {
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public abstract string GetDetails();
  }
}
