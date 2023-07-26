using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    /*
     * bcodendaal notes: 
     * This might be overengineered, but I created an interface for IPet which will have properties defined for all pets.
     * The way food was used in the program suggests that it may not be applicable to the human as types of pet food was specified. 
     * If the Human class also needs to have a Food property I would remove this interface and just add the property to the base class.
     */
    public interface IPet
    {
        string Food { get; set; }
    }
}
