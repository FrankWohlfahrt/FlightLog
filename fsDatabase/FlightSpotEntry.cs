using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.ComponentModel;

namespace FlightSpot.Database {

    /// <summary>
    /// class for database access
    /// </summary>
    public class FlightSpotDBEntry {
        [Browsable(false)]
        public int ID { get; set; }

        [Browsable(false)]
        public int Hash { get; set; }

        [DisplayName("Name")]
        [Browsable(true)]
        public String Name { get; set; }

        [DisplayName("Land")]
        [Browsable(true)]
        public String Country { get; set; }

        [DisplayName("PostCode")]
        [Browsable(true)]
        public String City { get; set; }

        [DisplayName("Höhe")]
        [Browsable(true)]
        public String Height { get; set; }

        [DisplayName("Beschreibung")]
        [Browsable(true)]
        [AutoSizeColumn]
        public String Description { get; set; }
        
        [Browsable(false)]
        public String Coordinates { get; set; }

        [Browsable(false)]
        public String WindFinderLink { get; set; }
        
        [DisplayName("Windrichtung")]
        [Browsable(true)]
        public String WindDirection { get; set; }

        [DisplayName("Bewertung")]
        [Browsable(true)]
        public int Rating { get; set; }

        [Browsable(false)]
        public String SupportsHangglider { get; set; }

        [Browsable(false)]
        public String SupportsParaglider { get; set; }
        
        [Browsable(false)]
        public String Importfile { get; set; }
        
        [Browsable(false)]
        public int wind_n { get; set; }
        
        [Browsable(false)]
        public int wind_nne { get; set; }
        
        [Browsable(false)]
        public int wind_ne { get; set; }
        
        [Browsable(false)]
        public int wind_ene { get; set; }
        
        [Browsable(false)]
        public int wind_e { get; set; }
        
        [Browsable(false)]
        public int wind_ese { get; set; }
        
        [Browsable(false)]
        public int wind_se { get; set; }
        
        [Browsable(false)]
        public int wind_sse { get; set; }
        
        [Browsable(false)]
        public int wind_s { get; set; }
        
        [Browsable(false)]
        public int wind_ssw { get; set; }
        
        [Browsable(false)]
        public int wind_sw { get; set; }
        
        [Browsable(false)]
        public int wind_wsw { get; set; }
        
        [Browsable(false)]
        public int wind_w { get; set; }
        
        [Browsable(false)]
        public int wind_wnw { get; set; }
        
        [Browsable(false)]
        public int wind_nw { get; set; }
        
        [Browsable(false)]
        public int wind_nnw { get; set; }

        [Browsable(false)]
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
