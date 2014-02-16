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

    }
}
