using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OutlayManagerWF.Model.TransactionDTO;

namespace OutlayManagerWF.Model.View
{
    public class TransactionView
    {
        public int ID { get; set; }
        public int Internal_ID { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public SourceGeneration Source { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
