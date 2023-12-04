using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    interface iMammal:IDisposable
    {
        //created the interface and the common method of GetDetails and implented the idisposable method
        //string ToString();
        string GetDetails();
    }
}
