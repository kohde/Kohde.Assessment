using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
  [TestClass]
  public class Dungeon
  {
    [TestMethod]
    public void InvokeLvlAExtensionMethod()
    {
      var methodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });

      Assert.IsTrue(methodInfo != null, "Indicates whether the extension method has not been implemented");

      var result = methodInfo.Invoke(typeof(Program), new object[] { "asduqwezxc" }) as IEnumerable<char>;

      Assert.IsNotNull(result, "Specifies whether the correct values has been returned");

      foreach (var item in result)
      {
        Trace.TraceInformation("-> {0}", item);
      }
    }

    [TestMethod]
    public void InvokeLvlB1ExtensionMethod()
    {
      Trace.TraceInformation("Ignore InvokeLvlB2ExtensionMethod, if this test succeeds!!");

      var methodInfo = typeof(Program).GetMethod("CustomWhere");
      Assert.IsNotNull(methodInfo);
      var generic = methodInfo.MakeGenericMethod(typeof(Dog));
      Assert.IsTrue(methodInfo != null, "Indicates whether the CustomWhere extension method has not been implemented");

      var selectMethodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });
      Assert.IsTrue(selectMethodInfo != null, "Indicates whether the SelectOnlyVowels extension method has not been implemented");

      //Func<Dog, bool> expressionB = x => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

      Expression<Func<Dog, bool>> expression = x => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

      IEnumerable<Dog> dogs = new List<Dog>
            {
                new Dog("Max", 8),
                new Dog("Rocky", 3),
                new Dog("Cooper", 1),
                new Dog("Olivier", 5),
                new Dog("Teddy", 11),
                new Dog("XML", 9)
            };

      Assert.IsTrue(generic.Invoke(typeof(Program), new object[] { dogs, expression }) is IEnumerable<Dog> result && result.Count().Equals(2));
    }

    [TestMethod]
    [Ignore]
    public void InvokeLvlB2ExtensionMethod()
    {
      Trace.TraceInformation("If InvokeLvlB1ExtensionMethod fails, this method must succeed, else all possible answers are wrong");

      var methodInfo = typeof(Program).GetMethod("CustomWhere");
      Assert.IsNotNull(methodInfo);
      var generic = methodInfo.MakeGenericMethod(typeof(Human));
      Assert.IsTrue(methodInfo != null, "Indicates whether the CustomWhere extension method has not been implemented");

      var selectMethodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });
      Assert.IsTrue(selectMethodInfo != null, "Indicates whether the SelectOnlyVowels extension method has not been implemented");

      bool ExpressionB(Human x) => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

      IEnumerable<Human> dogs = new List<Human>
            {
                new Human("Max", 8),
                new Human("Rocky", 3),
                new Human("Cooper", 1),
                new Human("Olivier", 5),
                new Human("Teddy", 11),
                new Human("XML", 9)
            };

      Assert.IsTrue(generic.Invoke(typeof(Program), new object[] { dogs, (Func<Human, bool>)ExpressionB }) is IEnumerable<Human> result && result.Count().Equals(2));
    }
  }
}
