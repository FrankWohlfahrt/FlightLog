using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlightSpot.Database;
using Utils;

namespace FlightLogGUI_WPF.Dialogs {
    /// <summary>
    /// Interaktionslogik für EditFlightDlg.xaml
    /// </summary>
    public partial class EditFlightDlg : Window {

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

        private void updateTakeoffAndLanding() {
            List<FlightSpotDBEntry> pList;
            m_fsdb.getFlightSpotList(out pList, 0);

            comboBoxTakeoff.ItemsSource = pList;
            comboBoxTakeoff.DisplayMemberPath = "Name";
            comboBoxTakeoff.SelectedValuePath = "Name";
            comboBoxLanding.ItemsSource = pList;
            comboBoxLanding.DisplayMemberPath = "Name";
            comboBoxLanding.SelectedValuePath = "Name";
        }

        private void updateMaskFromLastFlight() {
            if (null == m_Flight) {
                FlightLogEntry lastFlight;
                if (m_fsdb.getLastFlight(out lastFlight, m_UserId) > 0) {
                    textBoxGlider.Text = lastFlight.Glider;
                    comboBoxTakeoff.SelectedValue = lastFlight.LaunchSite;
                    comboBoxLanding.SelectedValue = lastFlight.LandingSite;
                }
            }
            else {
                textBoxGlider.Text = m_Flight.Glider;
                comboBoxTakeoff.SelectedValue = m_Flight.LaunchSite;
                comboBoxLanding.SelectedValue = m_Flight.LandingSite;
                int hours = 0;
                int minutes = 0;
                fsUtils.splitFloatTimeIntoHoursAndMinutes(m_Flight.AirtimeHours, ref hours, ref minutes);
                textBoxHours.Text = hours.ToString();
                textBoxMinutes.Text = minutes.ToString();
                textBoxComment.Text = m_Flight.Comment;
            }
            datePicker.SelectedDate = DateTime.Now;
        }

        private void insertNewFlight() {
            FlightLogEntry newFlight = new FlightLogEntry();
            newFlight.UserId = m_UserId;
            newFlight.Date = datePicker.SelectedDate.Value;
            newFlight.Glider = textBoxGlider.Text;
            newFlight.LaunchSite = comboBoxTakeoff.Text;
            newFlight.LandingSite = comboBoxLanding.Text;
            int hours = 0;
            int minutes = 0;
            int.TryParse(textBoxHours.Text, out hours);
            int.TryParse(textBoxMinutes.Text, out minutes);
            newFlight.AirtimeHours = fsUtils.combineHoursAndMinutesToFloatTime(hours, minutes);
            newFlight.Airtime = fsUtils.prettyPrintTime(newFlight.AirtimeHours);
            newFlight.Comment = textBoxComment.Text;

            if (m_fsdb.insertFlightLog(newFlight) > 0) {
                MessageBox.Show("Der Flug wurde hinzugefügt");
            }
        }

        private void updateFlight() {
            m_Flight.Date = datePicker.SelectedDate.Value;
            m_Flight.Glider = textBoxGlider.Text;
            m_Flight.LaunchSite = comboBoxTakeoff.Text;
            m_Flight.LandingSite = comboBoxLanding.Text;
            int hours = 0;
            int minutes = 0;
            int.TryParse(textBoxHours.Text, out hours);
            int.TryParse(textBoxMinutes.Text, out minutes);
            m_Flight.AirtimeHours = fsUtils.combineHoursAndMinutesToFloatTime(hours, minutes);
            m_Flight.Airtime = fsUtils.prettyPrintTime(m_Flight.AirtimeHours);
            m_Flight.Comment = textBoxComment.Text;

            if (m_fsdb.updateFlightLog(m_Flight) > 0) {
                MessageBox.Show("Der Flug wurde geändert");
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e) {
            if (null == m_Flight) {
                insertNewFlight();
            }
            else {
                updateFlight();
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void textBoxHoursMinutes_PreviewKeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumLock:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.Back:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }


    }
}
