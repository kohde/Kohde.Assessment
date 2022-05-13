namespace Kohde.Assessment
{

    /// <summary>
    /// Dog specific class
    /// </summary>
    public class Dog : PartyPetDetailsBase, System.IDisposable
    {

        public Dog() { }

        public Dog(string Name, int Age, string Food) : base(Name: Name, Age: Age, Food: Food)
        {
        }

        /// Space Available here for Dog specific Properties.

        public void Dispose()
        {
            
        }

        

    }
}