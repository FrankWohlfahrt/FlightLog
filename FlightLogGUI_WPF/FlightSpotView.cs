using FlightSpot.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FlightLogGUI_WPF {
    /// <summary>
    /// class for database access
    /// </summary>
    public class FlightSpotDisplay {
        [DisplayName("Name")]
        public String Name { get; set; }

        [DisplayName("Ort")]
        public String City { get; set; }

        [DisplayName("Land")]
        public String Country { get; set; }

        [DisplayName("Höhe")]
        public String Height { get; set; }

        [DisplayName("Beschreibung")]
        [AutoSizeColumn]
        public String Description { get; set; }

        [DisplayName("Windrichtung")]
        public String WindDirection { get; set; }

        [DisplayName("Bewertung")]
        public String Rating { get; set; }
    }


    public class FlightSpotView {

        private fsDatabase m_fsdb = null;

        public FlightSpotView(fsDatabase fsdb) {
            m_fsdb = fsdb;
        }

        private string getRating(int Rating) {
            string result = string.Empty;
            for (int i = 1; i <= Rating; i++) {
                result += '*';
            }
            return result;
        }

        public List<FlightSpotDisplay> getData(int Rating) {
            List<FlightSpotDisplay> displaydata = new List<FlightSpotDisplay>();
            List<FlightSpotDBEntry> spots;
            m_fsdb.getFlightSpotList(out spots, Rating);
            foreach (FlightSpotDBEntry db in spots) {
                FlightSpotDisplay display = new FlightSpotDisplay();
                display.Name = db.Name;
                display.City = db.Name;
                display.Country = db.City;
                display.Height = db.Height;
                display.Description = db.Description;
                display.WindDirection = db.WindDirection;
                display.Rating = getRating(db.Rating);

                displaydata.Add(display);
            }
            return displaydata;
        }

    }
}
