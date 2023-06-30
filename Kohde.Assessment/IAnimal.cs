using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public interface IAnimal: IMammal
    {
        string Food { get; set; }
    }
}
