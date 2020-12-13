using OutlayManagerWF.Model;
using OutlayManagerWF.Model.Info;
using OutlayManagerWF.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Utilities
{
    public static class CastObject
    {
        public static TransactionView TransactionToTransactionView(TransactionDTO transaction)
        {
            return new TransactionView()
            {
                ID = transaction.ID,
                Internal_ID = transaction.Internal_ID,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Type = transaction.DetailTransaction.Type,
                Code = transaction.DetailTransaction.Code,
                Description = transaction.DetailTransaction.Description,
                Source = transaction.Source
            };
        }

        public static TransactionDTO TransactionViewToTransaction(TransactionView transactionView)
        {
            return new TransactionDTO()
            {
                ID = transactionView.ID,
                Internal_ID = transactionView.Internal_ID,
                Amount = transactionView.Amount,
                Date = transactionView.Date,
                DetailTransaction = new DetailTransacionDTO()
                {
                    Type = transactionView.Type,
                    Code = transactionView.Code,
                    Description = transactionView.Description
                },
                Source = transactionView.Source
            };
        }

        public static ResumeTransactionDTO ToResumeTransaction (TransactionDTO transactionDTO)
        {
            return new ResumeTransactionDTO()
            {
                Code = transactionDTO.DetailTransaction.Code,
                Type = transactionDTO.DetailTransaction.Type,
                Amount = transactionDTO.Amount,
                Date = transactionDTO.Date,
            };
        }

        public static DateTime ToDateTime(object dateTimeObject)
        {
            string dateTimeAux = dateTimeObject?.ToString() ?? String.Empty;
            DateTime dateTimeParsed = default(DateTime);

            if (!DateTime.TryParse(dateTimeAux, out dateTimeParsed))
                throw new Exception($"Imposible parsed {dateTimeAux} to DateTime");

            return dateTimeParsed;
        }

        public static double ToDouble(object objectDouble)
        {
            string doubleString = objectDouble?.ToString() ?? String.Empty;
            double doubleValueParsed = 0.0d;

            if (!Double.TryParse(doubleString, out doubleValueParsed))
                throw new Exception($"Imposible parsed {doubleString} to Double");

            return doubleValueParsed;
        }
    }
}
