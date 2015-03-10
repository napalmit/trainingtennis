using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.PROGETTIHWSW
{
    public class ReleUSB
    {
        private string COM;
        private SerialPort SERIAL;

        public ReleUSB(string comPort, SerialPort serialPort)
        {
            COM = comPort;
            SERIAL = serialPort;
        }

        public void Connect()
        {
            try
            {
                SERIAL.PortName = COM;
                SERIAL.BaudRate = 115200;
                SERIAL.Parity = Parity.None;
                SERIAL.DataBits = 8;
                SERIAL.StopBits = StopBits.One;
                SERIAL.ReadTimeout = 500;
                SERIAL.WriteTimeout = 500;
                SERIAL.Handshake = Handshake.None;
                try
                {
                    SERIAL.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ReleUSB.Connect : " + ex.Message);
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReleUSB.Connect: " + ex.Message);
                Console.WriteLine("ReleUSB.Connect: " + ex.StackTrace);
                throw ex;
            }
        }

        public void InviaComando(string command)
        {
            try
            {
                SERIAL.Write(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReleUSB.InviaComando:" + ex.Message);
                throw ex;
            }
        }

        public string RiceviDati()
        {
            string ret = "";
            try
            {
                ret = SERIAL.ReadExisting();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReleUSB.RiceviDati:" + ex.Message);
                throw ex;
            }
            return ret;
        }

        private void Clean()
        {
            try
            {
                //-----Cleaning the Buffer
                SERIAL.DiscardOutBuffer();
                SERIAL.DiscardInBuffer();
                //-----Finish Cleaning
            }
            catch (Exception ex)
            {
                Console.WriteLine("LedRGBCOM.Clean: " + ex.Message);
                Console.WriteLine("LedRGBCOM.Clean: " + ex.StackTrace);
                throw ex;
            }
        }

        public List<string> GetCmdAndResponse(int sensorNumber)
        {
            List<string> lista = new List<string>();
            try
            {
                if (sensorNumber == 1)
                {
                    lista.Add(Comandi.AccendiRelay1);
                    lista.Add(Risposte.AccendiRelay1);
                    lista.Add(Comandi.SpegniRelay1);
                    lista.Add(Risposte.SpegniRelay1);
                    lista.Add(Comandi.Ingresso1);
                    lista.Add(Risposte.Ingresso1Alto);
                    lista.Add(Risposte.Ingresso1Basso);
                }
                else if (sensorNumber == 2)
                {
                    lista.Add(Comandi.AccendiRelay2);
                    lista.Add(Risposte.AccendiRelay2);
                    lista.Add(Comandi.SpegniRelay2);
                    lista.Add(Risposte.SpegniRelay2);
                    lista.Add(Comandi.Ingresso2);
                    lista.Add(Risposte.Ingresso2Alto);
                    lista.Add(Risposte.Ingresso2Basso);
                }
                else if (sensorNumber == 3)
                {
                    lista.Add(Comandi.AccendiRelay3);
                    lista.Add(Risposte.AccendiRelay3);
                    lista.Add(Comandi.SpegniRelay3);
                    lista.Add(Risposte.SpegniRelay3);
                    lista.Add(Comandi.Ingresso3);
                    lista.Add(Risposte.Ingresso3Alto);
                    lista.Add(Risposte.Ingresso3Basso);
                }
                else if (sensorNumber == 4)
                {
                    lista.Add(Comandi.AccendiRelay4);
                    lista.Add(Risposte.AccendiRelay4);
                    lista.Add(Comandi.SpegniRelay4);
                    lista.Add(Risposte.SpegniRelay4);
                    lista.Add(Comandi.Ingresso4);
                    lista.Add(Risposte.Ingresso4Alto);
                    lista.Add(Risposte.Ingresso4Basso);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReleUSB.GetCmdAndResponse:"+ex.Message);
                throw ex;
            }

            return lista;
        }
    }
}
