using Kohde.Assessment.Objects.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Kohde.Assessment.UnitTest
{
    //Magic strings are usually bad practice. Instead declared as consts throughout the test.
    [TestClass]
    public class AssessmentA
    {
        [TestMethod]
        public void TestA1()
        {
            Assert.AreNotSame(typeof(object), typeof(Human).BaseType);
        }

        [TestMethod]
        public void TestA2()
        {
            Assert.IsTrue(typeof(Human).BaseType.IsAbstract);
        }

        [TestMethod]
        public void TestA3()
        {
            const string toString = "ToString";

            Assert.AreSame(typeof(Human).GetMethod(toString).DeclaringType, typeof(Human));
        }

        [TestMethod]
        public void TestA4()
        {
            const string getDetails = "GetDetails";

            Assert.AreNotSame(typeof(object), typeof(Human).BaseType);

            Assert.AreSame(typeof(Human).BaseType.GetMethod(getDetails).DeclaringType, typeof(Human).BaseType);
        }

        [TestMethod]
        public void TestA5()
        {
            const string name = "Name";
            const string age = "Age";

            var properties = typeof(Human).BaseType.GetProperties().ToList();

            Assert.IsTrue(properties.Count > 0);

            Assert.IsTrue(properties.FirstOrDefault(x => x.Name.Equals(name)) != null);
            Assert.IsTrue(properties.FirstOrDefault(x => x.Name.Equals(age)) != null);
        }

        [TestMethod]
        public void ABonus1()
        {
            var baseType = typeof(Human).BaseType;
            Assert.IsTrue(baseType != null);
            {
                var interfaces = baseType.GetInterfaces();
                Assert.IsTrue(interfaces != null && interfaces.Any());
            }
        }
    }
}