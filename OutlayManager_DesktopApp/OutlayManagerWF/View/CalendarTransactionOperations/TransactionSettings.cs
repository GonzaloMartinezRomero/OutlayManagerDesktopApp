using OutlayManagerWF.Model;
using OutlayManagerWF.Model.View;
using OutlayManagerWF.Utilities;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlayManagerWF
{
    public partial class TransactionSettings : Form
    {
        private readonly HashSet<string> spendTypeList;             
        private readonly int transactionID;

        private readonly int internalTransactionID;
        private readonly TransactionDTO.SourceGeneration generationSource;

        public event BuilderTransactionDTO OnExecutionResult;
        public delegate void BuilderTransactionDTO(TransactionDTO transactionResult);        

        private TransactionSettings() 
        {
            InitializeComponent();

            spendTypeList = new HashSet<string>(OutlayDataHelper.OutlayTypes);
            this.type_text.Items.AddRange(spendTypeList.ToArray());
        }

        public TransactionSettings(DateTime date) : this()
        {
            this.dateTimePicker1.Value = date;
            this.generationSource = TransactionDTO.SourceGeneration.NewTransaction;
        }

        public TransactionSettings(TransactionView transactionView) : this() 
        {
            this.type_text.SelectedItem = transactionView.Type.ToString();
            this.text_amount.Text = Normalizer.NormalizeAmount(transactionView.Amount);
            this.dateTimePicker1.Value = transactionView.Date;
            this.text_Codigo.Text = transactionView.Code;
            this.text_description.Text = transactionView.Description;
            this.transactionID = transactionView.ID;

            this.internalTransactionID = transactionView.Internal_ID;
            this.generationSource = transactionView.Source;
        }

        private void Button_ConfirmChanges(object sender, EventArgs e)
        {
            TransactionDTO transaction = BuildTransacionDTO();

            if(transaction != null)
            {
                OnExecutionResult?.Invoke(transaction);
                this.Close();
            }
        }

        private TransactionDTO BuildTransacionDTO()
        {
            bool isAllOk = true;
            TransactionDTO transaction = new TransactionDTO()
            {
                ID = transactionID,
                DetailTransaction = new DetailTransacionDTO()
            };

            string typeValue = this.type_text.SelectedItem?.ToString() ?? String.Empty;
            if (!spendTypeList.Contains(typeValue))
            {
                this.type_text.BackColor = Color.Red;
                isAllOk = false;
            }
            else
            {
                transaction.DetailTransaction.Type = typeValue;
            }

            double? amount = Normalizer.NormalizeAmount(this.text_amount.Text);
            
            if (amount == null || !amount.HasValue)
            {
                this.text_amount.BackColor = Color.Red;
                isAllOk = false;
            }
            else
            {
                transaction.Amount = amount.Value;
            }

            transaction.Date = this.dateTimePicker1.Value;

            transaction.DetailTransaction.Description = this.text_description.Text;
            transaction.DetailTransaction.Code = this.text_Codigo.Text;

            transaction.Internal_ID = this.internalTransactionID;
            transaction.Source = this.generationSource;

            return (isAllOk) ? transaction : null;
        }
    }
}
