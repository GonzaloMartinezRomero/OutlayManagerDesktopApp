using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Model
{
    public class ResultInfo
    {
        public string Message { get; set; } = "No Message";
        public bool IsError { get; set; } = false;
        public bool ProcessCancel { get; set; } = false;
    }
}
