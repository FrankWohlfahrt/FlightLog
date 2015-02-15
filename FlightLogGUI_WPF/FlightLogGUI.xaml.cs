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
using FlightLogGUI_WPF.Dialogs;

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
        private void MenuItemClose_Click(object sender, RoutedEventArgs e) {
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
            SolidColorBrush brush = new SolidColorBrush(Colors.LightBlue);
            grid.AlternatingRowBackground = brush;
            grid.AlternationCount = 2;
            grid.IsReadOnly = true;
            grid.MouseDoubleClick += new MouseButtonEventHandler(dgv_CellDoubleClick);
            page.Content = grid;

            tabControlFlights.Items.Add(page);
            grid.ItemsSource = FlightLogView.getData(flights);
        }

        /// <summary>
        /// edit flight log entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgv_CellDoubleClick(object sender, MouseButtonEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is DataGridRow)) {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            if (dep is DataGridRow) {
                DataGridRow dataGridRow = dep as DataGridRow;

                if (dataGridRow.IsSelected) {
                    if (dataGridRow.Item is FlightLogDisplay) {
                        int id = ((FlightLogDisplay)dataGridRow.Item).Id;
                            FlightLogEntry flEntry;
                            if (m_fsdb.getFlightLogById(out flEntry, id) > 0) {
                                EditFlightDlg dlg = new EditFlightDlg(m_fsdb, USER, flEntry);
                                dlg.ShowDialog();
                                showFlightsOfUser(USER);
                            }
                    }
                }
            }            
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

        /// <summary>
        /// add a new flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddFlight_Click(object sender, RoutedEventArgs e) {
            EditFlightDlg dlg = new EditFlightDlg(m_fsdb, USER);
            dlg.ShowDialog();
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
