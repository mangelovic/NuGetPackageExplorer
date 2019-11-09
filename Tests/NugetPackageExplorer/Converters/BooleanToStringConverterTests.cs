using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageExplorer;

namespace Tests
{
    [TestClass]
    public class BooleanToStringConverterTests
    {
        [TestMethod]
        public void Convert_PositiveValue()
        {
            // Arrange
            var converter = new BooleanToStringConverter();

            // Act
            var convertedValue = converter.Convert(true, typeof(bool), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual("Yes", convertedValue);
        }

        [TestMethod]
        public void Convert_NegativeValue()
        {
            // Arrange
            var converter = new BooleanToStringConverter();

            // Act
            var convertedValue = converter.Convert(false, typeof(bool), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual("No", convertedValue);
        }
    }
}
