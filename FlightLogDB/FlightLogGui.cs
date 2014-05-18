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
using System.Text.RegularExpressions;
using System.Diagnostics;
using FlightLogGUI.Dialogs;
using Utils;

namespace FlightLogGUI
{
    public partial class FlightLogForm : Form
    {
        private const string flightlogDir = "flightlog";
        private const string flightlogDB = "flightlogDB.sqlite";

        private const int USER = 1;

        private fsDatabase m_fsdb = null;

        #region create & destroy
        /// <summary>
        /// constructor
        /// </summary>
        public FlightLogForm()
        {
            InitializeComponent();
            String userpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            String flightLogPath = Path.Combine(userpath, flightlogDir, flightlogDB);
            m_fsdb = new fsDatabase(flightLogPath);
            comboBoxRating.SelectedIndex = 2;

            showFlightsOfUser(USER);
        }

        /// <summary>
        /// quit the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e) {
            m_fsdb.Dispose();
            this.Close();
        }
        #endregion

        /// <summary>
        /// show all flights of a user
        /// </summary>
        /// <param name="UserId"></param>
        private void showFlightsOfUser(int UserId) {
            tabControlFlights.TabPages.Clear();

            List<FlightLogEntry> flights;
            m_fsdb.getFlightLogList(out flights, UserId);
            int max = flights.Max(f => f.Date.Year);
            int min = flights.Min(f => f.Date.Year);

            for (int i = max; i != min; i--) {
                createTabPageForFlightList(flights.FindAll(fl => fl.Date.Year == i), i);
            }
        }

        /// <summary>
        /// create a new tab and populate it with the flights of a year
        /// </summary>
        /// <param name="flights"></param>
        /// <param name="Year"></param>
        private void createTabPageForFlightList(List<FlightLogEntry> flights, int Year) {
            TabPage page = new TabPage();

            Single TotalAirTime = 0;
            foreach (FlightLogEntry fle in flights) {
                TotalAirTime += fle.AirtimeHours;
            }

            page.Text = Year.ToString() + " / " + fsUtils.prettyPrintTime(TotalAirTime);

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.CellDoubleClick += new DataGridViewCellEventHandler(dgv_CellDoubleClick);
            page.Controls.Add(dgv);
            tabControlFlights.TabPages.Add(page);

            DataTable table = TableConverter.flightLogsToDataTable(flights);
            GridUtils.updateDataSourceKeepPosition(dgv, table, null, "Kommentar");
        }

        /// <summary>
        /// edit flight log entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (sender is DataGridView) {
                DataGridView dgv = (DataGridView)sender;
                string idStr = dgv.CurrentRow.Cells[0].Value.ToString();
                int id;
                if (Int32.TryParse(idStr, out id)) {
                    FlightLogEntry flEntry;
                    if (m_fsdb.getFlightLogById(out flEntry, id) > 0) {
                        EditFlightDlg dlg = new EditFlightDlg(m_fsdb, USER, flEntry);
                        dlg.ShowDialog();
                        showFlightsOfUser(USER);
                    }
                }
            }
        }

        /// <summary>
        /// populate grid with flightspots
        /// </summary>
        /// <param name="Rating"></param>
        private void showFlightSpots(int Rating) {
            List<FlightSpotDBEntry> spots;
            m_fsdb.getFlightSpotList(out spots, Rating);
            List<String> visibleColumns;
            List<FlightSpotGui> display;
            TableConverter.flightSpotTable(spots, out visibleColumns, out display);
            GridUtils.updateDataSourceKeepPosition(dataGridViewSpots, display, visibleColumns, "Name");
        }

        /// <summary>
        /// rating changed, show flightspots matching the filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxRating_SelectedIndexChanged(object sender, EventArgs e) {
            showFlightSpots(comboBoxRating.SelectedIndex);
        }

        public string StripHTML(string HTMLText) {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            return reg.Replace(HTMLText, "");
        }

        /// <summary>
        /// show all informations about the flightspot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSpots_SelectionChanged(object sender, EventArgs e) {
            var obj = dataGridViewSpots.CurrentRow.DataBoundItem;
            if (obj is FlightSpotGui) {
                labelWeatherLink.Text = (obj as FlightSpotGui).WindFinderLink;
                richTextBoxAirspaceInfo.Text = StripHTML((obj as FlightSpotGui).AirspaceInfo);
            }
        }

        /// <summary>
        /// open the link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenWeatherUrl_Click(object sender, EventArgs e) {
            Process.Start(labelWeatherLink.Text);
        }

        /// <summary>
        /// save changed additional info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e) {
            var obj = dataGridViewSpots.CurrentRow.DataBoundItem;
            if (obj is FlightSpotGui) {
                (obj as FlightSpotGui).AirspaceInfo = richTextBoxAirspaceInfo.Text;
                m_fsdb.updateFlightSpotAdditionalInfo((obj as FlightSpotGui).ID, richTextBoxAirspaceInfo.Text);
            }
        }

        /// <summary>
        /// add a flight to the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hinzufügenToolStripMenuItem_Click(object sender, EventArgs e) {
            EditFlightDlg dlg = new EditFlightDlg(m_fsdb, USER);
            dlg.ShowDialog();
            showFlightsOfUser(USER);
        }

    }
}
