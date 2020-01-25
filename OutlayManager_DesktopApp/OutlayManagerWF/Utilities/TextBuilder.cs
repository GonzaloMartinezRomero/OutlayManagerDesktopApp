using OutlayManagerWF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Utilities
{
    public static class TextBuilder
    {
        public static string TransactionToText(List<TransactionDTO> transactionList)
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (TransactionDTO transaction in transactionList)
            {
                strBuilder.AppendLine(TransactionToCalendarText(transaction));
            }

            return strBuilder.ToString();
        }

        public static string TransactionToCalendarText(TransactionDTO transaction)
        {
             return $"{transaction.DetailTransaction.Type} -> {transaction.Amount}€ ({transaction.DetailTransaction.Code})";
        }

        public static string EndOfLineCustom(string delimiter="", int lenght=0)
        {
            StringBuilder endOfLine = new StringBuilder();
            endOfLine.Append(Environment.NewLine);
            
            for (int i = 0; i <= lenght; ++i)
                endOfLine.Append(delimiter);
            
            if(lenght > 0)
                endOfLine.Append(Environment.NewLine);

            return endOfLine.ToString();
        }
    }
}
