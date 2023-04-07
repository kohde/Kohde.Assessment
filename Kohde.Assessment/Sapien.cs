using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public abstract class Sapien: ICreature
    {
        //Name variable
        public string Name { get; set; }

        //Age variable
        public int Age { get; set; }

        //Gender variable
        public string Gender { get; set; }

        //abstract method GetDetails to be implemented
        public abstract string GetDetails();
    }
}
