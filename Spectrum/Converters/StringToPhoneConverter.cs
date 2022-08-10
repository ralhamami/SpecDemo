using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Spectrum
{
    public class StringToPhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Convert the raw phone string from Spectrum.com to a nicely formatted phone number.
            var retVal = "(###) ###-####";

            try
            {
                if (value != null)
                {
                    var phone = value as string;

                    if (!String.IsNullOrEmpty(phone))
                    {
                        retVal = Regex.Replace(phone, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
                    }
                }

            }
            catch (Exception ex)
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
