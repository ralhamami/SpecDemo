using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Spectrum
{
    public class StringToHoursConverter : IValueConverter
    {
        static Dictionary<char, string> DAYSOFWEEK = new Dictionary<char, string> { { '1', "MON" }, { '2', "TUE" }, { '3', "WED" }, { '4', "THU" }, { '5', "FRI" }, { '6', "SAT" }, { '7', "SUN" } };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var retVal = new List<string>();
            try
            {
                //Take the raw hours string returned to us from Spectrum.com. Then split, parse, and format it.
                if (value != null)
                {
                    var hours = value as string;

                    if (!String.IsNullOrEmpty(hours))
                    {
                        var hoursCollection = hours.Split(',');

                        foreach (var hour in hoursCollection)
                        {
                            retVal.Add(DAYSOFWEEK[hour[0]] + ": " + hour.Substring(2));
                        }

                        return retVal;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error encountered while converting hours string.", ex.Message);
            }

            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
