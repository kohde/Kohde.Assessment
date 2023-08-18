﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentG
    {
        [TestMethod]
        public void StackTraceTest()
        {
            try
            {
                Program.CatchAndRethrowExplicitly();
            }
            catch (ArithmeticException e)
            {
                Assert.IsTrue(GetNumSubstringOccurrences(e.StackTrace, "at") >= 3, "Indicates whether the stack trace is intact");
            }
        }
        public static int GetNumSubstringOccurrences(string text, string search)
        {
            var num = -1;
            var pos = 0;

            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(search))
            {
                return num;
            }

            while (text.IndexOf(search, pos, StringComparison.Ordinal) > -1)
            {
                num++;
                pos = text.IndexOf(search, pos, StringComparison.Ordinal) + search.Length + 1;
            }
            return num;
        }
    }
}