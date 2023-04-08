using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public abstract class Mammal: IMammal
    {

        public abstract string Name { get; set; }
        public abstract int Age { get; set; }

        public abstract string GetDetails();
    }
}
