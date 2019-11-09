using System;
using System.Globalization;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageExplorer;

namespace Tests
{
    [TestClass]
    public class IconUrlToImageCacheConverterTests
    {
        [TestMethod]
        public void Convert_Image()
        {
            // Arrange
            var converter = new IconUrlToImageCacheConverter();
            var uri = new Uri("https://cdn0.iconfinder.com/data/icons/dota-2-2/32/Recipe-512.png");
            var image = new BitmapImage(uri);

            // Act
            BitmapImage? convertedValue = converter.Convert("https://cdn0.iconfinder.com/data/icons/dota-2-2/32/Recipe-512.png", typeof(BitmapSource), null, CultureInfo.InvariantCulture) as BitmapImage;

            // Assert
            if (convertedValue != null)
            {
                Assert.AreEqual(image.DependencyObjectType.Id, convertedValue.DependencyObjectType.Id);
                Assert.AreEqual(image.DependencyObjectType.Name, convertedValue.DependencyObjectType.Name);
                Assert.AreEqual(image.DependencyObjectType.BaseType.Id, convertedValue.DependencyObjectType.BaseType.Id);
                Assert.AreEqual(image.DependencyObjectType.BaseType.Name, convertedValue.DependencyObjectType.BaseType.Name);
            }
            else
            {
                Assert.Fail("Return object from Convert method is was null. Test failed.");
            }
        }
    }
}
