using Newtonsoft.Json;
using OutlayManagerWF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Model
{
    public class TransactionDTO
    {   
        public enum SourceGeneration
        {
            DataBase,
            NewTransaction
        }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("detailTransaction")]
        public DetailTransacionDTO DetailTransaction { get; set; }

        [JsonIgnore]
        public int Internal_ID { get; set; }

        [JsonIgnore]
        public SourceGeneration Source { get; set; } = SourceGeneration.DataBase;

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine($"{nameof(this.ID)}: {this.ID}");
            strBuilder.AppendLine($"{nameof(this.Amount)}: {this.Amount}");
            strBuilder.AppendLine($"{nameof(this.Date)}: {this.Date.ToShortDateString()}");
            strBuilder.AppendLine($"{nameof(this.DetailTransaction.Code)}: {this.DetailTransaction.Code}");
            strBuilder.AppendLine($"{nameof(this.DetailTransaction.Description)}: {this.DetailTransaction.Description}");
            strBuilder.AppendLine($"{nameof(this.DetailTransaction.Type)}: {this.DetailTransaction.Type}");

            return strBuilder.ToString();
        }

        public TransactionDTO() { }

        public TransactionDTO(TransactionDTO transaction)
        {
            this.Amount = transaction.Amount;
            this.Date = transaction.Date;
            this.DetailTransaction = new DetailTransacionDTO(transaction.DetailTransaction);
            this.ID = transaction.ID;
            this.Internal_ID = transaction.Internal_ID;
            this.Source = transaction.Source;
        }
    }
}
