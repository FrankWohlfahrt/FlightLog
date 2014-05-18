using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace FlightSpot.Database {
    public partial class fsDatabase {

        private const string SELECT_FROM_FLIGHTLOG_BY_USER =
           "select * from FLIGHTLOG where USERID = @USERID";

        private const string SELECT_FROM_FLIGHTLOG_BY_ID =
            "select * from FLIGHTLOG where ID = @ID";

        private const string SELECT_FROM_FLIGHTLOG_LAST_FLIGHT =
            "select * from FLIGHTLOG where USERID = @USERID order by ID desc limit 1";

        private const string INSERT_INTO_FLIGHTLOG =
            "insert into FLIGHTLOG " +
            "       (USERID, DATE, GLIDER, LAUNCHSITE, LANDINGSITE, AIRTIMEHOURS, COMMENT, AIRTIME) " +
            "VALUES (@USERID, @DATE, @GLIDER, @LAUNCHSITE, @LANDINGSITE, @AIRTIMEHOURS, @COMMENT, @AIRTIME)";

        private const string UPDATE_FLIGHTLOG =
            "update FLIGHTLOG set " +
            "    DATE = @DATE, " +
            "    GLIDER = @GLIDER, " +
            "    LAUNCHSITE = @LAUNCHSITE, " +
            "    LANDINGSITE = @LANDINGSITE, " +
            "    AIRTIMEHOURS = @AIRTIMEHOURS, " +
            "    COMMENT = @COMMENT, " +
            "    AIRTIME = @AIRTIME " +
            "where ID = @ID";


        /// <summary>
        /// get a flightlog entry from datareader
        /// </summary>
        /// <param name="DataReader"></param>
        /// <returns></returns>
        private FlightLogEntry convertDBDataToFlightlog(DbDataReader DataReader) {
            FlightLogEntry rec = new FlightLogEntry();
            rec.fromSqlReader(DataReader);
            return rec;
        }

        /// <summary>
        /// get flightlog list by userid
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int getFlightLogList(out List<FlightLogEntry> pList, int UserId) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@USERID", DbType.Int32, UserId));
            return GetList<FlightLogEntry>(out pList, SELECT_FROM_FLIGHTLOG_BY_USER, DbParams, convertDBDataToFlightlog);
        }

        /// <summary>
        /// get flightlog entry by id
        /// </summary>
        /// <param name="pEntry"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int getFlightLogById(out FlightLogEntry pEntry, int Id) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@ID", DbType.Int32, Id));
            return GetSingle<FlightLogEntry>(out pEntry, SELECT_FROM_FLIGHTLOG_BY_ID, DbParams, convertDBDataToFlightlog);
        }

        /// <summary>
        /// get the last flight of a user
        /// </summary>
        /// <param name="pEntry"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int getLastFlight(out FlightLogEntry pEntry, int UserId) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@USERID", DbType.Int32, UserId));
            return GetSingle<FlightLogEntry>(out pEntry, SELECT_FROM_FLIGHTLOG_LAST_FLIGHT, DbParams, convertDBDataToFlightlog);
        }

        /// <summary>
        /// get flightlog list by userid
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int insertFlightLog(FlightLogEntry pEntry) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@USERID", DbType.Int32, pEntry.UserId));
            DbParams.Add(CreateDbParameter("@DATE", DbType.DateTime, pEntry.Date));
            DbParams.Add(CreateDbParameter("@GLIDER", DbType.String, pEntry.Glider));
            DbParams.Add(CreateDbParameter("@LAUNCHSITE", DbType.String, pEntry.LaunchSite));
            DbParams.Add(CreateDbParameter("@LANDINGSITE", DbType.String, pEntry.LandingSite));
            DbParams.Add(CreateDbParameter("@AIRTIMEHOURS", DbType.Single, pEntry.AirtimeHours));
            DbParams.Add(CreateDbParameter("@COMMENT", DbType.String, pEntry.Comment));
            DbParams.Add(CreateDbParameter("@AIRTIME", DbType.String, pEntry.Airtime));

            return executeDbCommand(INSERT_INTO_FLIGHTLOG, DbParams);
        }

        /// <summary>
        /// update flight log entry
        /// </summary>
        /// <param name="pEntry"></param>
        /// <returns></returns>
        public int updateFlightLog(FlightLogEntry pEntry) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@DATE", DbType.DateTime, pEntry.Date));
            DbParams.Add(CreateDbParameter("@GLIDER", DbType.String, pEntry.Glider));
            DbParams.Add(CreateDbParameter("@LAUNCHSITE", DbType.String, pEntry.LaunchSite));
            DbParams.Add(CreateDbParameter("@LANDINGSITE", DbType.String, pEntry.LandingSite));
            DbParams.Add(CreateDbParameter("@AIRTIMEHOURS", DbType.Single, pEntry.AirtimeHours));
            DbParams.Add(CreateDbParameter("@COMMENT", DbType.String, pEntry.Comment));
            DbParams.Add(CreateDbParameter("@AIRTIME", DbType.String, pEntry.Airtime));
            DbParams.Add(CreateDbParameter("@ID", DbType.Int32, pEntry.Id));
            
            return executeDbCommand(UPDATE_FLIGHTLOG, DbParams);
        }

    }
}
