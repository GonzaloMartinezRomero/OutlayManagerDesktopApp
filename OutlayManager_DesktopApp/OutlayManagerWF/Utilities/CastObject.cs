using OutlayManagerWF.Model;
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
    }
}
