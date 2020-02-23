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

    }
}
