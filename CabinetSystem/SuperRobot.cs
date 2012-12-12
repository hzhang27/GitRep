using System;
using System.Collections.Generic;
using CabinetSystem;

namespace CabinetTest
{
    public class SuperRobot:Robot
    {
        public SuperRobot(List<Cabinet> cabinets)
            : base(cabinets)
        {

        }
        protected override Cabinet GeSuitableCabinet()
        {
            Cabinet cabinetAvailable = m_Cabintes[0];
            foreach (Cabinet cabinet in m_Cabintes)
            {
                if (cabinet.GetVancancyRate() > cabinetAvailable.GetVancancyRate())
                {
                    cabinetAvailable = cabinet;
                }
            }
            return cabinetAvailable;
        }
    }
}