using System.Collections.Generic;

namespace CabinetSystem
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Cabinet
    {
        public Cabinet(int totalBoxCountNumber)
        {
            m_TotalBoxCount = m_RemainingEmptyBoxCount = totalBoxCountNumber;
            m_Box = new Dictionary<Ticket, Bag>();          
        }

        public int RemainingEmptyBoxCount
        {
            get { return m_RemainingEmptyBoxCount; }
        }

        public bool IsFull()
        {
            return m_RemainingEmptyBoxCount == 0;
        }

        public Ticket Store( Bag bag )
        {
            if ( IsFull() )
            {
                return null;
            }
            Ticket ticket = new Ticket();
            m_Box.Add(ticket,bag);
            m_RemainingEmptyBoxCount--;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (!m_Box.ContainsKey(ticket))
                return null;
            Bag returnBag = m_Box[ticket];
            m_Box.Remove(ticket);
            m_RemainingEmptyBoxCount++;
            return returnBag;
        }

        public double GetVancancyRate()
        {
            if (m_TotalBoxCount != 0)
                return (double)m_RemainingEmptyBoxCount / m_TotalBoxCount;
            return 0.0;
        }

        private int m_RemainingEmptyBoxCount;
        private int m_TotalBoxCount;
        private Dictionary<Ticket, Bag> m_Box;
    }
}

