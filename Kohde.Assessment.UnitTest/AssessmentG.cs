using System;
using Xunit;

namespace Kohde.Assessment.UnitTest
{
    public class AssessmentG
    {
        [Fact]
        public void StackTraceTest()
        {
            try
            {
                Program.CatchAndRethrowExplicitly();
            }
            catch (ArithmeticException e)
            {
                Assert.True(GetNumSubstringOccurrences(e.StackTrace, "at") >= 3, "Indicates whether the stack trace is intact");
            }
        }

        public static int GetNumSubstringOccurrences(string text, string search)
        {
            var num = -1;
            var pos = 0;
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(search))
                return num;

            while (text.IndexOf(search, pos, StringComparison.Ordinal) > -1)
            {
                num++;
                pos = text.IndexOf(search, pos, StringComparison.Ordinal) + search.Length + 1;
            }

            return num;
        }
    }
}