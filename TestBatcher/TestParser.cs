using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Batcher;

namespace TestBatcher
{
    [TestClass]
    public class TestParser
    {
        const string SimpleTestSequence = "<Sequence name='testsequence'><copy id='step1' /><move id='step2' /></Sequence>";
        private const string InvalidXML = "<Sequence>";
        [TestMethod]
        public void ParseValidSequence()
        {
            Parser parser= new Parser(SimpleTestSequence);
            Assert.IsNotNull(parser);
            Assert.IsTrue(parser.gotValidSequenceString(SimpleTestSequence),"Got invalid sequence though its valid.");
            parser = null;
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ParseInvalidXML()
        {
            Parser parser = new Parser(InvalidXML);
            Assert.IsFalse(parser.gotValidSequenceString(InvalidXML), "Check for invalid XML failed.");
            parser = null;
        }
        [TestMethod]
        public void TestGetSequenceName()
        {
            Parser parser = new Parser(SimpleTestSequence);
            Assert.AreEqual("testsequence", parser.GetSequenceName());
        }
    }
}
