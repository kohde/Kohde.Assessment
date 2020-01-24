using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentB
    {
        [TestMethod]
        public void PerformanceTest()
        {
            // check whether the performance has increased
            var s = new Stopwatch();
            s.Start();
            Program.PerformanceTest();
            s.Stop();
            Trace.TraceInformation("Performance: {0}ms", s.ElapsedMilliseconds);
            Assert.IsTrue(s.ElapsedMilliseconds < 1000, "Elapsed Milliseconds greater than 1 second indicates slow performance");
        }
    }
}