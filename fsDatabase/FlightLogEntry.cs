using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;
using System.ComponentModel;

namespace FlightSpot.Database {

    public class FlightLogEntry {

        [DisplayName("Id")]
        [Browsable(true)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [DisplayName("Datum")]
        [Browsable(true)]
        public DateTime Date { get; set; }

        [DisplayName("Fluggerät")]
        [Browsable(true)]
        public string Glider { get; set; }

        [DisplayName("Startplatz")]
        [Browsable(true)]
        public string LaunchSite { get; set; }

        [DisplayName("Landeplatz")]
        [Browsable(true)]
        public string LandingSite { get; set; }

        [Browsable(false)]
        public Single AirtimeHours { get; set; }

        [DisplayName("Kommentar")]
        [Browsable(true)]
        [AutoSizeColumn]
        public string Comment { get; set; }

        [DisplayName("Flugzeit")]
        [Browsable(true)]
        public string Airtime { get; set; }

        /// <summary>
        /// fill from sql reader
        /// </summary>
        /// <param name="reader"></param>
        public void fromSqlReader(DbDataReader reader) {
            Id = DBConvert.ToInt32(reader["ID"], 0);
            UserId = DBConvert.ToInt32(reader["USERID"], 0);
            Date = DBConvert.ToDateTime(reader["DATE"], DateTime.MinValue);
            Glider = DBConvert.ToString(reader["GLIDER"], ""); 
            LaunchSite = DBConvert.ToString(reader["LAUNCHSITE"], "");
            LandingSite = DBConvert.ToString(reader["LANDINGSITE"], "");
            AirtimeHours = DBConvert.ToSingle(reader["AIRTIMEHOURS"], 0);
            Comment = DBConvert.ToString(reader["COMMENT"], "");
            Airtime = DBConvert.ToString(reader["AIRTIME"], "");
        }

    }

}
