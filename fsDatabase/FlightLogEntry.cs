using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;

namespace FlightSpot.Database {

    public class FlightLogEntry {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Glider { get; set; }
        public string LaunchSite { get; set; }
        public string LandingSite { get; set; }
        public Single AirtimeHours { get; set; }
        public string Comment { get; set; }
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
