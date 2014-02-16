using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace FlightSpot.Database {
    
    public class FlightSpotEntry {
        public String Name { get; set; }
        public String Country { get; set; }
        public String PostCode { get; set; }
        public String MinHeight { get; set; }
        public String Description { get; set; }
        public String Coordinates { get; set; }
        public String WindFinderLink { get; set; }
        public String WindDirection { get; set; }

        public int ID { get; set; }
        public int Rating { get; set; }

        /// <summary>
        /// fill from sql reader
        /// </summary>
        /// <param name="reader"></param>
        public void fromSqlReader(DbDataReader reader) {
            Name = DBConvert.ToString(reader["Name"], "");
            Country = DBConvert.ToString(reader["Country"], "");
            PostCode = DBConvert.ToString(reader["City"], "");
            MinHeight = DBConvert.ToString(reader["Height"], "");
            Description = DBConvert.ToString(reader["Description"], "");
            Coordinates = DBConvert.ToString(reader["Coordinates"], "");
            WindFinderLink = DBConvert.ToString(reader["windfinderlink"], "");
            WindDirection = DBConvert.ToString(reader["winddirection"], "");

            ID = DBConvert.ToInt32(reader["Id"], 0);
            Rating = DBConvert.ToInt32(reader["Rating"], 0);
        }
    }

}
