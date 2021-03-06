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
        private const string SELECT_FROM_FLIGHTSPOT_BY_ID =
           "select * from FLIGHTSPOTS where ID = @ID";
        private const string UPDATE_FLIGHTSPOT_AIRSPACE_INFO =
           "update FLIGHTSPOTS set AIRSPACE = @AIRSPACE where ID = @ID";
        private const string UPDATE_FLIGHTSPOT_WEATHERLINK =
           "update FLIGHTSPOTS set WINDFINDERLINK = @WINDFINDERLINK where ID = @ID";

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

        /// <summary>
        /// get single flightspot data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FlightSpotDBEntry getFlightSpot(int id) {
            FlightSpotDBEntry fsEntry = null;
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@ID", DbType.Int32, id));
            GetSingle<FlightSpotDBEntry>(out fsEntry, SELECT_FROM_FLIGHTSPOT_BY_ID, DbParams, convertDBDataToFlightSpot);
            return fsEntry;
        }
        /// <summary>
        /// update airspace information of a flightspot
        /// </summary>
        /// <param name="Spot"></param>
        /// <returns></returns>
        public int updateFlightSpotAdditionalInfo(int Id, String airspace) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@AIRSPACE", DbType.String, airspace));
            DbParams.Add(CreateDbParameter("@ID", DbType.String, Id));
            return executeDbCommand(UPDATE_FLIGHTSPOT_AIRSPACE_INFO, DbParams);
        }

        /// <summary>
        /// update airspace information of a flightspot
        /// </summary>
        /// <param name="Spot"></param>
        /// <returns></returns>
        public int updateFlightSpotWeatherLink(int Id, String link) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@WINDFINDERLINK", DbType.String, link));
            DbParams.Add(CreateDbParameter("@ID", DbType.String, Id));
            return executeDbCommand(UPDATE_FLIGHTSPOT_WEATHERLINK, DbParams);
        }

    }

}
