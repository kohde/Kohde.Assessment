using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public abstract class Animal: IComparable<Animal>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual string GetDetails()
        {
            return "Name: " + Name + " Age: " + Age;
        }

        public int CompareTo(Animal other)
        {
            if (other == null) return 1;
            return Age.CompareTo(other.Age);
        }
    }
}
