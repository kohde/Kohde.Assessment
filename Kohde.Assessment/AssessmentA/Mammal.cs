using Kohde.Assessment.AssessmentA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment.AssessmentA
{
    public abstract class Mammal : IMammal, IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract string GetDetails();
    }
}
