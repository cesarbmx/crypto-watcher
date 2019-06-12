using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptoWatcher.Domain.Models;


namespace CryptoWatcher.Domain.Tests.ModelTests
{
    [TestClass]
    public class IndicatorTests
    {
        [TestMethod]
        public void DependencyLevel_1()
        {
            // Arrange
            var dependencies3 = new List<IndicatorDependency>
            {
                new IndicatorDependency("3", "4")
            };
            var dependencies2 = new List<IndicatorDependency>
            {
                new IndicatorDependency("2", "3")
            };
            var dependencies1 = new List<IndicatorDependency>
            {
                new IndicatorDependency("1", "2")
            };

            var indicator1 = new Indicator("1", IndicatorType.CurrencyIndicator, "master", "1", "1", "f()", dependencies1, 0);


            // Act
            var dependencyLevel = indicator1.DependencyLevel;

            // Assert
            Assert.AreEqual(3, dependencyLevel);
        }

    }
}
