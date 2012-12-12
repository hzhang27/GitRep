using System.Collections.Generic;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetTest
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Store_One_Bag_When_All_Cabinets_Full_Return_Null_Ticket()
        {
            var robot = new Robot(new List<Cabinet>{new Cabinet(0),new Cabinet(0),new Cabinet(0)});
            var bag = new Bag();
            var ticket = robot.Store(bag);
            Assert.IsNull(ticket);
        }

        [TestMethod]
        public void Store_One_Bag_When_Not_All_Cabinets_Full_Return_Ticket()
        {
            var robot = new Robot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var bag = new Bag();
            var ticket = robot.Store(bag);
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void Pick_One_Bag_When_Cabinet_Has_My_Bag_And_Give_Valid_Ticket()
        {
            var robot = new Robot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var bag = new Bag();
            var ticket = robot.Store(bag);
            Bag pickBag = robot.Pick(ticket);
            Assert.AreEqual(bag,pickBag);
        }

        [TestMethod]
        public void Pick_One_Bag_When_Cabinet_Has_My_Bag_And_Give_InValid_Ticket()
        {
            var robot = new Robot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var bag = new Bag();
            var ticket = robot.Store(bag);
            robot.Pick(ticket);
            Bag returnBag = robot.Pick(ticket);
            Assert.IsNull(returnBag);
        }    

    }


}