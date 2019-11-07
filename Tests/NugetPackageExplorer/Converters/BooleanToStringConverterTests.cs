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
            var converter = new BooleanToStringConverter();

            var convertedValue = converter.Convert(true, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.AreEqual("Yes", convertedValue);
        }

        [TestMethod]
        public void Convert_NegativeValue()
        {
            var converter = new BooleanToStringConverter();

            var convertedValue = converter.Convert(false, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.AreEqual("No", convertedValue);
        }
    }
}
