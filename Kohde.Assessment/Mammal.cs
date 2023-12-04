using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public abstract class Mammal : iMammal
    {
        //implented the abstract class with all the properties used by the different classes. Also implementing the methods required by idisposable
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }
        public string Gender { get; set; }
        private bool _disposed { get; set; }
        public string GetDetails()
        {
            return "Name: " + Name + " Age: " + Age;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Clear all property values that maybe have been set
                    // when the class was instantiated
                    Name = null;
                    Age = -1;
                    Food = null;
                    Gender = null;
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }
    }
}
