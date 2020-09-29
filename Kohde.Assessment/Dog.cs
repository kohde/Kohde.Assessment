namespace Kohde.Assessment
{
    public class Dog : Mammal, System.IDisposable
    {
        public string Food { get; set; }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}