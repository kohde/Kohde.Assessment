using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    /*
     * Abstract class creatures to contain related fields and methods
    */
    public abstract class Animal: ICreature
    {
        //Name variable
        public string Name { get; set; }

        //Age variable
        public int Age { get; set; }

        //Food variable
        public string Food { get; set; }

        //GetDetails method that should be implemented
        public abstract string GetDetails();

    }
}
