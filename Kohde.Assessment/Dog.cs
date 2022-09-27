using System;

namespace Kohde.Assessment
{
    public class Dog : IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Name = String.Empty;
                Age = 0;
                Food = String.Empty;
            }
            
        }

        public string GetDetails()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }
}