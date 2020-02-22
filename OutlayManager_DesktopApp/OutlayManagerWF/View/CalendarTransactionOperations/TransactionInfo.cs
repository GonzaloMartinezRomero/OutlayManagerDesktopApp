using OutlayManagerWF.Manager;
using OutlayManagerWF.Model;
using OutlayManagerWF.Model.View;
using OutlayManagerWF.Utilities;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace OutlayManagerWF
{
    public partial class TransactionInfo : Form
    {   
        private readonly DateTime dateSelected;
     
        private readonly TransactionManager transactionManager = new TransactionManager();

        private List<TransactionView> transactionDataSource = new List<TransactionView>();
        private BindingSource bindginDataSource = new BindingSource();
        
        private TransactionInfo()
        {
            InitializeComponent();
        }

        public TransactionInfo(List<TransactionDTO> transactionList, DateTime dateTransactions) : this ()
        {
            dateSelected = dateTransactions;
            
            if(transactionList != null)
            {
                this.transactionDataSource.AddRange(transactionList.Select(x =>
                {
                    return new TransactionView()
                    {
                        ID = x.ID,
                        Amount = x.Amount,
                        Date = x.Date,
                        Type = x.DetailTransaction.Type,
                        Code = x.DetailTransaction.Code,
                        Description = x.DetailTransaction.Description
                    };
                }).ToList());
            }

            bindginDataSource.DataSource = transactionDataSource;
            this.dataGridView1.DataSource = bindginDataSource;
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rowSelected = dataGridView1.SelectedRows;

            switch (rowSelected.Count)
            {
                case 0:
                    this.Enabled = false;
                    Dialog dialog = new Dialog("No one elemented has been selected");
                    dialog.Show();
                    this.Enabled = true;
                    break;

                case 1:
                    
                    TransactionView transactionSelected = (TransactionView)rowSelected[0].DataBoundItem;

                    this.Enabled = false;
                    TransactionSettings settings = new TransactionSettings(transactionSelected);
                    settings.OnExecutionResult += ModifyTransaction;
                    settings.Show();
                    this.Enabled = true;

                    break;

                default:
                    this.Enabled = false;
                    Dialog dialog2 = new Dialog("Only 1 item must be selected");
                    dialog2.Show();
                    this.Enabled = true;
                    break;
                      
            }
        }

        private void Button_NewTransaction(object sender, EventArgs e)
        {
            TransactionSettings settings = new TransactionSettings(dateSelected);
            settings.OnExecutionResult += AddNewTransaction;

            this.Enabled = false;
            settings.Show();
            this.Enabled = true;
        }

        private void Button_Delete(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                TransactionView transactionSelected = (TransactionView)row.DataBoundItem;
              
                TransactionDTO transaction = CastObject.TransactionViewToTransaction(transactionSelected);

                DeleteTransaction(transaction);
            }
        }

        private void Button_SaveChanges(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (!transactionManager.ChangesDetected())
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Information, "No changes detected", null);
            }
            else
            {
                DialogConfirmation confirm = new DialogConfirmation(transactionForDelete: transactionManager.DeletedTransactionList,
                                                                    transactionForModified: transactionManager.ModifiedTransactionList,
                                                                    transactionForAdd: transactionManager.AddedTransactionList);
                confirm.FormClosing += Confirm_FormClosing;
                confirm.Show();
            }
        }

        private void AddNewTransaction(TransactionDTO transactionResult)
        {
            //Add new transaction
            TransactionDTO transactionAdded = transactionManager.AddNewTransaction(transactionResult);

            UpdateTransactionView(CastObject.TransactionToTransactionView(transactionAdded));
        }

        private void ModifyTransaction(TransactionDTO transactionResult)
        {
            TransactionDTO transactionModified = transactionManager.ModifyTransaction(transactionResult);

            UpdateTransactionView(CastObject.TransactionToTransactionView(transactionModified));
        }

        private void DeleteTransaction(TransactionDTO transactionResult)
        {
            transactionManager.DeleteTransaction(transactionResult);

            TransactionView transactionView = CastObject.TransactionToTransactionView(transactionResult);
            transactionView.IsDeleted = true;

            UpdateTransactionView(transactionView);
        }

        private void UpdateTransactionView(TransactionView transactionView)
        {
            Func<TransactionView, bool> idFilter = (TransactionView transactionAux) => {

                switch (transactionAux.Source)
                {
                    case TransactionDTO.SourceGeneration.DataBase:
                        return transactionAux.ID == transactionView.ID;

                    case TransactionDTO.SourceGeneration.NewTransaction:
                        return transactionAux.Internal_ID == transactionView.Internal_ID;

                    default:
                        throw new Exception("Transaction source not defined");
                }
            };

            TransactionView result = transactionDataSource.Where(idFilter)
                                                          .SingleOrDefault();
            
            //Update
            if (result != null)
                transactionDataSource.RemoveAll(new Predicate<TransactionView>(idFilter));
            
            if(!transactionView.IsDeleted)
                transactionDataSource.Add(transactionView);
          
            //Refresh data source
            bindginDataSource.ResetBindings(metadataChanged: false);
        }

        private void Confirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sender is DialogConfirmation confirmationDialog)
            {
                ResultInfo result = confirmationDialog.ResultExecution;

                if (!result.ProcessCancel)
                {
                    List<ResultInfo> resultSaveChanges = transactionManager.SaveChanges();

                    var errorList = resultSaveChanges.Where(x => x.IsError)
                                                     .ToList();

                    if (errorList.Count > 0)
                    {
                        StringBuilder strBuilder = new StringBuilder();

                        foreach (var error in errorList)
                        {
                            strBuilder.AppendLine(error.Message);
                        }

                        Dialog dialog = new Dialog(strBuilder.ToString());
                        dialog.ShowDialog();
                    }

                    this.Close();
                }
            }

            this.Enabled = true;
        }
    }
}
