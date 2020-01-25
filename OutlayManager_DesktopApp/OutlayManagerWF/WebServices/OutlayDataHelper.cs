using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.WebServices
{
    public sealed class OutlayDataHelper
    {
        public static List<string> OutlayTypes { get; private set; }

        public void SetOutlayTypes(List<string> outlayTypesList)
        {
           OutlayTypes = outlayTypesList;
        }

    }
}
