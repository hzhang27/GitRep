using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetTest
{
    /// <summary>
    /// Summary description for SmartRobotTest
    /// </summary>
    [TestClass]
    public class SmartRobotTest
    {
        [TestMethod]
        public void Store_One_Bag_When_All_Cabinets_Full_Return_Null_Ticket()
        {
            var smartRobot = new SmartRobot(new List<Cabinet>{new Cabinet(0),new Cabinet(0),new Cabinet(0)});
            var bag = new Bag();
            var ticket = smartRobot.Store(bag);
            Assert.IsNull(ticket);
        }

        [TestMethod]
        public void Store_One_Bag_When_Not_All_Cabinets_Full_Return_Ticket()
        {
            var smartRobot = new SmartRobot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var bag = new Bag();
            var ticket = smartRobot.Store(bag);
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void Pick_One_Bag_When_Cabinet_Has_My_Bag_And_Give_Valid_Ticket()
        {
            var smartRobot = new SmartRobot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var bag = new Bag();
            var ticket = smartRobot.Store(bag);
            Bag pickBag = smartRobot.Pick(ticket);
            Assert.AreEqual(bag,pickBag);
        }

        [TestMethod]
        public void Pick_One_Bag_When_Cabinet_Has_My_Bag_And_Give_InValid_Ticket()
        {
            var smartRobot = new SmartRobot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var bag = new Bag();
            var ticket = smartRobot.Store(bag);
            smartRobot.Pick(ticket);
            Bag returnBag = smartRobot.Pick(ticket);
            Assert.IsNull(returnBag);
        }

        [TestMethod]
        public void StoreBag_In_MostEmpty_Cabinet()
        {
            var smartRobot = new SmartRobot(new List<Cabinet> { new Cabinet(2), new Cabinet(2), new Cabinet(2) });
            var bag = new Bag();
            smartRobot.Store(new Bag());
            smartRobot.Store(new Bag());
            Assert.AreEqual(1, smartRobot.GetCabinet(0).RemainingEmptyBoxCount);
            Assert.AreEqual(1, smartRobot.GetCabinet(1).RemainingEmptyBoxCount);
        } 

    }
}
