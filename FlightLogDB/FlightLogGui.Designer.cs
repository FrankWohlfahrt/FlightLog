namespace FlightLogGUI
{
    partial class FlightLogForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightLogForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flügeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSpots = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewSpots = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpenWeatherUrl = new System.Windows.Forms.Button();
            this.richTextBoxAirspaceInfo = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxRating = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageFlights = new System.Windows.Forms.TabPage();
            this.tabControlFlights = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textboxWeatherLink = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageSpots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpots)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageFlights.SuspendLayout();
            this.tabControlFlights.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.flügeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // flügeToolStripMenuItem
            // 
            this.flügeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hinzufügenToolStripMenuItem});
            this.flügeToolStripMenuItem.Name = "flügeToolStripMenuItem";
            this.flügeToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.flügeToolStripMenuItem.Text = "Flüge";
            // 
            // hinzufügenToolStripMenuItem
            // 
            this.hinzufügenToolStripMenuItem.Name = "hinzufügenToolStripMenuItem";
            this.hinzufügenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.hinzufügenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.hinzufügenToolStripMenuItem.Text = "hinzufügen";
            this.hinzufügenToolStripMenuItem.Click += new System.EventHandler(this.hinzufügenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1070, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSpots);
            this.tabControlMain.Controls.Add(this.tabPageFlights);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1070, 480);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPageSpots
            // 
            this.tabPageSpots.Controls.Add(this.splitContainer1);
            this.tabPageSpots.Controls.Add(this.panel1);
            this.tabPageSpots.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpots.Name = "tabPageSpots";
            this.tabPageSpots.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpots.Size = new System.Drawing.Size(1062, 454);
            this.tabPageSpots.TabIndex = 0;
            this.tabPageSpots.Text = "Fluggelände";
            this.tabPageSpots.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(190, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewSpots);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textboxWeatherLink);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSave);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOpenWeatherUrl);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxAirspaceInfo);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(869, 448);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridViewSpots
            // 
            this.dataGridViewSpots.AllowUserToAddRows = false;
            this.dataGridViewSpots.AllowUserToDeleteRows = false;
            this.dataGridViewSpots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSpots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpots.Location = new System.Drawing.Point(10, 9);
            this.dataGridViewSpots.Name = "dataGridViewSpots";
            this.dataGridViewSpots.ReadOnly = true;
            this.dataGridViewSpots.Size = new System.Drawing.Size(844, 231);
            this.dataGridViewSpots.TabIndex = 0;
            this.dataGridViewSpots.SelectionChanged += new System.EventHandler(this.dataGridViewSpots_SelectionChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(757, 70);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpenWeatherUrl
            // 
            this.buttonOpenWeatherUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenWeatherUrl.Location = new System.Drawing.Point(757, 29);
            this.buttonOpenWeatherUrl.Name = "buttonOpenWeatherUrl";
            this.buttonOpenWeatherUrl.Size = new System.Drawing.Size(97, 23);
            this.buttonOpenWeatherUrl.TabIndex = 4;
            this.buttonOpenWeatherUrl.Text = "Open";
            this.buttonOpenWeatherUrl.UseVisualStyleBackColor = true;
            this.buttonOpenWeatherUrl.Click += new System.EventHandler(this.buttonOpenWeatherUrl_Click);
            // 
            // richTextBoxAirspaceInfo
            // 
            this.richTextBoxAirspaceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAirspaceInfo.Location = new System.Drawing.Point(10, 70);
            this.richTextBoxAirspaceInfo.Name = "richTextBoxAirspaceInfo";
            this.richTextBoxAirspaceInfo.Size = new System.Drawing.Size(724, 109);
            this.richTextBoxAirspaceInfo.TabIndex = 3;
            this.richTextBoxAirspaceInfo.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Wetterlink";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxRating);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 448);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxRating
            // 
            this.comboBoxRating.FormattingEnabled = true;
            this.comboBoxRating.Items.AddRange(new object[] {
            "keine Bewertung",
            "*",
            "**",
            "***",
            "****"});
            this.comboBoxRating.Location = new System.Drawing.Point(5, 25);
            this.comboBoxRating.Name = "comboBoxRating";
            this.comboBoxRating.Size = new System.Drawing.Size(169, 21);
            this.comboBoxRating.TabIndex = 0;
            this.comboBoxRating.SelectedIndexChanged += new System.EventHandler(this.comboBoxRating_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bewertung";
            // 
            // tabPageFlights
            // 
            this.tabPageFlights.Controls.Add(this.tabControlFlights);
            this.tabPageFlights.Location = new System.Drawing.Point(4, 22);
            this.tabPageFlights.Name = "tabPageFlights";
            this.tabPageFlights.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFlights.Size = new System.Drawing.Size(1062, 454);
            this.tabPageFlights.TabIndex = 1;
            this.tabPageFlights.Text = "Flüge";
            this.tabPageFlights.UseVisualStyleBackColor = true;
            // 
            // tabControlFlights
            // 
            this.tabControlFlights.Controls.Add(this.tabPage1);
            this.tabControlFlights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFlights.Location = new System.Drawing.Point(3, 3);
            this.tabControlFlights.Name = "tabControlFlights";
            this.tabControlFlights.SelectedIndex = 0;
            this.tabControlFlights.Size = new System.Drawing.Size(1056, 448);
            this.tabControlFlights.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1048, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textboxWeatherLink
            // 
            this.textboxWeatherLink.Location = new System.Drawing.Point(10, 34);
            this.textboxWeatherLink.Name = "textboxWeatherLink";
            this.textboxWeatherLink.Size = new System.Drawing.Size(724, 20);
            this.textboxWeatherLink.TabIndex = 6;
            // 
            // FlightLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 526);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FlightLogForm";
            this.Text = "FlightLog";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSpots.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpots)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageFlights.ResumeLayout(false);
            this.tabControlFlights.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSpots;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxRating;
        private System.Windows.Forms.DataGridView dataGridViewSpots;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxAirspaceInfo;
        private System.Windows.Forms.Button buttonOpenWeatherUrl;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolStripMenuItem flügeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hinzufügenToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageFlights;
        private System.Windows.Forms.TabControl tabControlFlights;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textboxWeatherLink;
    }
}

