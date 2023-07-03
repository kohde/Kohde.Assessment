using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public class Animal : Mammal
    {
        public string Food { get; set; }
        public Animal(string name, int age, string food) : base(name, age)
        {
            Food = food;
        }

        public Animal() { }

        public override string ToString()
        {
            return $"{base.GetDetails()}, {nameof(Food)}: {Food}";
        }
    }
}