using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment.AssessmentA
{
  // All classes implementing this interface must have these properties
  internal interface IMammal
  {
    string Name { get; set; }

    int Age { get; set; }

    string GetDetails();
  }
}
