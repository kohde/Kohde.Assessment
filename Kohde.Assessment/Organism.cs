namespace Kohde.Assessment
{
    /// <summary>
    /// Introduced an abstract base class "Organism"
    /// Reason: Human, Dog, and Cat all share common properties (Name, Age)
    /// and all must provide a GetDetails() method
    /// Abstract class avoids code duplication and enforces consistency
    /// </summary>
    public abstract class Organism : IOrganism
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract string GetDetails();
    }
}
