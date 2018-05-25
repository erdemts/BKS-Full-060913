using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BKSUSBDriver
{
    public static class Extension
    {
        private static CultureInfo trCulture = new CultureInfo("tr-TR");


        public static string ByteToString(this byte[] data, int startpoint = 0, int endpoint = 0 )
        {
            if (data == null)
                return null;

            string result = string.Empty;

            int length = (endpoint == 0) ? data.Length : endpoint + 1;

            for (int index = startpoint; index < length; index++)
            {
                result += data[index];
            }

            return result;
        }

        public static DateTime ByteToDateTime(this byte[] data, int startpoint = 0)
        {
            if (data == null)
                return DateTime.MinValue;

            string dateData = string.Empty;

            if (data.Length == 6)
            {
                dateData = string.Format("{0:00}.{1:00}.20{2:00} {3:00}:{4:00}:{5:00}",
                        data[startpoint + 3],
                        data[startpoint + 4],
                        data[startpoint + 5],

                        data[startpoint + 2],
                        data[startpoint + 1],
                        data[startpoint + 0]);
            }
            else if (data.Length == 7)
            {
                byte dayofweek = data[startpoint + 3];

                dateData = string.Format("{0:00}.{1:00}.20{2:00} {3:00}:{4:00}:{5:00}",
                                       data[startpoint + 4],
                                       data[startpoint + 5],
                                       data[startpoint + 6],

                                       data[startpoint + 2],
                                       data[startpoint + 1],
                                       data[startpoint + 0]);
            }
            else
                return DateTime.MinValue;

            DateTime temp = DateTime.MinValue;


            DateTime.TryParseExact(dateData, "dd.MM.yyyy HH:mm:ss", trCulture, System.Globalization.DateTimeStyles.None, out temp);
            return temp;
        }
    }
}
