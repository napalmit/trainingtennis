﻿namespace ReactionTrainingGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboSensori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDurataWorkout = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPausaFrom = new System.Windows.Forms.ComboBox();
            this.comboPausaTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.comboSeriale = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelAttivita = new System.Windows.Forms.Panel();
            this.lblDurata = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonChiusuraSerial = new System.Windows.Forms.Button();
            this.panelConfig.SuspendLayout();
            this.panelAttivita.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboSensori
            // 
            this.comboSensori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSensori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSensori.FormattingEnabled = true;
            this.comboSensori.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboSensori.Location = new System.Drawing.Point(148, 27);
            this.comboSensori.Name = "comboSensori";
            this.comboSensori.Size = new System.Drawing.Size(71, 28);
            this.comboSensori.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero Sensori:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Durata Workout (s):";
            // 
            // comboDurataWorkout
            // 
            this.comboDurataWorkout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDurataWorkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDurataWorkout.FormattingEnabled = true;
            this.comboDurataWorkout.Items.AddRange(new object[] {
            "60",
            "90",
            "120",
            "150",
            "180",
            "210",
            "240",
            "270",
            "300"});
            this.comboDurataWorkout.Location = new System.Drawing.Point(389, 27);
            this.comboDurataWorkout.Name = "comboDurataWorkout";
            this.comboDurataWorkout.Size = new System.Drawing.Size(71, 28);
            this.comboDurataWorkout.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Intervallo pausa (ms):";
            // 
            // comboPausaFrom
            // 
            this.comboPausaFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPausaFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPausaFrom.FormattingEnabled = true;
            this.comboPausaFrom.Items.AddRange(new object[] {
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.comboPausaFrom.Location = new System.Drawing.Point(632, 27);
            this.comboPausaFrom.Name = "comboPausaFrom";
            this.comboPausaFrom.Size = new System.Drawing.Size(88, 28);
            this.comboPausaFrom.TabIndex = 5;
            // 
            // comboPausaTo
            // 
            this.comboPausaTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPausaTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPausaTo.FormattingEnabled = true;
            this.comboPausaTo.Items.AddRange(new object[] {
            "1200",
            "1400",
            "1600",
            "1800",
            "2000",
            "2200",
            "2400",
            "2600",
            "2800",
            "3000"});
            this.comboPausaTo.Location = new System.Drawing.Point(755, 27);
            this.comboPausaTo.Name = "comboPausaTo";
            this.comboPausaTo.Size = new System.Drawing.Size(88, 28);
            this.comboPausaTo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(726, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "to";
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.comboSeriale);
            this.panelConfig.Controls.Add(this.label6);
            this.panelConfig.Controls.Add(this.label1);
            this.panelConfig.Controls.Add(this.label4);
            this.panelConfig.Controls.Add(this.comboSensori);
            this.panelConfig.Controls.Add(this.comboPausaTo);
            this.panelConfig.Controls.Add(this.comboDurataWorkout);
            this.panelConfig.Controls.Add(this.comboPausaFrom);
            this.panelConfig.Controls.Add(this.label2);
            this.panelConfig.Controls.Add(this.label3);
            this.panelConfig.Location = new System.Drawing.Point(0, 3);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(1007, 81);
            this.panelConfig.TabIndex = 8;
            // 
            // comboSeriale
            // 
            this.comboSeriale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSeriale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSeriale.FormattingEnabled = true;
            this.comboSeriale.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboSeriale.Location = new System.Drawing.Point(873, 30);
            this.comboSeriale.Name = "comboSeriale";
            this.comboSeriale.Size = new System.Drawing.Size(93, 28);
            this.comboSeriale.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(869, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Porta seriale";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(170, 101);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(632, 115);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelAttivita
            // 
            this.panelAttivita.Controls.Add(this.lblDurata);
            this.panelAttivita.Controls.Add(this.label5);
            this.panelAttivita.Location = new System.Drawing.Point(12, 223);
            this.panelAttivita.Name = "panelAttivita";
            this.panelAttivita.Size = new System.Drawing.Size(984, 326);
            this.panelAttivita.TabIndex = 10;
            // 
            // lblDurata
            // 
            this.lblDurata.AutoSize = true;
            this.lblDurata.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurata.Location = new System.Drawing.Point(523, 13);
            this.lblDurata.Name = "lblDurata";
            this.lblDurata.Size = new System.Drawing.Size(82, 31);
            this.lblDurata.TabIndex = 9;
            this.lblDurata.Text = "99:99";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(311, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tempo Residuo:";
            // 
            // buttonChiusuraSerial
            // 
            this.buttonChiusuraSerial.Location = new System.Drawing.Point(929, 90);
            this.buttonChiusuraSerial.Name = "buttonChiusuraSerial";
            this.buttonChiusuraSerial.Size = new System.Drawing.Size(75, 47);
            this.buttonChiusuraSerial.TabIndex = 11;
            this.buttonChiusuraSerial.Text = "CHIUSURA SERIAL";
            this.buttonChiusuraSerial.UseVisualStyleBackColor = true;
            this.buttonChiusuraSerial.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.buttonChiusuraSerial);
            this.Controls.Add(this.panelAttivita);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "MainForm";
            this.Text = "ReactionTrainingGUI";
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.panelAttivita.ResumeLayout(false);
            this.panelAttivita.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSensori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboDurataWorkout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPausaFrom;
        private System.Windows.Forms.ComboBox comboPausaTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelAttivita;
        private System.Windows.Forms.Label lblDurata;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonChiusuraSerial;
        private System.Windows.Forms.ComboBox comboSeriale;
        private System.Windows.Forms.Label label6;
    }
}

