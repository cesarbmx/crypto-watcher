using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.CryptoWatcher.Domain.Builders;
using CesarBmx.CryptoWatcher.Domain.Types;


namespace CesarBmx.CryptoWatcher.Tests.Domain.Builders
{
    [TestClass]
    public class LineBuilderTests
    {
        #region BuildPeriod

        [TestMethod]
        public void Test_BuildPeriod_OneDay()
        {
            // Arrange
            var time = new DateTime(2021, 2, 5, 0, 0, 0);

            // Act
            var period = LineBuilder.BuildPeriod(time);

            // Assert
            Assert.AreEqual(Period.ONE_DAY, period);
        }

        [TestMethod]
        public void Test_BuildPeriod_OneHour()
        {
            // Arrange
            var time = new DateTime(2021, 2, 5, 10, 0, 0);

            // Act
            var period = LineBuilder.BuildPeriod(time);

            // Assert
            Assert.AreEqual(Period.ONE_HOUR, period);
        }

        [TestMethod]
        public void Test_BuildPeriod_FifteenMinutes()
        {
            // Arrange
            var time = new DateTime(2021, 2, 5, 10, 30, 0);

            // Act
            var period = LineBuilder.BuildPeriod(time);

            // Assert
            Assert.AreEqual(Period.FIFTEEN_MINUTES, period);
        }

        [TestMethod]
        public void Test_BuildPeriod_FiveMinutes()
        {
            // Arrange
            var time = new DateTime(2021, 2, 5, 10, 10, 0);

            // Act
            var period = LineBuilder.BuildPeriod(time);

            // Assert
            Assert.AreEqual(Period.FIVE_MINUTES, period);
        }

        [TestMethod]
        public void Test_BuildPeriod_OneMinute()
        {
            // Arrange
            var time = new DateTime(2021, 2, 5, 10, 12, 0);

            // Act
            var period = LineBuilder.BuildPeriod(time);

            // Assert
            Assert.AreEqual(Period.ONE_MINUTE, period);
        }

        #endregion
    }
}
