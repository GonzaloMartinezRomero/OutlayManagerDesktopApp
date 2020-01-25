using OutlayManagerWF.Model;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OutlayManagerWF.View.ResumeTransactions
{
    public partial class ResumeForm : Form
    {
        public ResumeForm()
        {
            InitializeComponent();
            FillSpendingChart();
        }

        private void FillSpendingChart()
        {
            this.chartSpending.Name = "Spending Bitacora";
            this.chartSpending.Series.Clear();

            using (OutlayAPIManager APIManager = new OutlayAPIManager())
            {
                List<TransactionDTO> transactionList = APIManager.GetAllTransactions();

                //Fill SPENDING
                var transactionsValues = transactionList.GroupBy(x => new DateTime(x.Date.Year, x.Date.Month, 01))
                                                        .OrderBy(x => x.Key)
                                                        .ToDictionary(key => key.Key, values => values.ToList());                                                   

                var serieSpend = this.chartSpending.Series.Add("Spending");
                var serieIncoming = this.chartSpending.Series.Add("Incomings");
                var serieSaved = this.chartSpending.Series.Add("Saved");

                foreach (var transactionGroup in transactionsValues)
                {
                    double totalSpend = transactionGroup.Value.Where(x => x.DetailTransaction.Type == "SPENDING" || x.DetailTransaction.Type == "ADJUST")
                                                              .Sum(x => x.Amount);

                    double totalIncoming = transactionGroup.Value.Where(x => x.DetailTransaction.Type == "INCOMING")
                                                                 .Sum(x => x.Amount);

                    double totalSave = totalIncoming - totalSpend;

                    string keyGroupDate = transactionGroup.Key.ToString("MM/yyyy");

                    serieSpend.Points.AddXY(keyGroupDate, totalSpend);
                    serieIncoming.Points.AddXY(keyGroupDate, totalIncoming);
                    serieSaved.Points.AddXY(keyGroupDate, totalSave);
                }
            }
        }
    }
}
