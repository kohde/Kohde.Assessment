using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

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
            Trace.TraceInformation($"Performance: {s.ElapsedMilliseconds}ms"); //cleaner
            Assert.IsTrue(s.ElapsedMilliseconds < 1000, "Elapsed Milliseconds greater than 1 second indicates slow performance");
        }
    }
}