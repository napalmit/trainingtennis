﻿using Core.OBJECT;
using Core.PROGETTIHWSW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.ALGORITMO
{
    public class MainThread
    {
        private ReleUSB RELE;
        private Configurator CONFIGURATOR;
        private List<Sensore> LIST_SENSOR = new List<Sensore>();
        private EventWaitHandle waitHandle;
        private Random RND = new Random();
        private Sensore SENSORE_USCITO;
        private bool CYCLE = true;       
        private DatiAcquisiti DATO_ACQUISITO;

        public List<DatiAcquisiti> LIST_DATI_ACQUISITI { get; private set; }

        private ManualResetEvent mainThread = new ManualResetEvent(true);
        private ManualResetEvent timeThread = new ManualResetEvent(true);
        private ManualResetEvent secondoThread = new ManualResetEvent(true);

        private int SECONDS;

        public event Action<int> SecondiRimanenti;

        public MainThread(Configurator aConfigurator)
        {
            CONFIGURATOR = aConfigurator;
            Init();
            //Start();    
        }

        public int Start()
        {

            try
            {
                /*
                 * creazione di due thread: 
                 * il primo thread si occuperà di definire quale sarà i ltempo di attesa e quale sarà il prossimo sensore ad attivarsi,
                 * finita l'attesa chiamerà la funzione Accendi sul sensore da attivare, settando anche il suo stato, si metterà in sleep svegliando il secondo thread
                 * 
                 * il secondo thread si occupa di aspettare una risposta dall'ingresso del sensore attivo, finchè la risposta sarà bassa nn succederà nulla,
                 * nel momento in cui la risposta sarà alta allora setterà lo stato del sensore, spegnerà il ralay, si metterà in sleep e risvegliarà il primo thread
                 * 
                 * 
                 */
                LIST_DATI_ACQUISITI = new List<DatiAcquisiti>();
                waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                Console.WriteLine("START");
                SECONDS = CONFIGURATOR.DURATA;
                ThreadStart timeThread = new ThreadStart(TimeThread);
                Thread time = new Thread(timeThread);
                time.Start();
                while (CYCLE)
                {
                    mainThread.WaitOne(Timeout.Infinite);
                    int pausa = RND.Next(CONFIGURATOR.VALORE_MINORE_PAUSA, CONFIGURATOR.VALORE_MAGGIORE_PAUSA);
                    Console.WriteLine("valore attesa: " + pausa + " ms");
                    Thread.Sleep(pausa);
                    int sensoreUscito = RND.Next(0, LIST_SENSOR.Count - 1);
                    Console.WriteLine("sensoreUscito: " + sensoreUscito);
                    SENSORE_USCITO = LIST_SENSOR.ElementAt(sensoreUscito);
                    SENSORE_USCITO.STATO = StatoSensore.ATTIVO;
                    RELE.InviaComando(SENSORE_USCITO.Accendi());
                    DATO_ACQUISITO = new DatiAcquisiti(SENSORE_USCITO);
                    ThreadStart secondoThread = new ThreadStart(FunzioneSecondoThread);
                    Thread t = new Thread(secondoThread);
                    t.Start();

                    if (waitHandle.WaitOne(Timeout.Infinite, true))
                    {
                        Console.WriteLine("timeout");
                    }

                    Console.WriteLine("riparto");
                }
                Console.WriteLine("finito");

                foreach (Sensore sensore in LIST_SENSOR)
                {
                    sensore.Accendi();
                }

                Thread.Sleep(200);

                foreach (Sensore sensore in LIST_SENSOR)
                {
                    sensore.Spegni();
                }

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainThread.Start: " + ex.Message);
                return -1;
            }
        }

        private void FunzioneSecondoThread()
        {
            try
            {
                bool schiacciato = true;
                Console.WriteLine("in attesa di essere schiacciato");
                while (schiacciato)
                {
                    secondoThread.WaitOne(Timeout.Infinite);
                    RELE.InviaComando(SENSORE_USCITO.Ingresso());
                    string ricezione = RELE.RiceviDati();
                    Console.WriteLine("ricezione: " + ricezione);
                    if (ricezione.Equals(SENSORE_USCITO.IngressoAlto))
                    {
                        SENSORE_USCITO.STATO = StatoSensore.DISATTIVO;
                        RELE.InviaComando(SENSORE_USCITO.Spegni());
                        SENSORE_USCITO = null;
                        schiacciato = false;
                        DATO_ACQUISITO.DATA_DISATTIVAZIONE = DateTime.Now;
                        LIST_DATI_ACQUISITI.Add(DATO_ACQUISITO);
                        DATO_ACQUISITO = null;
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
                waitHandle.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainThread.FunzioneSecondoThread: " + ex.Message);
            }    
        }

        private void TimeThread()
        {
            try
            {
                bool cycle = true;
                DateTime dataStop = DateTime.Now.AddMilliseconds(CONFIGURATOR.DURATA);
                while (cycle)
                {
                    timeThread.WaitOne(Timeout.Infinite);
                    Thread.Sleep(1000);
                    SECONDS--;
                    if (SECONDS == 0)
                    {
                        cycle = false;
                        CYCLE = false;
                    }                        
                    else
                    {
                        //invio un evento con SECONDS rimanenti COME PARAMETRO
                        SecondiRimanenti.Invoke(SECONDS);
                    }
                        //this.Invoke(new DelegatoInt(SetLblDurata), SECONDS);
                    /*if (DateTime.Now.CompareTo(dataStop) > 0)
                    {
                        cicla = false;
                        CYCLE = false;
                    }
                    else
                        Thread.Sleep(1000);*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainThread.TimeThread: " + ex.Message);
            }
        }

        private void Init()
        {
            try
            {
                #region relay
                RELE = new ReleUSB(CONFIGURATOR.COM_PORT, CONFIGURATOR.SERIAL_PORT);
                RELE.Connect();
                #endregion

                #region sensori
                for (int i = 1; i <= CONFIGURATOR.NUMBER_OF_SENSOR; i++)
                {
                    Sensore sensore = new Sensore();
                    sensore.ID = i;
                    sensore.NAME = "sensore numero " + i;
                    sensore.STATO = StatoSensore.DISATTIVO;
                    sensore.CaricaComandi(RELE.GetCmdAndResponse(i));
                    sensore.Spegni();
                    LIST_SENSOR.Add(sensore);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainThread.Init: " + ex.Message);
            }    
        }

        public void PauseThread()
        {
            mainThread.Reset();
            secondoThread.Reset();
            timeThread.Reset();
        }

        public void RestartThread()
        {
            mainThread.Set();
            secondoThread.Set();
            timeThread.Set();
        }
    }
}
