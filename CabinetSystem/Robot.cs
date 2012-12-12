using System.Collections.Generic;
using CabinetSystem;

namespace CabinetSystem
{
    public class Robot
    {
        public Robot(List<Cabinet> cabinets)
        {
            m_Cabintes = cabinets;
        }

        public Ticket Store(Bag bag)
        {
            var cabinetAvailable = GeSuitableCabinet();
            return cabinetAvailable.Store(bag);
        }

        protected virtual Cabinet GeSuitableCabinet()
        {
            Cabinet cabinetAvailable = m_Cabintes[0];
            foreach (Cabinet cabinet in m_Cabintes)
            {
                if (!cabinet.IsFull())
                {
                    cabinetAvailable = cabinet;
                    break;
                }
            }
            return cabinetAvailable;
        }

        protected List<Cabinet> m_Cabintes;

        public Bag Pick(Ticket ticket)
        {
            foreach (Cabinet cab in m_Cabintes)
            {
                Bag b = cab.Pick(ticket);
                if (b != null)
                    return b;
            }
            return null;
        }

        public Cabinet GetCabinet(int index)
        {
            return m_Cabintes[index];
        }
    }
}