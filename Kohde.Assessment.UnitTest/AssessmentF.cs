using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentF
    {
        [TestMethod]
        public void InvokeGenericMethodA()
        {
            var method = typeof(Program).GetMethod("ShowSomeMammalInformation");

            Assert.IsTrue(method != null, "Indicates whether the generic method has not been implemented");

            var human = new Human
            {
                Name = "John Doe", Age = 34
            };
            var dog = new Dog
            {
                Name = "Russell",
                Age = 7
            };
            var cat = new Cat
            {
                Name = "Mr.. Whiskers",
                Age = 5
            };

            var generic = method.MakeGenericMethod(typeof(Human));
            generic.Invoke(typeof(Program), new object[] { human });
            
            generic = method.MakeGenericMethod(typeof(Dog));
            generic.Invoke(typeof(Program), new object[] { dog });
            
            generic = method.MakeGenericMethod(typeof(Cat));
            generic.Invoke(typeof(Program), new object[] { cat });
        }

        [TestMethod]
        public void InvokeGenericMethodB()
        {
            var method = typeof(Program).GetMethod("GenericTester");
            Assert.IsTrue(method != null, "Indicates whether the generic method has not been implemented");

            var human = new Human
            {
                Name = "John Doe", Age = 34
            };

            var dog = new Dog
            {
                Name = "Walter", Age = 7
            };

            string Func1(Dog x) => x.GetDetails();
            Type[] typeArgs1 = { typeof(Dog), typeof(string) };
            var generic1 = method.MakeGenericMethod(typeArgs1);
            var resultA = generic1.Invoke(typeof(Program), new object[]
            {
                (Func<Dog, string>) Func1, dog
            });
            Trace.TraceInformation("{0}", resultA);

            string Func2(Human x) => x.GetDetails();
            Type[] typeArgs2 = { typeof(Human), typeof(string) };
            var generic2 = method.MakeGenericMethod(typeArgs2);
            var resultB = generic2.Invoke(typeof(Program), new object[]
            {
                (Func<Human, string>) Func2, human
            });
            Trace.TraceInformation("{0}", resultB);

            Type[] typeArgs3 = { typeof(Human), typeof(string) };
            var generic3 = method.MakeGenericMethod(typeArgs3);
            var resultC = generic3.Invoke(typeof(Program), new object[]
            {
                (Func<Human, string>) Func2, null
            });
            Trace.TraceInformation("{0}", resultC);
        }
    }
}
