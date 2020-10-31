using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.WebServices
{
    public sealed class OutlayDataHelper
    {
        public enum OutlayTypesEnum
        {
            INCOMING,
            SPENDING,
            ADJUST
        }

        public static List<string> OutlayTypes {
            get
            {
                return Enum.GetNames(typeof(OutlayTypesEnum)).ToList();
            }
        }

        public static bool IsCorrectOutlayType(string outlayType)
        {
            return Enum.TryParse(outlayType, out OutlayTypesEnum typeAux);
        }

        public static OutlayTypesEnum? GetOutlayType(string outlayType)
        {
            OutlayTypesEnum? typeParsed = null;

            if (Enum.TryParse(outlayType, out OutlayTypesEnum typeAux))
                typeParsed = typeAux;

            return typeParsed;
        }

         
    }
}
