using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentG
    {
        [TestMethod]
        public void ReflectionTest()
        {
            var withReflection = Program.CallMethodWithReflection();
            Assert.IsTrue(!string.IsNullOrEmpty(withReflection), "Indicates whether the method was implemented correctly");                        
        }
    }
}
