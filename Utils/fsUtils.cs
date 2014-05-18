using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils {
    public static class fsUtils {

        /// <summary>
        /// split a time in float to hours and minutes as int
        /// </summary>
        /// <param name="fTime"></param>
        /// <param name="iHours"></param>
        /// <param name="iMinutes"></param>
        public static void splitFloatTimeIntoHoursAndMinutes(float fTime, ref int iHours, ref int iMinutes) {
            iHours = (int)fTime;
            iMinutes = (int)((fTime - iHours) * 60);
        }

        /// <summary>
        /// combine hours and minutes in int to a float
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static float combineHoursAndMinutesToFloatTime(int hours, int minutes) {
            while (minutes > 60) {
                hours++;
                minutes -= 60;
            }
            return hours + ((float)minutes / 60);
        }

        /// <summary>
        /// pretty print the time
        /// </summary>
        /// <param name="fTime"></param>
        /// <returns></returns>
        public static String prettyPrintTime(float fTime) {
            String sRet;
            int iHours = 0;
            int iMin = 0;

            splitFloatTimeIntoHoursAndMinutes(fTime, ref iHours, ref iMin);
            sRet = String.Format("{0} h, {1} min", iHours, iMin);

            return sRet;
        }
    }
}
