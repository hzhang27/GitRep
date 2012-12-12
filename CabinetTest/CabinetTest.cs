using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabinetSystem;

namespace CabinetTest
{
    [TestClass]
    public class CabinetTest
    {
        [TestMethod]
        public void Store_One_Bag_When_Cabinet_Full_Return_Null_Ticket()
        {
            int nBox = 0;
            var cabinet = new Cabinet( nBox );
            var bag = new Bag();
            var ticket = cabinet.Store( bag );
            Assert.IsNull( ticket);
        }

        [TestMethod]
        public void Store_One_Bag_When_Cabinet_Has_EmptyBox_Return_Valid_Ticket()
        {
            int nBox = 3;
            var cabinet = new Cabinet( nBox );
            var bag = new Bag();
            var ticket = cabinet.Store( bag );
            Assert.IsNotNull( ticket );
        }

        [TestMethod]
        public void Pick_One_Bag_When_Cabinet_Has_My_Bag_And_Give_Valid_Ticket()
        {
            int nBox = 3;
            var cabinet = new Cabinet(nBox);
            var myBag = new Bag();
            var ticket = cabinet.Store(myBag);

            Bag returnBag = cabinet.Pick(ticket);

            Assert.AreEqual(myBag,returnBag);
        }

        [TestMethod]
        public void Pick_Return_NULL_When_Give_InValid_Ticket()
        {
            int nBox = 3;
            var cabinet = new Cabinet(nBox);
            var myBag = new Bag();
            var ticket = cabinet.Store(myBag);
            cabinet.Pick(ticket);             

            Assert.IsNull(cabinet.Pick(ticket));
        }

 

    }
}
