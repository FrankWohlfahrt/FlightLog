using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace FlightSpot.Database {

    public partial class fsDatabase {

        private const string SELECT_FROM_ADDITIONAL_INFOS_BY_HASH =
           "select * from additional_infos where Hash = @Hash";

        /// <summary>
        /// get a flightlog entry from datareader
        /// </summary>
        /// <param name="DataReader"></param>
        /// <returns></returns>
        private AdditionalInfos convertDBDataToAdditionalInfo(DbDataReader DataReader) {
            AdditionalInfos rec = new AdditionalInfos();
            rec.fromSqlReader(DataReader);
            return rec;
        }

        /// <summary>
        /// get additional infos by hash
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="Hash"></param>
        /// <returns></returns>
        public int getAdditionalInfoList(out List<AdditionalInfos> pList, int Hash) {
            List<DbParameter> DbParams = new List<DbParameter>();
            DbParams.Add(CreateDbParameter("@HASH", DbType.Int32, Hash));
            return GetList<AdditionalInfos>(out pList, SELECT_FROM_ADDITIONAL_INFOS_BY_HASH, DbParams, convertDBDataToAdditionalInfo);
        }
    }
}
