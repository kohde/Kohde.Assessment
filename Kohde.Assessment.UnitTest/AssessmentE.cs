using System;
using System.Reflection;
using Xunit;

namespace Kohde.Assessment.UnitTest
{
    public class AssessmentE
    {
        [Fact]
        public void HasObjectBeenDisposed()
        {
            var disposableObject = Program.DisposeSomeObject().Result;
            Assert.True(disposableObject.Counter.Equals(1), "Trivial Test => Indicates event handler has not been disposed properly");

            var fieldInfo = typeof(DisposableObject).GetField("SomethingHappened", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null) return;
            if (!(fieldInfo.GetValue(disposableObject) is Delegate handler)) return;
            var subscribers = handler.GetInvocationList();
            Assert.True(subscribers.Length == 0, "More Relevant => Indicates event handler has not been disposed properly");
        }
    }
}