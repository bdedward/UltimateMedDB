using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateMedDB.Business;

namespace UMDBBusinessLayerTest
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void AddRoomTest()
        {
            //Arrange
            Room newRoom = new Room
            {
                Number = 302,
                Status = "available",
                Type = "Intensive Care"
            };
            Room.AddNewRoom(newRoom);

            //Act
            int expectedNumber = 302;
            string expectedStatus = "available";
            string expectedType = "Intensive Care";

            int actualNumber = newRoom.Number;
            string actualStatus = newRoom.Status;
            string actualType = newRoom.Type;

            //Assert
            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedStatus, actualStatus);
            Assert.AreEqual(expectedType, actualType);
        }

    }
}
