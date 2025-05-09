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

            Assert.AreEqual("Test",repo?.AddPlayer(new Player() {Name = "Test", IsMurderer = true})?.Name);

            players = repo?.GetAllPlayers();

            Assert.AreNotEqual(5,players?.Count);
            Assert.AreEqual(6,players?.Count);
            Assert.AreNotEqual(7,players?.Count);
        }

        [TestMethod]
        public void GetPlayerByIdTest()
        {
            Assert.IsNotNull(repo);
            List<Player>? players = repo?.GetAllPlayers();
            Assert.AreEqual(5, players?.Count);
            Assert.ThrowsException<ArgumentNullException>(() => repo?.GetPlayerById(6));
            Player? test = repo?.GetPlayerById(1);
            Assert.IsNotNull(test);
            Assert.AreEqual("Miki", test?.Name);
        }

        [TestMethod]
        public void UpdatePlayerTest(){
            Assert.IsNotNull(repo);
            List<Player>? players = repo?.GetAllPlayers();

            string? toTest = players[0]?.Name;
            Assert.AreEqual("Miki",toTest);
            Assert.ThrowsException<ArgumentNullException>(() => repo?.UpdatePlayer(1,null));

            Assert.AreEqual(false, players[0]?.IsMurderer);

            Player? testNameChange = new() { Name = "Mixi", IsMurderer = true};

            Assert.AreEqual(true, repo?.UpdatePlayer(1,testNameChange)?.IsMurderer);
        }
    }
}


