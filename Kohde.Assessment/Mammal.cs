using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public abstract class Mammal : IMammal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual string GetDetails()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
        protected Mammal(string name, int age) {
            Name = name;
            Age = age;
        }

        protected Mammal() { }
    }
}
