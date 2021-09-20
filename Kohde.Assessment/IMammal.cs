using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public interface IMammal
    {
        string Name { get; set; }
        int Age { get; set; }
        string Food { get; set; }
        string Gender { get; set; }
        string GetDetails();
    }
}
