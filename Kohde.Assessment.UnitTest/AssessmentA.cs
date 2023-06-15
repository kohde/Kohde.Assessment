using System.Linq;
using Kohde.Assessment.Mammals;
using Xunit;

namespace Kohde.Assessment.UnitTest
{
    public class AssessmentA
    {
        [Fact]
        public void TestA1()
        {
            Assert.NotSame(typeof(object), typeof(Human).BaseType);
        }

        [Fact]
        public void TestA2()
        {
            Assert.True(typeof(Human).BaseType.IsAbstract);
        }

        [Fact]
        public void TestA3()
        {
            Assert.Same(typeof(Human).GetMethod("ToString").DeclaringType, typeof(Human));
        }

        [Fact]
        public void TestA4()
        {
            Assert.NotSame(typeof(object), typeof(Human).BaseType);

            Assert.Same(typeof(Human).BaseType.GetMethod("GetDetails").DeclaringType, typeof(Human).BaseType);
        }

        [Fact]
        public void TestA5()
        {
            var properties = typeof(Human).BaseType.GetProperties().ToList();

            Assert.True(properties.Count > 0);

            Assert.True(properties.FirstOrDefault(x => x.Name.Equals("Name")) != null);
            Assert.True(properties.FirstOrDefault(x => x.Name.Equals("Age")) != null);
        }

        [Fact]
        public void ABonus1()
        {
            var baseType = typeof(Human).BaseType;
            Assert.True(baseType != null);
            {
                var interfaces = baseType.GetInterfaces();
                Assert.True(interfaces != null && interfaces.Any());
            }
        }
    }
}