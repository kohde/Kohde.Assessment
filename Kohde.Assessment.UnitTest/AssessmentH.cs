using Xunit;

namespace Kohde.Assessment.UnitTest
{
    public class AssessmentH
    {
        [Fact]
        public void ReflectionTest()
        {
            var withReflection = Program.CallMethodWithReflection();
            Assert.True(!string.IsNullOrEmpty(withReflection), "Indicates whether the method was implemented correctly");
        }
    }
}