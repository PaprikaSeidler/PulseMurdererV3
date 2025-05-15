using Microsoft.VisualStudio.TestTools.UnitTesting;
using PulseMurdererV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace PulseMurdererV3.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            string? expected = "Id: 0, Name: Miki, Avatar: , IsMurderer: False";
            Player test = new() { Name = "Miki", IsMurderer = false };
            Assert.IsNotNull(test);

            Assert.AreEqual(expected, test.ToString());
        }
        [TestMethod]
        public void PlayerNameTest()
        {
            string? expectedName = "Paprika";
            Player test = new() { Name = "Paprika", IsMurderer = false };
            Assert.IsNotNull(test);

            Assert.AreEqual(expectedName, test.Name);
            Assert.ThrowsException<ArgumentNullException>(() => test.Name = null);
            Assert.ThrowsException<ArgumentException>(() => test.Name = " ");
        }

        [TestMethod]
        public void PlayerMurderTest()
        {
            Player test = new() { Name = "Peter", IsMurderer = true };
            Assert.IsNotNull(test);
            Assert.AreEqual(true, test.IsMurderer);
        }

        
    }
}