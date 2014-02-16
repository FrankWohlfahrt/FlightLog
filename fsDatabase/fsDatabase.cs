//******************************************************************************
//  Project:            FlightSpotDB
//------------------------------------------------------------------------------
//  Copyright (c) Frank Wohlfahrt (FW), Wiesbaden, Germany   All rights reserved
//------------------------------------------------------------------------------
//  AUTHOR:             FW
//  CREATED:            2013
//  DESCRIPTION:        Interface to SQLite database
//------------------------------------------------------------------------------
//  HISTORY:
//  2014-02-04  V1.0    port from QT project
// 
//******************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Reflection;
using System.Data.Common;
using System.Data;

namespace FlightSpot.Database {

    public partial class fsDatabase : IDisposable {

        private SQLiteConnection m_Connection;
        private object m_LockObject = new object();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public fsDatabase(String connectionString) {
            connect(connectionString);
        }

        /// <summary>
        /// clean up
        /// </summary>
        public void Dispose() {
            if (null != m_Connection) {
                m_Connection.Dispose();
            }
        }

        public bool isConnected {
            get { return ConnectionState.Open == m_Connection.State; }
        }

        /// <summary>
        /// connect to database
        /// </summary>
        /// <param name="connectionString"></param>
        private void connect(String connectionString) {
            m_Connection = new SQLiteConnection();
            m_Connection.ConnectionString = "Data Source=" + connectionString;
            m_Connection.Open();
        }

        /// <summary>
        /// trace exception
        /// </summary>
        /// <param name="MethodName"></param>
        /// <param name="Text"></param>
        /// <param name="e"></param>
        private void doTraceException(String MethodName, String Text, Exception e) {
        }

        /// <summary>
        /// create database command object
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DbCommand CreateDbCommand(String sql) {
            if (null != m_Connection) {
                SQLiteCommand command = new SQLiteCommand(m_Connection);
                command.CommandText = sql;
                return command;
            }
            return null;
        }

        /// <summary>
        /// create database parameter
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private DbParameter CreateDbParameter(String paramName, DbType type, object value) {
            SQLiteParameter param = new SQLiteParameter();
            param.DbType = type;
            param.ParameterName = paramName;
            param.Value = value;
            return param;
        }

        /// <summary>
        /// generic wrapper for reading database lists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pList"></param>
        /// <param name="sSQL"></param>
        /// <param name="conversionMethod"></param>
        /// <returns></returns>
        public int GetList<T>(out List<T> pList,
                              String sSQL,
                              List<DbParameter> DbParams,
                              Func<DbDataReader, T> conversionMethod) where T : new() {
            pList = new List<T>();
            int lCount = 0;
            try {
                DbCommand pCommand = CreateDbCommand(sSQL);

                if ((null == pCommand) || (null == pCommand.Connection) || (!isConnected)) {
                    return 0;
                }

                lock (m_LockObject) {
                    try {
                        if (null != DbParams) {
                            foreach (DbParameter p in DbParams) {
                                pCommand.Parameters.Add(p);
                            }
                        }

                        DbDataReader DataReader = pCommand.ExecuteReader();
                        try {
                            if (DataReader.HasRows) {
                                while (DataReader.Read()) {
                                    T rec = conversionMethod(DataReader);
                                    if (null != rec) {
                                        pList.Add(rec);
                                        lCount++;
                                    }
                                }
                            }
                        }
                        finally {
                            DataReader.Close();
                        }
                    }
                    finally {
                        pCommand.Dispose();
                    }
                }
            }
            catch (Exception e) {
                lCount = 0;
                pList.Clear();
                doTraceException(MethodInfo.GetCurrentMethod().Name, sSQL, e);
            }
            return lCount;
        }

        /// <summary>
        /// wrapper to get a single data set from DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ret"></param>
        /// <param name="sSQL"></param>
        /// <param name="DbParams"></param>
        /// <param name="conversionMethod"></param>
        /// <returns></returns>
        public int GetSingle<T>(out T ret,
                      String sSQL,
                      List<DbParameter> DbParams,
                      Func<DbDataReader, T> conversionMethod) where T : new() {
            ret = new T();
            int lCount = 0;
            try {
                DbCommand pCommand = CreateDbCommand(sSQL);
                if ((null == pCommand) || (null == pCommand.Connection) || (!isConnected)) {
                    return 0;
                }

                lock (m_LockObject) {
                    try {
                        if (null != DbParams) {
                            foreach (DbParameter p in DbParams) {
                                pCommand.Parameters.Add(p);
                            }
                        }

                        DbDataReader DataReader = pCommand.ExecuteReader();
                        try {
                            if (DataReader.HasRows) {
                                while (DataReader.Read()) {
                                    T rec = conversionMethod(DataReader);
                                    if (null != rec) {
                                        ret = rec;
                                        lCount++;
                                    }
                                }
                            }
                        }
                        finally {
                            DataReader.Close();
                        }
                    }
                    finally {
                        pCommand.Dispose();
                    }
                }
            }
            catch (Exception e) {
                lCount = 0;
                doTraceException(MethodInfo.GetCurrentMethod().Name, sSQL, e);
            }
            return lCount;
        }

        /// <summary>
        /// execute a param-defined sql command
        /// </summary>
        /// <param name="sSQL"></param>
        /// <param name="DbParams"></param>
        /// <returns></returns>
        public int executeDbCommand(String sSQL, List<DbParameter> DbParams) {
            int iRes = 0;
            try {
                DbCommand pCommand = CreateDbCommand(sSQL);
                if ((null == pCommand) || (null == pCommand.Connection) || (!isConnected)) {
                    return 0;
                }

                try {
                    if (null != DbParams) {
                        foreach (DbParameter p in DbParams) {
                            pCommand.Parameters.Add(p);
                        }
                    }
                    lock (m_LockObject) {
                        try {
                            iRes = pCommand.ExecuteNonQuery();
                        }
                        catch (Exception e) {
                            doTraceException(MethodInfo.GetCurrentMethod().Name, sSQL, e);
                        }
                    }
                }
                finally {
                    pCommand.Dispose();
                }
            }
            catch (Exception e) {
                doTraceException(MethodInfo.GetCurrentMethod().Name, sSQL, e);
            }
            return iRes;
        }

    }

}
