using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Utilities
{
    public static class Normalizer
    {
        public static double? NormalizeAmount(string text, int decimalRound = 2)
        {
            double? valueNormalized = null;

            string value = text.Trim().Replace(',', '.');

            if(Double.TryParse(value,
                               NumberStyles.AllowDecimalPoint,
                               CultureInfo.InvariantCulture,
                               out double valueParsedAux))
            {
                valueNormalized = Math.Round(valueParsedAux,decimalRound);
            }

            return valueNormalized;
        }

        public static string NormalizeAmount(double? value, int decimalRound = 2)
        {
            string amountNormalized = String.Empty;

            if (value.HasValue)
                amountNormalized = Math.Round(value.Value, decimalRound).ToString().Replace(',', '.').Trim();

            return amountNormalized;
        }

        public static string NormalizeAmount(double value, int decimalRound = 2)
        {
            return Math.Round(value, decimalRound).ToString();
        }

        /// <summary>
        /// Return 0 if cast failed
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double NormalizeAmount(object value,int decimalRound = 2)
        {
            string valueStr = value?.ToString() ?? "";
            double? valueNullableParsed = NormalizeAmount(valueStr);

            return Math.Round(valueNullableParsed ?? 0.0d, decimalRound);
        }

        public static string SpainFormatAmount(double amount)
        {
            double roundAmount = Math.Round(amount,2);

            return roundAmount.ToString("N", CultureInfo.CreateSpecificCulture("es-ES")) + " €";
        }

    }
}
