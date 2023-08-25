using System;

namespace Kohde.Assessment
{
    public class Dog : IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }        

        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {               
            }
        }

        public void Dispose() {
            Dispose(true);
        }
    }
}