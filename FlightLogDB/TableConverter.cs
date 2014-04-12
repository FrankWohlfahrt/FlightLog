using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightSpot.Database;
using System.Data;
using Utilities.Grids;

namespace FlightLogGUI {

    static class TableConverter {

        private const string COL_FLIGHT_LOG_ID = "Id";
        private const string COL_FLIGHT_LOG_DATE = "Datum";
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


        /// <summary>
        /// add a row with flight information
        /// </summary>
        /// <param name="table"></param>
        /// <param name="flight"></param>
        private static void addFlightRow(DataTable table, FlightLogEntry flight) {
            GridUtils.addRow(
                table, 
                flight.Id.ToString(),
                flight.Date.ToShortDateString(),
                flight.Glider,
                flight.LaunchSite,
                flight.LandingSite,
                flight.Airtime,
                flight.Comment
            );
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
                COL_FLIGHT_LOG_DATE, 
                COL_FLIGHT_LOG_GLIDER, 
                COL_FLIGHT_LOG_START, 
                COL_FLIGHT_LOG_LAND, 
                COL_FLIGHT_LOG_AIRTIME, 
                COL_FLIGHT_LOG_COMMENT 
            };
            GridUtils.addColumns(table, columns);

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
        private static void addFlightSpotRow(DataTable table, FlightSpotDBEntry spot) {
            String rating = String.Empty;
            for (int i = 1; i <= spot.Rating; i++) {
                rating += "*";
            }

            FlightSpotGui fs = new FlightSpotGui(spot);
            table.Rows.Add(fs);

            GridUtils.addRow(
                table,
                spot.Name,
                spot.Country,
                spot.City,
                spot.Description,
                spot.Height,
                spot.WindDirection,
                rating
            );
        }

        /// <summary>
        /// create data table with flight spots
        /// </summary>
        /// <param name="spots"></param>
        /// <returns></returns>
        public static void flightSpotTable(List<FlightSpotDBEntry> spots, out List<String> columns, out List<FlightSpotGui> display) {
            columns = new List<string>() { 
                COL_FLIGHT_SPOT_NAME,
                COL_FLIGHT_SPOT_COUNTRY,
                COL_FLIGHT_SPOT_POSTCODE,
                COL_FLIGHT_SPOT_DESCRIPTION,
                COL_FLIGHT_SPOT_MINHEIGHT,
                COL_FLIGHT_SPOT_WIND,
                COL_FLIGHT_SPOT_RATING
            };

            display = new List<FlightSpotGui>();
            foreach (FlightSpotDBEntry spot in spots) {
                FlightSpotGui fs = new FlightSpotGui(spot);
                display.Add(fs);
            }
        }

        /// <summary>
        /// create data table with flight spots
        /// </summary>
        /// <param name="spots"></param>
        /// <returns></returns>
        public static DataTable flightSpotTable(List<FlightSpotDBEntry> spots) {
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
            GridUtils.addColumns(table, columns);

            foreach (FlightSpotDBEntry spot in spots) {
                addFlightSpotRow(table, spot);
            }

            return table;
        }

    }
}
