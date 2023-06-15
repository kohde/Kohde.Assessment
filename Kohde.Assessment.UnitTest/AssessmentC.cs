using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Kohde.Assessment.UnitTest
{
    public class AssessmentC
    {
        [Fact]
        public void FirstOrDefaultUsed()
        {
            var value = Program.GetFirstEvenValue(new List<int>
            {
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19
            });

            Trace.TraceInformation("Value: {0}", value);
            Assert.True(value % 2 == 0, "Indicates whether the use made use of the correct logic");
        }

        [Fact]
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

            Assert.True(!string.IsNullOrEmpty(value2));
        }
    }
}