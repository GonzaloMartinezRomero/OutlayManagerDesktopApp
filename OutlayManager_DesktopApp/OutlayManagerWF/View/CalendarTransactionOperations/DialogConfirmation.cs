using OutlayManagerWF.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OutlayManagerWF
{
    public partial class DialogConfirmation : Form
    {
        public List<TransactionDTO> TransactionForDelete { get; private set; }
        public List<TransactionDTO> TransactionForAdd { get; private set; }
        public List<TransactionDTO> TransactionForModified { get; private set; }

        public ResultInfo ResultExecution { get; private set; }

        private DialogConfirmation()
        {
            InitializeComponent();

            ResultExecution = new ResultInfo() { IsError = true, Message = "Nothing has hapened" };
        }

        public DialogConfirmation(List<TransactionDTO> transactionForDelete,
                                  List<TransactionDTO> transactionForAdd,
                                  List<TransactionDTO> transactionForModified) : this()
        {
            this.TransactionForAdd = transactionForAdd;
            this.TransactionForDelete = transactionForDelete;
            this.TransactionForModified = transactionForModified;

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("Transaction Add:");
            foreach (var t in transactionForAdd)
                strBuilder.AppendLine(t.ToString());

            strBuilder.AppendLine("Transaction Modified:");
            foreach (var t in transactionForModified)
                strBuilder.AppendLine(t.ToString());

            strBuilder.AppendLine("Transaction Delete:");
            foreach (var t in transactionForDelete)
                strBuilder.AppendLine(t.ToString());

            this.text_Info.Text = strBuilder.ToString();
        }

        private void Acept_Click(object sender, EventArgs e)
        {
            this.ResultExecution.ProcessCancel = false;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.ResultExecution.ProcessCancel = true;
            this.Close();
        }
    }
}
