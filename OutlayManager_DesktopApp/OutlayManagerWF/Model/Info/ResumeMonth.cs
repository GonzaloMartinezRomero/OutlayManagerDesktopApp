using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Model.Info
{
    public class ResumeMonth
    {
        public double Spenses { get; set; }
        public double Incoming { get; set; }
        public Dictionary<string, double> GroupCodeTransactions { get; set; }
    }
}
