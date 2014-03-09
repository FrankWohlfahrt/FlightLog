using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace FlightSpot.Database {

    /// <summary>
    /// class for database access
    /// </summary>
    public class AdditionalInfos {
        public int ID { get; set; }
        public int Hash { get; set; }
        public String Name { get; set; }
        public int TypeId { get; set; }
        public String Data { get; set; }

                /// <summary>
        /// fill from sql reader
        /// </summary>
        /// <param name="reader"></param>
        public void fromSqlReader(DbDataReader reader) {
            ID = DBConvert.ToInt32(reader["Id"], 0);
            Hash = DBConvert.ToInt32(reader["Hash"], 0);
            Name = DBConvert.ToString(reader["Name"], "");
            TypeId = DBConvert.ToInt32(reader["TypeId"], 0);
            Data = DBConvert.ToString(reader["Data"], "");
        }
    }
}
