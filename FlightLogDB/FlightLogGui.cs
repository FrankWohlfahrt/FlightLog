using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlightSpot.Database;
using System.IO;
using Utilities.Grids;

namespace FlightSpotDB
{
    public partial class FlightLogForm : Form
    {
        private const string flightlogDir = "flightlog";
        private const string flightlogDB = "flightlogDB.sqlite";

        private fsDatabase m_fsdb = null; 

        public FlightLogForm()
        {
            InitializeComponent();
            String userpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            String flightLogPath = Path.Combine(userpath, flightlogDir, flightlogDB);
            m_fsdb = new fsDatabase(flightLogPath);
            comboBoxRating.SelectedIndex = 2;

            showFlightsOfUser(1);
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void showFlightsOfUser(int UserId) {
            List<FlightLogEntry> flights;
            m_fsdb.getFlightLogList(out flights, UserId);
            int max = flights.Max(f => f.Date.Year);
            int min = flights.Min(f => f.Date.Year);

            for (int i = max; i != min; i--) {
                createTabPageForFlightList(flights.FindAll(fl => fl.Date.Year == i), i);
            }
         
        }

        private void createTabPageForFlightList(List<FlightLogEntry> flights, int Year) {
            TabPage page = new TabPage();
            page.Text = Year.ToString();

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;

            page.Controls.Add(dgv);
            GridUtils.updateDataSourceKeepPosition(dgv, flights, null, "Comment");

            tabControlMain.TabPages.Add(page);
        }

        private void showFlightSpots(int Rating) {
            List<FlightSpotEntry> spots;
            m_fsdb.getFlightSpotList(out spots, Rating);
            GridUtils.updateDataSourceKeepPosition(dataGridViewSpots, spots, null, 6);
        }

        private void comboBoxRating_SelectedIndexChanged(object sender, EventArgs e) {
            showFlightSpots(comboBoxRating.SelectedIndex);
        }

    }
}
