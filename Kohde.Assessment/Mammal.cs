using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public abstract class Mammal : IMammal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Food { get; set; }

        public virtual string GetDetails()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }
}
