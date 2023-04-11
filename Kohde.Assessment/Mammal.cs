using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    public abstract class Mammal: IMammal
    {
        //private variable declaration to ensure encapsulation
        private string name;
        private int age;
        
        //public getters and setters to access private properties
        public string Name {
            get => name;
            set => name = value;
        }
        public int Age {
            get => age;
            set => age = value;
        }

        //virtual GetDetails if all Mammals do not want to implement their own method, can force them by making method abstract
        public virtual string GetDetails()
        {
            return "Name: " + name + " Age: " + age;
        }

    }
}
