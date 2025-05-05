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
            List<Player> players = repo.GetAllPlayers();

            Assert.AreNotEqual(4,players.Count);
            Assert.AreEqual(5,players.Count);
            Assert.AreNotEqual(6,players.Count);
        }
    }
}
