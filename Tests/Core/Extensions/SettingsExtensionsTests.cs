using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGetPe;

namespace Tests.Core.Extensions
{
    [TestClass]
    public class SettingsExtensionsTests
    {
        [TestMethod]
        public void GetEncryptedValue_FormatException_Expected()
        {
            try
            {
                // Arrange
                var settings = new Mock<NuGetPe.ISettings>();
                settings.Setup(e => e.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns("ZGVjcg");

                // Act
                var answer = SettingsExtensions.GetDecryptedValue(settings.Object, "apikeys", "testKey");

                // Assert
                Assert.Fail();
            }
            catch (FormatException)
            {
                // Assert
                Assert.IsTrue(true, "Expected FormatException thrown.");
            }
        }

        [TestMethod]
        public void GetEncryptedValue_CryptographicException_Expected()
        {
            try
            {
                // Arrange
                var settings = new Mock<NuGetPe.ISettings>();
                settings.Setup(e => e.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns("AgQGCAoMDhASFA==");

                // Act
                var answer = SettingsExtensions.GetDecryptedValue(settings.Object, "apikeys", "testKey");

                // Assert
                Assert.Fail();
            }
            catch (Exception e)
            {
                // Assert
                if (e.Message == "The parameter is incorrect.")
                {
                    Assert.IsTrue(true, "Expected Cryptographic exception thrown.");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetEncryptedValue_SettingsNull_ExceptionExpected()
        {
            try
            {
                // Act
                var answer = SettingsExtensions.GetDecryptedValue(null, "apikeys", "testKey");

                // Assert
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.IsTrue(true, "Expected ArgumentNullException thrown.");
            }
        }

        [TestMethod]
        public void GetEncryptedValue_SectionNull_ExceptionExpected()
        {
            try
            {
                // Arrange
                var settings = new Mock<NuGetPe.ISettings>();

                // Act
                var answer = SettingsExtensions.GetDecryptedValue(settings.Object, null, "testKey");

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // Assert
                Assert.IsTrue(true, "Expected ArgumentException thrown.");
            }
        }

        [TestMethod]
        public void GetEncryptedValue_KeyNull_ExceptionExpected()
        {
            try
            {
                // Arrange
                var settings = new Mock<NuGetPe.ISettings>();

                // Act
                var answer = SettingsExtensions.GetDecryptedValue(settings.Object, "apikeys", null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // Assert
                Assert.IsTrue(true, "Expected ArgumentException thrown.");
            }
        }
    }
}
