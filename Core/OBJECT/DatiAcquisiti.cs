using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.OBJECT
{
    public class DatiAcquisiti
    {
        public DatiAcquisiti(Sensore aSensore)
        {
            SENSORE = aSensore;
            DATA_ATTIVAZIONE = DateTime.Now;
        }
        public Sensore SENSORE { get; private set; }
        public DateTime DATA_ATTIVAZIONE { get; private set; }
        public DateTime DATA_DISATTIVAZIONE { get; set; }
        public double DifferenceSeconds()
        {
            return (DATA_DISATTIVAZIONE - DATA_ATTIVAZIONE).TotalSeconds;
        }
    }
}
