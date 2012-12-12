using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetTest
{
    /// <summary>
    /// Summary description for SuperRobotTest
    /// </summary>
    [TestClass]
    public class SuperRobotTest
    {
        [TestMethod]
        public void Store_One_Bag_When_All_Cabinets_Full_Return_Null_Ticket()
        {
            var superRobot = new SuperRobot(new List<Cabinet> { new Cabinet(0), new Cabinet(0), new Cabinet(0) });
            var ticket = superRobot.Store(new Bag());
            Assert.IsNull(ticket);
        }
        [TestMethod]
        public void Store_One_Bag_When_Not_All_Cabinets_Full_Return_Ticket()
        {
            var superRobot = new SuperRobot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var ticket = superRobot.Store(new Bag());
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void Pick_One_Bag_When_Cabinet_Has_My_Bag_And_Give_Valid_Ticket()
        {
            var superRobot = new SuperRobot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            Bag bag = new Bag();
            var ticket = superRobot.Store(bag);
            Bag pickBag = superRobot.Pick(ticket);
            Assert.AreEqual(bag, pickBag);
        }

        [TestMethod]
        public void Pick_One_Bag_When_Cabinet_Has_My_Bag_And_Give_InValid_Ticket()
        {
            var superRobot = new SuperRobot(new List<Cabinet> { new Cabinet(0), new Cabinet(1), new Cabinet(0) });
            var ticket = superRobot.Store(new Bag());
            superRobot.Pick(ticket);
            Bag returnBag = superRobot.Pick(ticket);
            Assert.IsNull(returnBag);
        }
        [TestMethod]
        public void StoreBag_In_Highest_Vacancy_Rate_Cabinet()
        {
            var superRobot = new SuperRobot(new List<Cabinet> { new Cabinet(5), new Cabinet(2), new Cabinet(2) });
            superRobot.Store(new Bag());
            superRobot.Store(new Bag());
            Assert.AreEqual(4, superRobot.GetCabinet(0).RemainingEmptyBoxCount);
            Assert.AreEqual(1, superRobot.GetCabinet(1).RemainingEmptyBoxCount);
        } 
    }
}
