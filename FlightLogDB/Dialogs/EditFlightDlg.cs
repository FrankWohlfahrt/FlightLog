using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlightSpot.Database;
using Utils;

namespace FlightLogGUI.Dialogs {
    public partial class EditFlightDlg : Form {

        private fsDatabase m_fsdb = null;
        private int m_UserId = 0;
        private FlightLogEntry m_Flight = null;

        public EditFlightDlg(fsDatabase fsdb, int UserId, FlightLogEntry flight = null) {
            InitializeComponent();
            m_fsdb = fsdb;
            m_UserId = UserId;
            m_Flight = flight;

            updateTakeoffAndLanding();
            updateMaskFromLastFlight();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
            textBoxDate.Text = e.Start.ToShortDateString();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            textBoxDate.Text = e.Start.ToShortDateString();
        }

        private void updateTakeoffAndLanding() {
            List<FlightSpotDBEntry> pList;
            m_fsdb.getFlightSpotList(out pList, 0);

            BindingSource flightspotsTakeoff = new BindingSource();
            flightspotsTakeoff.DataSource = pList.OrderBy(fs => fs.Name).ToList();

            BindingSource flightspotsLanding = new BindingSource();
            flightspotsLanding.DataSource = pList.OrderBy(fs => fs.Name).ToList();

            comboBoxTakeoff.DataSource = flightspotsTakeoff;
            comboBoxTakeoff.DisplayMember = "Name";
            comboBoxTakeoff.ValueMember = "Name";
            comboBoxLandingZone.DataSource = flightspotsLanding;
            comboBoxLandingZone.DisplayMember = "Name";
            comboBoxLandingZone.ValueMember = "Name";
        }

        private void updateMaskFromLastFlight() {
            if (null == m_Flight) {
                FlightLogEntry lastFlight;
                if (m_fsdb.getLastFlight(out lastFlight, m_UserId) > 0) {
                    textBoxGlider.Text = lastFlight.Glider;
                    textBoxDate.Text = lastFlight.Date.ToShortDateString();
                    comboBoxTakeoff.SelectedValue = lastFlight.LaunchSite;
                    comboBoxLandingZone.SelectedValue = lastFlight.LandingSite;
                }
            }
            else {
                textBoxDate.Text = m_Flight.Date.ToShortDateString();
                textBoxGlider.Text = m_Flight.Glider;
                comboBoxTakeoff.SelectedValue = m_Flight.LaunchSite;
                comboBoxLandingZone.SelectedValue = m_Flight.LandingSite;
                int hours = 0;
                int minutes = 0;
                fsUtils.splitFloatTimeIntoHoursAndMinutes(m_Flight.AirtimeHours, ref hours, ref minutes);
                numericUpDownAirtimeHours.Value = hours;
                numericUpDownAirtimeMinutes.Value = minutes;
                textBoxComment.Text = m_Flight.Comment;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            if (null == m_Flight) {
                insertNewFlight();
            }
            else {
                updateFlight();
            }
        }

        private void insertNewFlight() {
            FlightLogEntry newFlight = new FlightLogEntry();
            newFlight.UserId = m_UserId;
            newFlight.Date = DateTime.Parse(textBoxDate.Text);
            newFlight.Glider = textBoxGlider.Text;
            newFlight.LaunchSite = comboBoxTakeoff.Text;
            newFlight.LandingSite = comboBoxLandingZone.Text;
            int hours = (int)numericUpDownAirtimeHours.Value;
            int minutes = (int)numericUpDownAirtimeMinutes.Value;
            newFlight.AirtimeHours = fsUtils.combineHoursAndMinutesToFloatTime(hours, minutes);
            newFlight.Airtime = fsUtils.prettyPrintTime(newFlight.AirtimeHours);
            newFlight.Comment = textBoxComment.Text;

            if (m_fsdb.insertFlightLog(newFlight) > 0) {
                MessageBox.Show("Der Flug wurde hinzugefügt");
            }
        }

        private void updateFlight() {
            m_Flight.Date = DateTime.Parse(textBoxDate.Text);
            m_Flight.Glider = textBoxGlider.Text;
            m_Flight.LaunchSite = comboBoxTakeoff.Text;
            m_Flight.LandingSite = comboBoxLandingZone.Text;
            int hours = (int)numericUpDownAirtimeHours.Value;
            int minutes = (int)numericUpDownAirtimeMinutes.Value;
            m_Flight.AirtimeHours = fsUtils.combineHoursAndMinutesToFloatTime(hours, minutes);
            m_Flight.Airtime = fsUtils.prettyPrintTime(m_Flight.AirtimeHours);
            m_Flight.Comment = textBoxComment.Text;

            if (m_fsdb.updateFlightLog(m_Flight) > 0) {
                MessageBox.Show("Der Flug wurde geändert");
            }
        }

    }
}
