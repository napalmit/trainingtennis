using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OBJECT
{
    public class Sensore
    {
        public Sensore()
        {
            STATO = StatoSensore.DISATTIVO;
        }
        public int ID { get; set; }
        public string NAME { get; set; }
        public int STATO { get; set; }

        public void CaricaComandi(List<string> aComandi)
        {
            CmdAccendi = aComandi.ElementAt(0);
            RitornoAccendi = aComandi.ElementAt(1);
            CmdSpegni = aComandi.ElementAt(2);
            RitornoSpegni = aComandi.ElementAt(3);
            CmdIngresso = aComandi.ElementAt(4);
            IngressoAlto = aComandi.ElementAt(5);
            IngressoBasso = aComandi.ElementAt(6);
        }

        private string CmdAccendi { get; set; }
        private string RitornoAccendi { get; set; }
        private string CmdSpegni { get; set; }
        private string RitornoSpegni { get; set; }
        private string CmdIngresso { get; set; }
        public string IngressoAlto { get; private set; }
        public string IngressoBasso { get; private set; }

        public string Accendi()
        {
            return CmdAccendi;
        }
        public string Spegni()
        {
            return CmdSpegni;
        }
        public string Ingresso()
        {
            return CmdIngresso;
        }

    }
}
