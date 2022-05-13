using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    /// <summary>
    /// The Basic Details for any party 
    /// </summary>
    public abstract class PartyDetailsBase : IPartyDetailsBase
    {

        public PartyDetailsBase() { }

        public PartyDetailsBase(string Name, int Age) 
        {
            this.Name = Name;
            this.Age = Age;
        }


        public string Name { get; set; }
        public int Age { get; set; }


        /// <summary>
        /// Returns a String Value of the Values of this base class
        /// </summary>
        /// <returns></returns>
        public string GetDetails()
        {
            return $"Name: {Name} Age: {Age}";
        }

    }

    /// <summary>
    /// Simple interface for PartyDetailsBase that defines which methods it should contain.
    /// </summary>
    public interface IPartyDetailsBase
    {

        string GetDetails();

    }


}
