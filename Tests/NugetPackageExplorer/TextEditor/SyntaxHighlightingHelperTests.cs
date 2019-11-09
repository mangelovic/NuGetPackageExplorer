using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageExplorer;

namespace Tests
{
    [TestClass]
    public class SyntaxHighlightingHelperTests
    {
        [DataTestMethod]
        [DataRow("file.js", "JavaScript")]
        [DataRow("file.css", "CSS")]
        public void GuessHighligtingDefinition_css_js(string fileName, string expectedExtension)
        {
            // Act
            var answer = SyntaxHighlightingHelper.GuessHighligtingDefinition(fileName);

            // Assert
            Assert.AreEqual(expectedExtension, answer.Name);
        }

        [DataTestMethod]
        [DataRow("file.transform", "Plain Text")]
        [DataRow("file.pp", "Plain Text")]
        public void GuessHighligtingDefinition_pp_transform(string fileName, string expectedExtension)
        {
            // Act
            var answer = SyntaxHighlightingHelper.GuessHighligtingDefinition(fileName);

            // Assert
            Assert.AreEqual(expectedExtension, answer.Name);
        }

        [TestMethod]
        public void GuessHighligtingDefinition_xml()
        {
            // Act
            var answer = SyntaxHighlightingHelper.GuessHighligtingDefinition("Jano.xml");

            // Assert
            Assert.AreEqual("XML", answer.Name);
        }
    }
}
