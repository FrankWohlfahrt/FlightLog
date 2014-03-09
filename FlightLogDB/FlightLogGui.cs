﻿using System;
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

namespace FlightLogGUI
{
    public partial class FlightLogForm : Form
    {
        private const string flightlogDir = "flightlog";
        private const string flightlogDB = "flightlogDB.sqlite";

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

            showFlightsOfUser(1);
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
            page.Text = Year.ToString();

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            page.Controls.Add(dgv);
            tabControlMain.TabPages.Add(page);

            DataTable table = TableConverter.flightLogsToDataTable(flights);
            GridUtils.updateDataSourceKeepPosition(dgv, table, null, "Kommentar");
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
                richTextBox1.Text = StripHTML((obj as FlightSpotGui).AirspaceInfo);

                List<AdditionalInfos> InfoList;
                m_fsdb.getAdditionalInfoList(out InfoList, (obj as FlightSpotGui).Hash);
                StringBuilder sb = new StringBuilder();
                foreach (AdditionalInfos info in InfoList) {
                    sb.Append(info.Name);
                    sb.Append(Environment.NewLine);
                    sb.Append(info.Data);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                }
                textBoxAirspace.Text = sb.ToString();
            }
        }

    }
}
