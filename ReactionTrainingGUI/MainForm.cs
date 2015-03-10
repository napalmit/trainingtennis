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
        public int STATO;
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
                    Configurator config = new Configurator("COM8", serialPort1, numeroSensori, pausaFrom, pausaTo, durataWorkout * 1000);

                    ThreadStart thread = new ThreadStart(() => FunzionePrincipale(config));
                    Thread t = new Thread(thread);
                    t.Start();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.buttonStart_Click: " + ex.Message);
                MessageBox.Show("Selezionare un valore");                
            }
        }

        private void FunzionePrincipale(Configurator aConfig)
        {
            try
            {
                MainThread main = new MainThread(aConfig);
                main.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm.FunzionePrincipale: " + ex.Message);
            }
        }
    }

    public static class Stato
    {
        public static int FERMO = 0;
        public static int IN_AZIONE = 1;
        public static int STOPPATO = 2;
    }
}
