using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public class Mammal : IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine("Disposing member");
        }

    }
}
