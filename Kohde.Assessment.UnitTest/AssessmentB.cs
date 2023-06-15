using System.Diagnostics;
using Xunit;

namespace Kohde.Assessment.UnitTest
{
    public class AssessmentB
    {
        [Fact]
        public void PerformanceTest()
        {
            // check whether the performance has increased
            var s = new Stopwatch();
            s.Start();
            Program.PerformanceTest();
            s.Stop();
            Trace.TraceInformation("Performance: {0}ms", s.ElapsedMilliseconds);
            Assert.True(s.ElapsedMilliseconds < 1000, "Elapsed Milliseconds greater than 1 second indicates slow performance");
        }
    }
}