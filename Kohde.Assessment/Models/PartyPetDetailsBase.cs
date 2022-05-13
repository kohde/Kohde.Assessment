using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{

    /// <summary>
    /// A Base Class for pets as for all their similar properties.
    /// </summary>
    public class PartyPetDetailsBase : PartyDetailsBase
    {

        public PartyPetDetailsBase() { }

        public PartyPetDetailsBase(string Name, int Age, string Food) : base(Name: Name, Age: Age)
        {
            this.Food = Food;
        }

        public string Food { get; set; }

    }
}
