using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace FlightSpot.Database {
    public partial class fsDatabase {

        private const string SELECT_FROM_FLIGHTSPOT_BY_RATING =
           "select * from FLIGHTSPOTS where RATING >= @RATING";

        /// <summary>
        /// get a flightlog entry from datareader
        /// </summary>
        /// <param name="DataReader"></param>
        /// <returns></returns>
        private FlightSpotEntry convertDBDataToFlightSpot(DbDataReader DataReader) {
            FlightSpotEntry rec = new FlightSpotEntry();
            rec.fromSqlReader(DataReader);
            return rec;
        }

        /// <summary>
        /// get flightspot list by rating
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="Rating"></param>
        /// <returns></returns>
        public int getFlightSpotList(out List<FlightSpotEntry> pList, int Rating) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@RATING", DbType.Int32, Rating));
            return GetList<FlightSpotEntry>(out pList, SELECT_FROM_FLIGHTSPOT_BY_RATING, DbParams, convertDBDataToFlightSpot);
        }
    
    }

}
