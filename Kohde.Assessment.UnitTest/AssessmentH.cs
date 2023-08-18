using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentH
    {
        [TestMethod]
        public void ReflectionTest()
        {
            var withReflection = Program.CallMethodWithReflection();

            //IsNullOrWhiteSpace checks for null, empty or whitespace as opposed to IsNullOrEmpty just checking for null or empty.
            Assert.IsTrue(!string.IsNullOrWhiteSpace(withReflection), "Indicates whether the method was implemented correctly");
        }
    }
}