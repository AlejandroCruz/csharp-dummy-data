﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReadWriteTest
{
    [TestClass]
    public class RegexHandlerUtils_Test1
    {
        [TestMethod]
        public static void Main()
        {
            string actual = "AA";
            string expected = "AB";

            RegexHandlerUtils rgxUtilTest = new RegexHandlerUtils();

            string testResult = rgxUtilTest.AddPrefixToSequence(actual);

            Assert.AreEqual(expected, testResult);
        }
    }
}