using System.Collections.Generic;
using CabinetSystem;

namespace CabinetTest
{
    public class SmartRobot:Robot
    {
        public SmartRobot(List<Cabinet> cabinets) : base(cabinets)
        {
        }

        protected override Cabinet GeSuitableCabinet()
        {
            Cabinet cabinetFittest = m_Cabintes[0];
            foreach (Cabinet cabinet in m_Cabintes)
            {
                if(cabinet.RemainingEmptyBoxCount > cabinetFittest.RemainingEmptyBoxCount )
                {
                    cabinetFittest = cabinet;
                }
            }
            return cabinetFittest;

        }
    }

}