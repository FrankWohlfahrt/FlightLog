using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace FlightSpot.Database {

    /// <summary>
    /// class for display in GUI
    /// </summary>
    public class FlightSpotGui {
        public int ID { get; set; }

        public String Name { get; set; }
        public String Land { get; set; }
        public String MinHeight { get; set; }
        public String PostCode { get; set; }
        public String Beschreibung { get; set; }
        public String Windrichtung { get; set; }
        public String Bewertung { get; set; }

        public String WindFinderLink { get; set; }
        public int Rating { get; set; }
        public String AirspaceInfo { get; set; }
        public int Hash { get; set; }

        public FlightSpotGui(FlightSpotDBEntry fsEntry) {
            this.ID = fsEntry.ID;
            this.Name = fsEntry.Name;
            this.Land = fsEntry.Coordinates;
            this.MinHeight = fsEntry.Height.ToString();
            this.PostCode = fsEntry.City;
            this.Beschreibung = fsEntry.Description;
            this.Windrichtung = fsEntry.WindDirection;

            String rating = String.Empty;
            for (int i = 1; i <= fsEntry.Rating; i++) {
                rating += "*";
            }
            this.Bewertung = rating;
            this.WindFinderLink = fsEntry.WindFinderLink;
            this.Rating = fsEntry.Rating;
            this.AirspaceInfo = fsEntry.airspace;
            this.Hash = fsEntry.Hash;
        }
    }

    /// <summary>
    /// class for database access
    /// </summary>
    public class FlightSpotDBEntry {
        public int ID { get; set; }
        public int Hash { get; set; }

        public String Name { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public String Height { get; set; }
        public String Description { get; set; }
        public String Coordinates { get; set; }
        public String WindFinderLink { get; set; }
        public String WindDirection { get; set; }

        public int Rating { get; set; }

        public String SupportsHangglider { get; set; }
        public String SupportsParaglider { get; set; }
        public String Importfile { get; set; }
        public int wind_n { get; set; }
        public int wind_nne { get; set; }
        public int wind_ne { get; set; }
        public int wind_ene { get; set; }
        public int wind_e { get; set; }
        public int wind_ese { get; set; }
        public int wind_se { get; set; }
        public int wind_sse { get; set; }
        public int wind_s { get; set; }
        public int wind_ssw { get; set; }
        public int wind_sw { get; set; }
        public int wind_wsw { get; set; }
        public int wind_w { get; set; }
        public int wind_wnw { get; set; }
        public int wind_nw { get; set; }
        public int wind_nnw { get; set; }
        public String airspace { get; set; }

        /// <summary>
        /// fill from sql reader
        /// </summary>
        /// <param name="reader"></param>
        public void fromSqlReader(DbDataReader reader) {
            ID = DBConvert.ToInt32(reader["Id"], 0);
            Hash = DBConvert.ToInt32(reader["Hash"], 0);

            Name = DBConvert.ToString(reader["Name"], "");
            Country = DBConvert.ToString(reader["Country"], "");
            City = DBConvert.ToString(reader["City"], "");
            Height = DBConvert.ToString(reader["Height"], "");
            Description = DBConvert.ToString(reader["Description"], "");
            Coordinates = DBConvert.ToString(reader["Coordinates"], "");
            WindFinderLink = DBConvert.ToString(reader["windfinderlink"], "");
            WindDirection = DBConvert.ToString(reader["winddirection"], "");

            Rating = DBConvert.ToInt32(reader["Rating"], 0);

            SupportsHangglider = DBConvert.ToString(reader["supports_hg"], "");
            SupportsParaglider = DBConvert.ToString(reader["supports_pg"], "");
            //Importfile = DBConvert.ToString(reader["importfiles"], "");

            wind_n = DBConvert.ToInt32(reader["wind_n"], 0);
            wind_nne = DBConvert.ToInt32(reader["wind_nne"], 0);
            wind_ne = DBConvert.ToInt32(reader["wind_ne"], 0);
            wind_ene = DBConvert.ToInt32(reader["wind_ene"], 0);
            wind_e = DBConvert.ToInt32(reader["wind_e"], 0);
            wind_ese = DBConvert.ToInt32(reader["wind_ese"], 0);
            wind_se = DBConvert.ToInt32(reader["wind_se"], 0);
            wind_sse = DBConvert.ToInt32(reader["wind_sse"], 0);
            wind_s = DBConvert.ToInt32(reader["wind_s"], 0);
            wind_ssw = DBConvert.ToInt32(reader["wind_ssw"], 0);
            wind_sw = DBConvert.ToInt32(reader["wind_sw"], 0);
            wind_wsw = DBConvert.ToInt32(reader["wind_wsw"], 0);
            wind_w = DBConvert.ToInt32(reader["wind_w"], 0);
            wind_wnw = DBConvert.ToInt32(reader["wind_wnw"], 0);
            wind_nw = DBConvert.ToInt32(reader["wind_nw"], 0);
            wind_nnw = DBConvert.ToInt32(reader["wind_nnw"], 0);

            airspace = DBConvert.ToString(reader["airspace"], "");

        }
    }

}
