namespace Kohde.Assessment.AssessmentA
{
  // All classes implementing this interface must have these properties
  public interface IMammal
  {
    string Name { get; set; }

    int Age { get; set; }

    string GetDetails();
  }
}
