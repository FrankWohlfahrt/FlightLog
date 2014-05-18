namespace FlightLogGUI.Dialogs {
    partial class EditFlightDlg {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.textBoxGlider = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.comboBoxTakeoff = new System.Windows.Forms.ComboBox();
            this.comboBoxLandingZone = new System.Windows.Forms.ComboBox();
            this.numericUpDownAirtimeHours = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownAirtimeMinutes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAirtimeHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAirtimeMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxGlider
            // 
            this.textBoxGlider.Location = new System.Drawing.Point(98, 59);
            this.textBoxGlider.Name = "textBoxGlider";
            this.textBoxGlider.Size = new System.Drawing.Size(290, 20);
            this.textBoxGlider.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fluggerät";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(34, 247);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Speichern";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(446, 247);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Schließen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kommentar";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(98, 191);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(290, 20);
            this.textBoxComment.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Startplatz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Landeplatz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Datum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Flugzeit";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(420, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 10;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(98, 26);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(290, 20);
            this.textBoxDate.TabIndex = 11;
            // 
            // comboBoxTakeoff
            // 
            this.comboBoxTakeoff.FormattingEnabled = true;
            this.comboBoxTakeoff.Location = new System.Drawing.Point(98, 92);
            this.comboBoxTakeoff.Name = "comboBoxTakeoff";
            this.comboBoxTakeoff.Size = new System.Drawing.Size(290, 21);
            this.comboBoxTakeoff.TabIndex = 12;
            // 
            // comboBoxLandingZone
            // 
            this.comboBoxLandingZone.FormattingEnabled = true;
            this.comboBoxLandingZone.Location = new System.Drawing.Point(98, 125);
            this.comboBoxLandingZone.Name = "comboBoxLandingZone";
            this.comboBoxLandingZone.Size = new System.Drawing.Size(290, 21);
            this.comboBoxLandingZone.TabIndex = 13;
            // 
            // numericUpDownAirtimeHours
            // 
            this.numericUpDownAirtimeHours.Location = new System.Drawing.Point(98, 159);
            this.numericUpDownAirtimeHours.Name = "numericUpDownAirtimeHours";
            this.numericUpDownAirtimeHours.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownAirtimeHours.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "h";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "min";
            // 
            // numericUpDownAirtimeMinutes
            // 
            this.numericUpDownAirtimeMinutes.Location = new System.Drawing.Point(179, 159);
            this.numericUpDownAirtimeMinutes.Name = "numericUpDownAirtimeMinutes";
            this.numericUpDownAirtimeMinutes.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownAirtimeMinutes.TabIndex = 16;
            // 
            // EditFlightDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 294);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownAirtimeMinutes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownAirtimeHours);
            this.Controls.Add(this.comboBoxLandingZone);
            this.Controls.Add(this.comboBoxTakeoff);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGlider);
            this.Name = "EditFlightDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flug bearbeiten";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAirtimeHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAirtimeMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.ComboBox comboBoxTakeoff;
        private System.Windows.Forms.ComboBox comboBoxLandingZone;
        private System.Windows.Forms.NumericUpDown numericUpDownAirtimeHours;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownAirtimeMinutes;
    }
}