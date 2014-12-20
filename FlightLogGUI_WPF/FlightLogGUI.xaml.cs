using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSpot.Database;
using Utilities.Grids;
using System.ComponentModel;

namespace FlightLogGUI_WPF {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class FlightLogGui : Window {

        private const string flightlogDir = "flightlog";
        private const string flightlogDB = "flightlogDB.sqlite";

        private const int USER = 1;

        private fsDatabase m_fsdb = null;

        public FlightLogGui() {
            InitializeComponent();

            String userpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            String flightLogPath = System.IO.Path.Combine(userpath, flightlogDir, flightlogDB);
            m_fsdb = new fsDatabase(flightLogPath);

            //showFlightsOfUser(USER);
            showFlightSpots(2);
        }

        /// <summary>
        /// show all flights of a user
        /// </summary>
        /// <param name="UserId"></param>
        //private void showFlightsOfUser(int UserId) {
        //    tabControlFlights.TabPages.Clear();

        //    List<FlightLogEntry> flights;
        //    m_fsdb.getFlightLogList(out flights, UserId);
        //    int max = flights.Max(f => f.Date.Year);
        //    int min = flights.Min(f => f.Date.Year);

        //    for (int i = max; i != min; i--) {
        //        createTabPageForFlightList(flights.FindAll(fl => fl.Date.Year == i), i);
        //    }
        //}

        /// <summary>
        /// populate grid with flightspots
        /// </summary>
        /// <param name="Rating"></param>
        private void showFlightSpots(int Rating) {
            List<FlightSpotDBEntry> spots;
            m_fsdb.getFlightSpotList(out spots, Rating);
            dataGridFlightSpots.ItemsSource = spots;
        }

        private void dataGridFlightSpots_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            if (((PropertyDescriptor)e.PropertyDescriptor).IsBrowsable == false)
                e.Cancel = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
