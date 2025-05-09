using Microsoft.VisualStudio.TestTools.UnitTesting;
using PulseMurdererV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseMurdererV3.Tests
{
    [TestClass()]
    public class PlayerRepositoryTests
    {
        PlayerRepository? repo;

        [TestInitialize]
        public void TestInitializer(){
            repo = new();
        }

        [TestMethod()]
        public void GetAllPlayersTest()
        {
            Assert.IsNotNull(repo);
            List<Player>? players = repo.GetAllPlayers();

            Assert.AreNotEqual(4,players?.Count);
            Assert.AreEqual(5,players?.Count);
            Assert.AreNotEqual(6,players?.Count);
        }

        [TestMethod]
        public void AddToRepoTest(){
            Assert.IsNotNull(repo);
            List<Player>? players = repo?.GetAllPlayers();

            Assert.AreNotEqual(4,players?.Count);
            Assert.AreEqual(5,players?.Count);
            Assert.AreNotEqual(6,players?.Count);

            Assert.ThrowsException<ArgumentNullException>(() => repo?.AddPlayer(null));

            Assert.AreEqual("Test",repo?.AddPlayer(new Player() {Name = "Test", IsMurderer = true}).Name);

            players = repo?.GetAllPlayers();

            Assert.AreNotEqual(5,players?.Count);
            Assert.AreEqual(6,players?.Count);
            Assert.AreNotEqual(7,players?.Count);
        }
    }
}


