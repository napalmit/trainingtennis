using Core.ALGORITMO;
using Core.OBJECT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactionTrainingGUI
{
    public partial class MainForm : Form
    {
        private delegate void DelegatoInt(int value);
        public int STATO { get; set; }
        private MainThread MAIN_THREAD;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                STATO = Stato.FERMO;
                panelConfig.Enabled = true;
                panelAttivita.Hide();
                buttonStart.Text = "START";
            }
            catch(Exception ex)
            {
                Console.WriteLine("MainForm.Init: " + ex.Message);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (STATO == Stato.FERMO)
                {
                    int numeroSensori = Int32.Parse(comboSensori.SelectedItem.ToString());
                    int durataWorkout = Int32.Parse(comboDurataWorkout.SelectedItem.ToString());
                    int pausaFrom = Int32.Parse(comboPausaFrom.SelectedItem.ToString());
                    int pausaTo = Int32.Parse(comboPausaTo.SelectedItem.ToString());
                    panelConfig.Enabled = false;
                    STATO = Stato.IN_AZIONE;
                    Configurator config = new Configurator("COM5", numeroSensori, pausaFrom, pausaTo, durataWorkout * 1000);

                    ThreadStart thread = new ThreadStart(() => FunzionePrincipale(config));
                    Thread t = new Thread(thread);
                    t.Start();

                    panelAttivita.Show();

                    SetLblDurata(durataWorkout);
                    /*ThreadStart threadTime = new ThreadStart(() => FunzioneTime(config));
                    Thread time = new Thread(threadTime);
                    time.Start();*/

                    buttonStart.Text = "PAUSA";
                }
                else if (STATO == Stato.IN_AZIONE)
                {
                    //stoppare anche i thread del Core
                    buttonStart.Text = "AVVIA";
                    STATO = Stato.PAUSA;
                    MAIN_THREAD.PauseThread();
                }
                else if (STATO == Stato.PAUSA)
                {
                    //riattivare anche i thread del Core
                    buttonStart.Text = "PAUSA";
                    STATO = Stato.IN_AZIONE;
                    MAIN_THREAD.RestartThread();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.buttonStart_Click: " + ex.Message);
                MessageBox.Show("Selezionare un valore");                
            }
        }

        private void SetLblDurata(int seconds)
        {
            try
            {
                var timespan = TimeSpan.FromSeconds(seconds);
                lblDurata.Text = timespan.ToString(@"mm\:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.SetLblDurata: " + ex.Message);            
            }
        }

        /*private void FunzioneTime(Configurator config)
        {
            try
            {
                bool cycle = true;
                while (cycle)
                {
                    pauseThreadTime.WaitOne(Timeout.Infinite);
                    Thread.Sleep(1000);
                    SECONDS--;
                    if (SECONDS == 0)
                        cycle = false;
                    else
                        this.Invoke(new DelegatoInt(SetLblDurata), SECONDS);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.FunzioneTime: " + ex.Message);
            }
        }*/

        private void FunzionePrincipale(Configurator aConfig)
        {
            try
            {
                MAIN_THREAD = new MainThread(aConfig);
                MAIN_THREAD.SecondiRimanenti += MAIN_THREAD_SecondiRimanenti; 
                int ritorna = MAIN_THREAD.Start();

                if (ritorna == 1)
                {
                    //end
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.FunzionePrincipale: " + ex.Message);
            }
        }

        private void MAIN_THREAD_SecondiRimanenti(int obj)
        {
            this.Invoke(new DelegatoInt(SetLblDurata), obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MAIN_THREAD.CloseSerialPort();
        }

        
    }

    public static class Stato
    {
        public static int FERMO = 0;
        public static int IN_AZIONE = 1;
        public static int PAUSA = 2;
    }
}
