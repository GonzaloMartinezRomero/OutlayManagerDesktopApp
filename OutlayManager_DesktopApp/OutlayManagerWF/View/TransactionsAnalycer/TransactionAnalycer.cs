using FastMember;
using OutlayManagerWF.Manager;
using OutlayManagerWF.Model.Info;
using OutlayManagerWF.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Zuby.ADGV;

namespace OutlayManagerWF.View.TransactionsAnalycer
{
    public partial class TransactionAnalycer : Form
    {
        public TransactionAnalycer()
        {
            InitializeComponent();
            this.transactionsDataGridView.FilterStringChanged += FilterStringChanged;
            InitializeChart();
        }

        private void InitializeChart()
        {
           this.chartTypeSelector.Items.AddRange(new object[]
           {
                SeriesChartType.Line,
                SeriesChartType.Spline,
                SeriesChartType.Area,
                SeriesChartType.Column,
                SeriesChartType.Pie
           });

            //Line by default
            this.chartTypeSelector.SelectedItem = SeriesChartType.Line;
        }

        public void LoadTransactions()
        {
            try
            {
                List<ResumeTransactionDTO> transactions = null;
                transactions = new TransactionManager().GetAllTransactions();

                DataTable dataTable = new DataTable();

                using (var reader = ObjectReader.Create(transactions))
                {
                    dataTable.Load(reader);
                }

                BindingSource bindingSource = new BindingSource
                {
                    DataSource = dataTable
                };

                this.transactionsDataGridView.DataSource = bindingSource;
            }
            catch (Exception e)
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Exception, e.Message, this);
            }
        }   

        private void FilterStringChanged(object sender, AdvancedDataGridView.FilterEventArgs e)
        {   
            if(sender is AdvancedDataGridView dataGrid)
            {
                BindingSource bindingSource = dataGrid.DataSource as BindingSource;
                DataView dataView = bindingSource.List as DataView;
                dataView.RowFilter = e.FilterString;

                SumTransactionsValues(dataView);
                GraphicTransactionsChart(dataView);
            }   
        }

        private void GraphicTransactionsChart(DataView dataView)
        {
            this.transactionsChart.Series.Clear();

            List<DataRowView> dataRowFiltered = new List<DataRowView>();
            foreach (DataRowView row in dataView)
                dataRowFiltered.Add(row);

            var codeGrouping = dataRowFiltered.GroupBy(row => row[nameof(ResumeTransactionDTO.Code)]);

            foreach (var transactionCodes in codeGrouping)
            {
                string groupName = transactionCodes.Key.ToString();
                this.transactionsChart.Series.Add(groupName);

                var dataRows = transactionCodes.Select(x => x).ToList();

                foreach (var dateTimeTransaction in dataRows)
                {
                    DateTime dt = CastObject.ToDateTime(dateTimeTransaction[nameof(ResumeTransactionDTO.Date)]);
                    double amount = CastObject.ToDouble(dateTimeTransaction[nameof(ResumeTransactionDTO.Amount)]);
                  
                    this.transactionsChart.Series[groupName].Points.AddXY(dt, amount);
                }
            }
        }

        private void SumTransactionsValues(DataView dataView)
        {
            double totalAmountFiteredColumns = 0.0d;

            foreach (DataRowView dataRowFiltered in dataView)
            {
                totalAmountFiteredColumns += Utilities.Normalizer.NormalizeAmount(dataRowFiltered[nameof(ResumeTransactionDTO.Amount)]);
            }

            this.textBoxTotalAmount.Text = Utilities.Normalizer.SpainFormatAmount(totalAmountFiteredColumns);
        }

        private void buttonCalculateSaving_Click(object sender, EventArgs e)
        {
            SeriesChartType chartTypeSelected = this.chartTypeSelector.SelectedItem as SeriesChartType? ?? SeriesChartType.Line;

            foreach (var serieAux in this.transactionsChart.Series)
                serieAux.ChartType = chartTypeSelected;
        }
    }
}
    
