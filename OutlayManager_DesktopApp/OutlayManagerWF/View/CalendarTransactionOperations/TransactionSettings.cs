using OutlayManagerWF.Model;
using OutlayManagerWF.Model.View;
using OutlayManagerWF.Utilities;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static OutlayManagerWF.WebServices.OutlayDataHelper;

namespace OutlayManagerWF
{
    public partial class TransactionSettings : Form
    {   
        private readonly int transactionID;

        private readonly int internalTransactionID;
        private readonly TransactionDTO.SourceGeneration generationSource;

        public event BuilderTransactionDTO OnExecutionResult;
        public delegate void BuilderTransactionDTO(TransactionDTO transactionResult);
        
        private TransactionSettings()
        {
            InitializeComponent();

            this.textBoxSpendType.ReadOnly = true;
            this.dateTimeSpend.Enabled = false;
        }

        public TransactionSettings(DateTime date, OutlayTypesEnum typeOutlay) : this()
        {
            this.dateTimeSpend.Value = date;
            this.textBoxSpendType.Text = typeOutlay.ToString();
            this.generationSource = TransactionDTO.SourceGeneration.NewTransaction;
        }

        public TransactionSettings(TransactionView transactionView) : this() 
        {
            this.textBoxSpendType.Text = transactionView.Type;
            this.text_amount.Text = Normalizer.NormalizeAmount(transactionView.Amount);
            this.dateTimeSpend.Value = transactionView.Date;
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

            string typeTransactionSelected = this.textBoxSpendType.Text;
            if (!IsCorrectOutlayType(typeTransactionSelected))
            {
                this.textBoxSpendType.BackColor = Color.Red;
                isAllOk = false;
            }
            else
            {
                transaction.DetailTransaction.Type = typeTransactionSelected;
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

            transaction.Date = this.dateTimeSpend.Value;

            transaction.DetailTransaction.Description = this.text_description.Text;
            transaction.DetailTransaction.Code = this.text_Codigo.Text;

            transaction.Internal_ID = this.internalTransactionID;
            transaction.Source = this.generationSource;

            return (isAllOk) ? transaction : null;
        }
    }
}
