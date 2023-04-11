using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public interface IMammal
    {
        //Properties that all Mammals require
        string Name { get; }
        int Age { get; }
        //Method that all Mammals require
        string GetDetails();
    }
}
