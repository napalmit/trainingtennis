using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OBJECT
{
    public class Configurator
    {
        public Configurator(string comPort, int numberOfSensor, int valoreMinorePausa, int valoreMaggiorePausa, int durata)
        {
            COM_PORT = comPort;
            NUMBER_OF_SENSOR = numberOfSensor;
            VALORE_MINORE_PAUSA = valoreMinorePausa;
            VALORE_MAGGIORE_PAUSA = valoreMaggiorePausa;
            DURATA = durata;
        }
        public string COM_PORT { get; private set; }
        public int NUMBER_OF_SENSOR { get; private set; }
        public int VALORE_MINORE_PAUSA { get; private set; }
        public int VALORE_MAGGIORE_PAUSA { get; private set; }
        public int DURATA { get; private set; }
    }
}
