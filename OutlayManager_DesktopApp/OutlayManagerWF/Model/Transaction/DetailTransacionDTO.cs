using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Model
{
    public class DetailTransacionDTO
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        public DetailTransacionDTO() { }

        public DetailTransacionDTO(DetailTransacionDTO transactionDetail)
        {
            this.Code = transactionDetail.Code;
            this.Description = transactionDetail.Description;
            this.Type = transactionDetail.Type;
        }
    }
}
