using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightSpot.Database;
using System.Data;

namespace FlightLogGUI {

    static class TableConverter {

        private const string COL_FLIGHT_LOG_ID = "Id";
        private const string COL_FLIGHT_LOG_GLIDER = "Fluggerät";
        private const string COL_FLIGHT_LOG_START = "Startplatz";
        private const string COL_FLIGHT_LOG_LAND = "Landeplatz";
        private const string COL_FLIGHT_LOG_AIRTIME = "Flugzeit";
        private const string COL_FLIGHT_LOG_COMMENT = "Kommentar";

        private const string COL_FLIGHT_SPOT_NAME = "Name";
        private const string COL_FLIGHT_SPOT_COUNTRY = "Country";
        private const string COL_FLIGHT_SPOT_MINHEIGHT = "MinHeight";
        private const string COL_FLIGHT_SPOT_POSTCODE = "PostCode";
        private const string COL_FLIGHT_SPOT_DESCRIPTION = "Beschreibung";
        private const string COL_FLIGHT_SPOT_WIND = "WindDirection";
        private const string COL_FLIGHT_SPOT_RATING = "Bewertung";


        private static void addColumn(DataTable table, String colName) {
            DataColumn col = new DataColumn();
            col.Caption = colName;
            col.ColumnName = colName;
            table.Columns.Add(col);
        }

        private static void addColumns(DataTable table, List<String> columns) {
            foreach (String col in columns) {
                addColumn(table, col);
            }
        }
        
        /// <summary>
        /// add a row with flight information
        /// </summary>
        /// <param name="table"></param>
        /// <param name="flight"></param>
        private static void addFlightRow(DataTable table, FlightLogEntry flight) {
            DataRow row = table.NewRow();
            table.Rows.Add(row); 
            row[0] = flight.Id;
            row[1] = flight.Glider;
            row[2] = flight.LaunchSite;
            row[3] = flight.LandingSite;
            row[4] = flight.Airtime;
            row[5] = flight.Comment;
        }

        /// <summary>
        /// create data table with flight information
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public static DataTable flightLogsToDataTable(List<FlightLogEntry> flights) {
            DataTable table = new DataTable();
            List<String> columns = new List<string>() { 
                COL_FLIGHT_LOG_ID, 
                COL_FLIGHT_LOG_GLIDER, 
                COL_FLIGHT_LOG_START, 
                COL_FLIGHT_LOG_LAND, 
                COL_FLIGHT_LOG_AIRTIME, 
                COL_FLIGHT_LOG_COMMENT 
            };
            addColumns(table, columns);

            foreach (FlightLogEntry flight in flights) {
               addFlightRow(table, flight);
            }

            return table;
        }

        /// <summary>
        /// add flight spot row to table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="spot"></param>
        private static void addFlightSpotRow(DataTable table, FlightSpotEntry spot) {
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            row[0] = spot.Name;
            row[1] = spot.Country;
            row[2] = spot.PostCode;
            row[3] = spot.Description;
            row[4] = spot.MinHeight;
            row[5] = spot.WindDirection;
            String rating = String.Empty;
            for (int i = 1; i <= spot.Rating; i++) {
                rating += "*";
            }
            row[6] = rating;
        }

        /// <summary>
        /// create data table with flight spots
        /// </summary>
        /// <param name="spots"></param>
        /// <returns></returns>
        public static DataTable flightSpotsToDataTable(List<FlightSpotEntry> spots) {
            DataTable table = new DataTable();
            List<String> columns = new List<string>() { 
                COL_FLIGHT_SPOT_NAME,
                COL_FLIGHT_SPOT_COUNTRY,
                COL_FLIGHT_SPOT_POSTCODE,
                COL_FLIGHT_SPOT_DESCRIPTION,
                COL_FLIGHT_SPOT_MINHEIGHT,
                COL_FLIGHT_SPOT_WIND,
                COL_FLIGHT_SPOT_RATING
            };
            addColumns(table, columns);

            foreach (FlightSpotEntry spot in spots) {
               addFlightSpotRow(table, spot);
            }

            return table;
        }

    }
}
