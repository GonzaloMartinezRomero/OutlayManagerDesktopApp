using FastMember;
using OutlayManagerWF.Manager;
using OutlayManagerWF.Model;
using OutlayManagerWF.Model.Info;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace OutlayManagerWF.View.ResumeTransactions
{
    public partial class ResumeForm : Form
    {
        private ResumeForm()
        {
            InitializeComponent();
        }

        public ResumeForm(int year, int month) : this()
        {
            FillMonthsTransactions(year,month);
            this.advancedDataGridView1.FilterStringChanged += AdvancedDataGridView1_FilterStringChanged;
        }

        private void AdvancedDataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            double totalAmountFiteredColumns = 0.0d;

            if (sender is AdvancedDataGridView dataGridView)
            {
                 BindingSource bindingSource = dataGridView.DataSource as BindingSource;
                 DataView dataView = bindingSource.List as DataView;
                 dataView.RowFilter = e.FilterString;

                 foreach(DataRowView dataRowFiltered in dataView)
                 {
                     totalAmountFiteredColumns += Utilities.Normalizer.NormalizeAmount(dataRowFiltered[nameof(ResumeTransactionDTO.Amount)]);
                 }
            }

            this.textBoxTotalAmount.Text = Utilities.Normalizer.SpainFormatAmount(totalAmountFiteredColumns);
        }

        private void FillMonthsTransactions(int year, int month)
        {
            try
            {
                List<ResumeTransactionDTO> resumeTransactions = new TransactionManager().GetAllMonthsTransactions(year, month);

                DataTable dataTable = new DataTable();

                using (var reader = ObjectReader.Create(resumeTransactions))
                {
                    dataTable.Load(reader);
                }

                BindingSource bindingSource = new BindingSource
                {
                    DataSource = dataTable
                };

                this.advancedDataGridView1.DataSource = bindingSource;

                double totalTransactionsAmount = resumeTransactions.Select(x => x.Amount).Sum();

                this.textBoxTotalAmount.Text = Utilities.Normalizer.SpainFormatAmount(totalTransactionsAmount);
            }
            catch (Exception e)
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Exception, e.Message, this);
            }
        }
    }
}
