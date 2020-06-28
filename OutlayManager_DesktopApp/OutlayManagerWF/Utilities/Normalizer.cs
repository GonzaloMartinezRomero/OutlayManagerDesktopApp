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
        public static double? NormalizeAmount(string text)
        {
            double? valueNormalized = null;

            string value = text.Trim().Replace(',', '.');

            if(Double.TryParse(value,
                               NumberStyles.AllowDecimalPoint,
                               CultureInfo.InvariantCulture,
                               out double valueParsedAux))
            {
                valueNormalized = valueParsedAux;
            }

            return valueNormalized;
        }

        public static string NormalizeAmount(double? value)
        {
            string amountNormalized = String.Empty;

            if (value.HasValue)
                amountNormalized = value.Value.ToString().Replace(',', '.').Trim();

            return amountNormalized;
        }

        public static string SpainFormatAmount(double amount)
        {
            double roundAmount = Math.Round(amount,2);

            return roundAmount.ToString("N", CultureInfo.CreateSpecificCulture("es-ES")) + " €";
        }

    }
}
