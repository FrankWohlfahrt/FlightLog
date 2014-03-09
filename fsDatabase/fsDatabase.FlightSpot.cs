﻿using System;
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
        private FlightSpotDBEntry convertDBDataToFlightSpot(DbDataReader DataReader) {
            FlightSpotDBEntry rec = new FlightSpotDBEntry();
            rec.fromSqlReader(DataReader);
            return rec;
        }

        /// <summary>
        /// get flightspot list by rating
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="Rating"></param>
        /// <returns></returns>
        public int getFlightSpotList(out List<FlightSpotDBEntry> pList, int Rating) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@RATING", DbType.Int32, Rating));
            return GetList<FlightSpotDBEntry>(out pList, SELECT_FROM_FLIGHTSPOT_BY_RATING, DbParams, convertDBDataToFlightSpot);
        }
    
    }

}
