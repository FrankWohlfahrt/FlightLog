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
using Utils;

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

            showFlightsOfUser(USER);
            showFlightSpots(2);
        }

        /// <summary>
        /// close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        /// <summary>
        /// show all flights of a user
        /// </summary>
        /// <param name="UserId"></param>
        private void showFlightsOfUser(int UserId) {
            tabControlFlights.Items.Clear();

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
            Single TotalAirTime = 0;
            foreach (FlightLogEntry fle in flights) {
                TotalAirTime += fle.AirtimeHours;
            }

            TabItem page = new TabItem();
            page.Header = Year.ToString() + " / " + fsUtils.prettyPrintTime(TotalAirTime);

            DataGrid grid = new DataGrid();
            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.VerticalAlignment = VerticalAlignment.Stretch;
            grid.MouseDoubleClick += grid_MouseDoubleClick;
            grid.AutoGeneratingColumn += grid_AutoGeneratingColumn;
            page.Content = grid;

            tabControlFlights.Items.Add(page);

            grid.ItemsSource = flights;
        }

        /// <summary>
        /// change column properties like
        /// - Name
        /// - AutoSize 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            PropertyDescriptor prop = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = prop.DisplayName;
            AutoSizeColumn attrib = new AutoSizeColumn();
            if (prop.Attributes.Contains(attrib)) {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        /// <summary>
        /// handle mouse click into flight datagrids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
        }

        /// <summary>
        /// populate grid with flightspots
        /// </summary>
        /// <param name="Rating"></param>
        private void showFlightSpots(int Rating) {
            FlightSpotView fsview = new FlightSpotView(m_fsdb);
            dataGridFlightSpots.ItemsSource = fsview.getData(Rating);
        }

        /// <summary>
        /// change column properties like
        /// - Name
        /// - AutoSize 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridFlightSpots_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            PropertyDescriptor prop = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = prop.DisplayName;
            AutoSizeColumn attrib = new AutoSizeColumn();
            if (prop.Attributes.Contains(attrib)) {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }
    }
}
