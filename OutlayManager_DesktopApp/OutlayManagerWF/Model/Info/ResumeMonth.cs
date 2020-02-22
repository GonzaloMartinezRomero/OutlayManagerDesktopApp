using System;
using System.Collections.Generic;

namespace OutlayManagerWF.Model.Info
{
    public class ResumeMonth
    {
        public DateTime Date { get; }
        public double Spenses { get; set; } = 0.0d;
        public double Incoming { get; set; } = 0.0d;
        public Dictionary<string, double> GroupCodeTransactions { get; set; } = new Dictionary<string, double>();

        private ResumeMonth() { }

        public ResumeMonth(int year, int month): this()
        {
            this.Date = new DateTime(year, month, 1);
        }
    }
}
