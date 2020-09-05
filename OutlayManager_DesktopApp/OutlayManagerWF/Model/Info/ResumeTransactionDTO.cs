using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Model.Info
{
    public class ResumeTransactionDTO
    {       
        public string Code { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}
