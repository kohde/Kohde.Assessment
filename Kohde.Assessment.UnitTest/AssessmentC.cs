using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentC
    {
        [TestMethod]
        public void FirstOrDefaultUsed()
        {
            var value = Program.GetFirstEvenValue(new List<int>
            {
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19
            });

            Trace.TraceInformation("Value: {0}", value);
            Assert.IsTrue(value%2 == 0, "Indicates whether the use made use of the correct logic");
        }

        [TestMethod]
        public void SingleOrDefaultUsed()
        {
            var value = Program.GetSingleStringValue(new List<string>
            {
                "Jhn", "Jn", "Srh", "Pt"
            });

            Trace.TraceInformation("Testing for: System.InvalidOperationException: Sequence contains no elements");
            Trace.TraceInformation("Value: {0}", value);

            var value2 = Program.GetSingleStringValue(new List<string>
            {
                "Jhn", "Jn", "Sarah", "Pt"
            });

            Assert.IsTrue(!string.IsNullOrEmpty(value2));
        }
    }
}
