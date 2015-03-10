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

        public event Action<string> RicevoDato;

        public ReleUSB(string comPort)
        {
            COM = comPort;
        }

        public void Connect()
        {
            try
            {
                SERIAL = new SerialPort();
                SERIAL.PortName = COM;
                SERIAL.BaudRate = 115200;
                SERIAL.Parity = Parity.None;
                SERIAL.DataBits = 8;
                SERIAL.StopBits = StopBits.One;
                SERIAL.ReadTimeout = 500;
                SERIAL.WriteTimeout = 500;
                SERIAL.Handshake = Handshake.None;
                SERIAL.DataReceived += new SerialDataReceivedEventHandler(mySerialPort_DataReceived);
                try
                {
                    Console.WriteLine("APRO SERIAL");
                    SERIAL.Open();
                    Console.WriteLine("APERTA SERIAL");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ReleUSB.Connect : " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReleUSB.Connect: " + ex.Message);
                Console.WriteLine("ReleUSB.Connect: " + ex.StackTrace);
            }
        }

        private void SERIAL_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        }

        private void mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            try
            {
                string s = SERIAL.ReadExisting();
                RicevoDato.Invoke(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReleUSB.mySerialPort_DataReceived:" + ex.Message);
            }

        }

        public void InviaComando(string command)
        {
            try
            {
                //Console.WriteLine("INVIO:" + command);
                Clean();
                SERIAL.Write(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReleUSB.InviaComando:" + ex.Message);
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
            }
        }

        public void Close()
        {
            try
            {
                SERIAL.Close();
            }
            catch (Exception ex)
            {
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
            }

            return lista;
        }
    }
}
