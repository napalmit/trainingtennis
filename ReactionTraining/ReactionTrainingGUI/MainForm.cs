using Core.ALGORITMO;
using Core.OBJECT;
using DbLinq.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
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
        private Main DB;
        private TBlJob JOB;

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
                var ports = SerialPort.GetPortNames();
                comboSeriale.DataSource = ports;
                comboSeriale.SelectedIndex = 0;

                //valori di default
                comboSensori.SelectedIndex = 1;
                comboDurataWorkout.SelectedIndex = 4;
                comboPausaFrom.SelectedIndex = 5;
                comboPausaTo.SelectedIndex = 7;
                //end
                InitDB();
            }
            catch(Exception ex)
            {
                Console.WriteLine("MainForm.Init: " + ex.Message);
            }
        }

        private void InitDB()
        {
            try
            {
                string ConStr = "Data Source = rt.db;New=False;Version=3";
                var connection = new SQLiteConnection(
                    ConStr
                    );

                connection.Open();

                DB = new Main(connection, new SqliteVendor());

            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.InitDB: " + ex.Message);
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
                    JOB = new TBlJob();
                    JOB.Data = DateTime.Now;
                    JOB.DURatA = durataWorkout;
                    JOB.NumEROSensorI = numeroSensori;
                    JOB.InTeRvAllOMinimO = pausaFrom;
                    JOB.InTeRvAllOMasSimO = pausaTo;

                    Configurator config = new Configurator(comboSeriale.SelectedItem.ToString(), numeroSensori, pausaFrom, pausaTo, durataWorkout * 1000);

                    ThreadStart thread = new ThreadStart(() => FunzionePrincipale(config));
                    Thread t = new Thread(thread);
                    t.Start();

                    panelAttivita.Show();

                    SetLblDurata(durataWorkout);

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
                Console.WriteLine("timespan: " + timespan);  
                lblDurata.Text = timespan.ToString(@"mm\:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.SetLblDurata: " + ex.Message);            
            }
        }

        private void FunzionePrincipale(Configurator aConfig)
        {
            try
            {
                MAIN_THREAD = new MainThread(aConfig);
                MAIN_THREAD.SecondiRimanenti += MAIN_THREAD_SecondiRimanenti; 
                int ritorna = MAIN_THREAD.Start();

                if (ritorna == 1)
                {
                    Console.WriteLine("FINITO");
                    foreach(DatiAcquisiti dato in MAIN_THREAD.LIST_DATI_ACQUISITI)
                    {
                        Console.WriteLine(dato.DifferenceSeconds());
                    }

                    WriteToDB(MAIN_THREAD.LIST_DATI_ACQUISITI);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.FunzionePrincipale: " + ex.Message);
            }
        }

        private void WriteToDB(List<DatiAcquisiti> list)
        {
            try
            {
                string ConStr = "Data Source = rt.db;New=False;Version=3";
                var connection = new SQLiteConnection(
                    ConStr
                    );

                connection.Open();

                var db = new Main(connection, new SqliteVendor());

                db.TBlJob.InsertOnSubmit(JOB);
                db.SubmitChanges();

                var results = from s in db.TBlJob
                              orderby s.Data descending
                              select s;

                TBlJob job = results.ElementAt(0);
                Console.WriteLine("job insert:" + job.ID + "|" + job.Data);
                foreach (DatiAcquisiti dato in list)
                {
                    TBlJobDetail jobDetail = new TBlJobDetail();
                    jobDetail.IDJob = job.ID;
                    jobDetail.SensorE = dato.SENSORE.ID;
                    jobDetail.DataAtTIVAzIonE = dato.DATA_ATTIVAZIONE;
                    jobDetail.DataDiSatTIVAzIonE = dato.DATA_DISATTIVAZIONE;
                    db.TBlJobDetail.InsertOnSubmit(jobDetail);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.WriteToDB: " + ex.Message);
            }
        }

        private void MAIN_THREAD_SecondiRimanenti(int obj)
        {
            Console.WriteLine("ricevo secondi:" + obj);
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
