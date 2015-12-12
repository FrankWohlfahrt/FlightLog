using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FlightLogGUI_WPF {
    /// <summary>
    /// Interaktionslogik für FlightSpotControl.xaml
    /// </summary>
    public partial class FlightSpotControl : UserControl {
        public FlightSpotControl() {
            InitializeComponent();
        }

        public void update(FlightSpotDBEntry flEntry) {
            tbWeatherLink.Text = flEntry.WindFinderLink;
            tbSiteInfo.Text = flEntry.airspace;
        }

        private void btnWeatherlink_Click(object sender, RoutedEventArgs e) {
            Process.Start(tbWeatherLink.Text);
        }
    }
}
