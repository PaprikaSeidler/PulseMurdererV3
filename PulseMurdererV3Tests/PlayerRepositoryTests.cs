﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(null, repo?.GetPlayerById(10));
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
            Assert.ThrowsException<ArgumentNullException>(() => repo?.UpdatePlayer(10, testNameChange));
        }
        [TestMethod]
        public void RemovePlayerTest()
        {
            Assert.IsNotNull(repo);
            List<Player>? players = repo?.GetAllPlayers();
            Assert.AreEqual(5, players?.Count);
            repo.Remove(1);
            players = repo?.GetAllPlayers();
            Assert.AreEqual(4, players?.Count);
            Assert.ThrowsException<ArgumentNullException>(() => repo?.Remove(6));
        }

        [TestMethod]
        public void ClearVoteTest()
        {
            repo.UpdatePlayer(1, new Player() { Name = "Miki", HasVoted = true });
            repo.ClearVotes();
            Assert.AreEqual(repo.GetPlayerById(1)?.HasVoted, false);
            repo.UpdatePlayer(1, new Player() { Name = "Miki", VotesRecieved = 1 });
            repo.ClearVotes();
            Assert.AreEqual(repo.GetPlayerById(1)?.VotesRecieved, 0);
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void TallyVoteTest()
        {
            Assert.IsNotNull(repo);
            List<Player>? players = repo?.GetAllPlayers();
            Assert.AreEqual(5, players?.Count);
            repo.UpdatePlayer(1, new Player() { Name = "Miki", VotesRecieved = 4 });
            Assert.AreEqual(4, players[0]?.VotesRecieved);
            repo.TallyVotes();
            Assert.AreEqual(0, players[0]?.VotesRecieved);
            Assert.AreEqual(false, players[0]?.IsAlive);
        }
    }
}


