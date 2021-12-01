using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RemoteConnectionTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Getting_Player_With_NonExisting_Email_Should_Receive_Player_ID_0()
        {
            string strJSONInput =  "{\"email\":\"notValidEmail@fake.com\"}";
            string jsonResult = GetAPIDatabase.GetPlayers(strJSONInput);
            Player player = Deserialization.DeserializePlayer(jsonResult);
            Assert.IsNotNull(player);
            Assert.AreEqual(0, player.player_id);
        }

        [Test]
        public void Should_Get_Player_Information()
        {
            string strJSONInput = "{\"email\":\"test1@example.com\"}";
            string jsonResult = GetAPIDatabase.GetPlayers(strJSONInput);
            Player player = Deserialization.DeserializePlayer(jsonResult);
            Assert.IsNotNull(player);
            Assert.AreEqual(1, player.player_id);
            Assert.AreEqual(0, player.currency);
            Assert.AreEqual(0, player.fuelAmount);
            Assert.AreEqual("Bike", player.selectedVehicle);
            Assert.AreEqual(0, player.upgrade);
            Assert.AreEqual(0, player.protection);
            Assert.AreEqual(0, player.time);
            Assert.AreEqual(0, player.totalScore);
        }
    }
}
