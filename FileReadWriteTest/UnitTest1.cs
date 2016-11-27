using FileReadWrite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReadWriteTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddPrefixToSequence()
        {
            string actual = "AA";
            string expected = "AB";

            RegexHandlerUtils rgxUtilTest = new RegexHandlerUtils();

            string testResult = rgxUtilTest.AddPrefixToSequence(actual);

            Assert.AreEqual(expected, testResult);
        }
    }
}