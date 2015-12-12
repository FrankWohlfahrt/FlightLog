using FlightSpot.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Utils;

namespace FlightLogGUI_WPF {
    
    public class FlightLogDisplay {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Datum")]
        public string Date { get; set; }

        [DisplayName("Fluggerät")]
        public string Glider { get; set; }

        [DisplayName("Startplatz")]
        public string LaunchSite { get; set; }

        [DisplayName("Landeplatz")]
        public string LandingSite { get; set; }

        [DisplayName("Kommentar")]
        [AutoSizeColumn]
        public string Comment { get; set; }

        [DisplayName("Flugzeit")]
        public string Airtime { get; set; }
    }

    public static class FlightLogView {

        public static List<FlightLogDisplay> getData(List<FlightLogEntry> logEntries) {
            List<FlightLogDisplay> displaydata = new List<FlightLogDisplay>();
            foreach (FlightLogEntry log in logEntries.OrderByDescending(l => l.Id)) {
                FlightLogDisplay display = new FlightLogDisplay();
                display.Id = log.Id;
                display.Date = String.Format("{0:dd.MM.yy}", log.Date);
                display.Glider = log.Glider;
                display.LaunchSite = log.LaunchSite;
                display.LandingSite = log.LandingSite;
                display.Comment = log.Comment;
                display.Airtime = log.Airtime; 

                displaydata.Add(display);
            }
            return displaydata;
        }

    }

}
